using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace YouTubeThumb
{
    public partial class YouTubeThumb : Form
    {
        #region main

        public static readonly IList<string> ImageTypes = new System.Collections.ObjectModel.ReadOnlyCollection<string>(new[] {
            ".jpg", ".jpeg", ".jiff", ".jfif", ".png", ".gif", ".ico", ".svg", ".bmp", ".dib", ".tif", ".tiff"
        });

        private WebClient downloader = new WebClient();

        public YouTubeThumb()
        {
            InitializeComponent();
            downloader.Headers.Add("user-agent", "ythumb.exe");
        }

        private void YouTubeThumb_Load(object sender, EventArgs e)
        {
           txt_url.Focus();
           this.ActiveControl = txt_url;
        }

        #endregion

        #region func

        private void print(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txt_output.Text += text + Environment.NewLine;
                txt_output.SelectionStart = txt_output.Text.Length;
                txt_output.ScrollToCaret();
            });
        }
        private bool downloadThumb_isBusy = false;
        private void downloadThumb(string url)
        {
            new Thread(() =>
            {
                if (downloadThumb_isBusy) { return; }
                downloadThumb_isBusy = true;

              //if (!url.Contains("www.youtube.com"))                  { print("ERROR: invalid youtube URL: " + url); downloadThumb_isBusy = false; return; }
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) { print("ERROR: invalid URL: " + url);         downloadThumb_isBusy = false; return; }

                print("DOWNLOADING HTML........: " + url);

                byte[] html = null;
                try { html = downloader.DownloadData(url); }
                catch (WebException e)          { print("ERROR: " + e.Message); downloadThumb_isBusy = false; return; }
                catch (ArgumentNullException e) { print("ERROR: " + e.Message); downloadThumb_isBusy = false; return; }

                print("DOWNLOADED HTML.........: " + ROund(html.Length) + " (" + html.Length + " bytes)");
                print("SEARCHING HTML FOR THUMBNAIL URL...");

                string[] links = getLinks(html);
                foreach (string link in links)
                {
                    if (Uri.IsWellFormedUriString(link, UriKind.Absolute) && URLisImage(link))
                    {
                        print("DOWNLOADING IMAGE...: " + link);

                        string filename = Path.GetFileName(new Uri(link).LocalPath);
                        string tempDir = Path.GetTempPath() + "ytthumb\\";
                        if (!Directory.Exists(tempDir)) { Directory.CreateDirectory(tempDir); }
                        string savePath = tempDir + filename;

                        if (File.Exists(savePath))
                        {
                            FileInfo fi = new FileInfo(savePath);
                            int c = 1;
                            savePath = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) + " [" + c + "]" + fi.Extension;
                            while (File.Exists(savePath))
                            { c++;savePath = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) + " [" + c + "]" + fi.Extension; }
                        }

                        downloader.DownloadFile(link, savePath);

                        print("DOWNLOADED IMAGE....: " + link);

                        Image img = Image.FromFile(savePath);
                        int size = Math.Max(img.Width, img.Height);
                        Bitmap bmpDrawOn = new Bitmap(size, size);
                        using (Graphics g = Graphics.FromImage(bmpDrawOn)) { g.Clear(Color.Transparent); g.DrawImage(img, 0, 0); }
                        img.Dispose();

                        this.Invoke((MethodInvoker)delegate
                        {
                            imageList.Images.Add(bmpDrawOn);
                            ListViewItem lvi = new ListViewItem() { Name = savePath, Text = filename, ImageIndex = imageList.Images.Count - 1 };
                            images.Items.Add(lvi);
                        });
                    }
                }

                print("DONE!");

                downloadThumb_isBusy = false;
            })
            { IsBackground = true }.Start();
        }
        private string[] getLinks(byte[] html)
        {
            List<string> links = new List<string>();
            string link = "";
            bool afterQuote = false;
            foreach (char ch in Encoding.Default.GetString(html).ToArray())
            {
                if (ch == '"')
                {
                    afterQuote = !afterQuote;
                    if (!afterQuote) { links.Add(link); link = ""; }
                }
                else if (afterQuote) { link = link + ch; }
            }
            return links.ToArray();
        }

        #endregion

        #region UI events

        private void images_open()
        {
            foreach (ListViewItem item in images.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                OpenFile(text);
            }
        }
        private void images_explorer()
        {
            foreach (ListViewItem item in images.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                OpenAndSelectInExplorer(text);
            }
        }

        private void btn_dl_Click(object sender, EventArgs e)
        {
            downloadThumb(txt_url.Text);
        }
        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                downloadThumb(txt_url.Text);
                e.SuppressKeyPress = e.Handled = true;
            }
        }
        private void txt_output_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
        private void images_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            images_open();
        }

        // RMB
        private void images_RMB_open_Click(object sender, EventArgs e)
        {
            images_open();
        }
        private void images_RMB_explorer_Click(object sender, EventArgs e)
        {
            images_explorer();
        }

        #region sc update

        private void splitContainer_MouseDown(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = true;
        }
        private void splitContainer_MouseUp(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = false;
        }
        private void splitContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
                    {
                        if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                        {
                            ((SplitContainer)sender).SplitterDistance = e.X;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                    else
                    {
                        if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.Y;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                }
                else
                {
                    ((SplitContainer)sender).IsSplitterFixed = false;
                }
            }
        }

        #endregion

        #endregion

        #region other functions

        private bool URLisImage(string url)
        {
            foreach (string type in ImageTypes) { if (url.Contains(type)) { return true; } }
            return false;
        }
        private string ROund(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
        public bool OpenFile(string file)
        {
            if (!File.Exists(file)) { print("ERROR: can't find file"); return false; }
            try { Process.Start(file); }
            catch (Win32Exception e)          { print("ERROR: " + e.Message); }
            catch (ObjectDisposedException e) { print("ERROR: " + e.Message); }
            catch (FileNotFoundException e)   { print("ERROR: " + e.Message); }
            catch (Exception e)               { print("ERROR: " + e.Message); }

            print("OPENED: " + file);
            return true;
        }
        public bool OpenAndSelectInExplorer(string file)
        {
            try { Process.Start("explorer.exe", "/select,\"" + file + "\""); }
            catch (Win32Exception e)          { print("ERROR: " + e.Message); }
            catch (ObjectDisposedException e) { print("ERROR: " + e.Message); }
            catch (FileNotFoundException e)   { print("ERROR: " + e.Message); }
            catch (Exception e)               { print("ERROR: " + e.Message); }

            print("EXPLORER: " + file);
            return true;
        }

        #endregion

        #region custom controls (patches)

        public class FixedListView : ListView
        {
            public FixedListView()
            {
                this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.EnableNotifyMessage, true);
            }

            protected override void OnNotifyMessage(Message m)
            {
                //Filter out the WM_ERASEBKGND message
                if (m.Msg != 0x14)
                {
                    base.OnNotifyMessage(m);
                }
            }
        }

        public class FixedRichTextBox : RichTextBox
        {
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                if (!base.AutoWordSelection)
                {
                    base.AutoWordSelection = true;
                    base.AutoWordSelection = false;
                }
            }
        }

        #endregion
    }
}
