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

        private string downloadTempDir = Path.GetTempPath() + "ytthumb\\";

        private WebClient downloader = new WebClient();

        public YouTubeThumb()
        {
            InitializeComponent();
            images_RMB.Renderer = new patch.fixedControls.BetterToolStripRenderer(Color.Cyan);
            downloader.Headers.Add("user-agent", "ythumb.exe");
        }

        private void YouTubeThumb_Load(object sender, EventArgs e)
        {
           txt_url.Focus();
           this.ActiveControl = txt_url;
        }

        #endregion

        #region func

        private void print(string text, bool tab = false)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txt_output.Text += (tab ? "  " : "") + text + Environment.NewLine;
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

                try
                {
                  //if (!url.Contains("www.youtube.com"))                  { print("ERROR: invalid youtube URL: " + url); throw new ArgumentException("Not a yotubue url", "original"); }
                    if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) { print("ERROR: invalid URL: " + url);         throw new ArgumentException("Not valid url", "original");     }

                    print(url + " {");

                    byte[] html = html = downloader.DownloadData(url);
                    print("> Searching HTML for images...", true);

                    int count = 0;
                    string[] links = getLinks(html);
                    List<string> validLinks = new List<string>();
                    foreach (string link in links)
                    {
                        if (!Uri.IsWellFormedUriString(link, UriKind.Absolute)) { continue; }
                        if (!URLisImage(link)) { continue; }
                        validLinks.Add(link);
                    }
                    print("> found " + validLinks.Count + " URL(s)", true);
                    int pad = validLinks.Count.ToString().Length;
                    foreach (string link in validLinks)
                    {
                        string filename = Path.GetFileName(new Uri(link).LocalPath);
                        if (!Directory.Exists(downloadTempDir)) { Directory.CreateDirectory(downloadTempDir); }
                        string savePath = downloadTempDir + filename;

                        if (File.Exists(savePath))
                        {
                            FileInfo fi = new FileInfo(savePath);
                            int c = 1;
                            savePath = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) + " [" + c + "]" + fi.Extension;
                            while (File.Exists(savePath))
                            { c++; savePath = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) + " [" + c + "]" + fi.Extension; }
                        }

                        downloader.DownloadFile(link, savePath);
                        count++;

                        print("> " + count.ToString().PadLeft(pad, ' ') + ": " + link, true);

                        Image img = Image.FromFile(savePath);
                        int size = Math.Max(img.Width, img.Height);
                        Bitmap bmpDrawOn = new Bitmap(size, size);
                        using (Graphics g = Graphics.FromImage(bmpDrawOn))
                        { g.Clear(Color.Transparent); g.DrawImage(img, 0, 0); }
                        img.Dispose();

                        this.Invoke((MethodInvoker)delegate
                        {
                            imageList.Images.Add(bmpDrawOn);
                            images.Items.Add(
                                new ListViewItem()
                                {
                                    Name = savePath,
                                    Text = Path.GetFileName(savePath),
                                    ImageIndex = imageList.Images.Count - 1
                                }
                            );
                        });
                    }

                    print("}");
                }
                catch (Exception) { }

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
            return links.Distinct().ToArray();
        }

        #endregion

        #region UI events

        #region Draw

        private void HelpBallon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

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
                ExplorerSelect(text);
            }
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            downloadThumb(txt_url.Text);
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_output.Text = "";
            images.Items.Clear();
            imageList.Images.Clear();
        }
        private void btn_folder_Click(object sender, EventArgs e)
        {
            Explorer(downloadTempDir);
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
        private bool OpenFile(string file)
        {
            if (!File.Exists(file)) { print("ERROR: can't find file"); return false; }
            try { Process.Start(file); }
            catch (Win32Exception e)          { print("ERROR: " + e.Message); }
            catch (ObjectDisposedException e) { print("ERROR: " + e.Message); }
            catch (FileNotFoundException e)   { print("ERROR: " + e.Message); }
            catch (Exception e)               { print("ERROR: " + e.Message); }

            print("Open: " + file);
            return true;
        }
        private bool Explorer(string dir)
        {
            try { Process.Start("explorer.exe", "\"" + dir + "\""); }
            catch (Win32Exception e)          { print("ERROR: " + e.Message); }
            catch (ObjectDisposedException e) { print("ERROR: " + e.Message); }
            catch (FileNotFoundException e)   { print("ERROR: " + e.Message); }
            catch (Exception e)               { print("ERROR: " + e.Message); }
            print("Explorer: " + dir);
            return true;
        }
        private bool ExplorerSelect(string file)
        {
            try { Process.Start("explorer.exe", "/select,\"" + file + "\""); }
            catch (Win32Exception e)          { print("ERROR: " + e.Message); }
            catch (ObjectDisposedException e) { print("ERROR: " + e.Message); }
            catch (FileNotFoundException e)   { print("ERROR: " + e.Message); }
            catch (Exception e)               { print("ERROR: " + e.Message); }
            print("Explorer Select: " + file);
            return true;
        }


        #endregion
    }
}
