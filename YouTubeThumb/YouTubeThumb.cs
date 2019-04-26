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

namespace YouTubeThumb
{
    public partial class YouTubeThumb : Form
    {
        public YouTubeThumb()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           URL.Focus();
           this.ActiveControl = URL;
        }

        private bool GetThumbnail_Busy = false;
        private void GetThumbnail_Busy_sw(bool busy)
        {
            if (busy == true)
            {
                GetThumbnail_Busy = true;

                dl.Enabled = false;
                URL.Enabled = false;

                output.Text = "";
                output.Focus();
                ActiveControl = output;
            }
            else
            {
                GetThumbnail_Busy = false;

                dl.Enabled = true;
                URL.Enabled = true;
            }
        }
        private void GetThumbnail_Thread(string url)
        {
            if (GetThumbnail_Busy == false)
            {
                new Thread(() => GetThumbnail(url)) { IsBackground =true }.Start();
            }
        }
        private void GetThumbnail(string url)
        {
            GetThumbnail_Busy_sw(true);
            
            if (url.Contains("www.youtube.com"))
            {
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    //DOWNLOAD HTML
                    output.Text += "DOWNLOADING HTML........: " + url + Environment.NewLine; ;

                    byte[] html = null;

                    try
                    {
                        html = new System.Net.WebClient().DownloadData(url);
                    }
                    catch (System.Net.WebException)
                    {
                        output.Text += "ERR: Forbidden." + Environment.NewLine;
                        GetThumbnail_Busy_sw(false);
                        return;
                    }
                    catch (ArgumentNullException)
                    {
                        output.Text += "ERR: null" + Environment.NewLine;
                        GetThumbnail_Busy_sw(false);
                        return;
                    }

                    output.Text += "DOWNLOADED HTML.........: " + ROund(html.Length) + " (" + html.Length + " bytes)" + Environment.NewLine; ;

                    char[] htmlChars = System.Text.Encoding.Default.GetString(html).ToArray();

                    output.Text += "SEARCHING HTML FOR THUMBNAIL URL..." + Environment.NewLine; ;

                    //get urls like this: blablablablablablabla "some url we want" blablablablabla
                    List<string> links = new List<string>();
                    string link = "";
                    bool afterQuote = false;
                    foreach (char ch in htmlChars)
                    {
                        if (ch == '"')
                        {
                            afterQuote = !afterQuote;

                            if (afterQuote == false)
                            {
                                links.Add(link);
                                link = "";
                            }
                        }
                        else if (afterQuote == true)
                        {
                            link = link + ch; //add chars to string after quote
                        }
                    }

                    int dump = 0;
                    int maxres_count = 0;
                    string is_same_url = "";
                    foreach (string l in links)
                    {
                        if (Uri.IsWellFormedUriString(l, UriKind.Absolute))
                        {
                            if (l.Contains("maxres"))
                            {
                                if (is_same_url != l)
                                {
                                    is_same_url = l;

                                    string FileName = "maxres_" + maxres_count + ".jpg";

                                    output.Text += "DOWNLOADING THUMBNAIL...: " + l + Environment.NewLine;
                                    pb.Load(l);
                                    output.Text += "DOWNLOADED THUMBNAIL....: " + l + Environment.NewLine; ;
                                    maxres_count++;
                                }
                            }
                            else
                            {
                                dump++;
                            }
                        }
                        else
                        {
                            dump++;
                        }
                    }

                    // output.Text += Environment.NewLine;
                    // output.Text += "===[DEBUG]===" + Environment.NewLine;
                    // output.Text += "dumped lines: " + dump + Environment.NewLine;
                    // output.Text += "end;" + Environment.NewLine;

                    GetThumbnail_Busy_sw(false);
                    return;
                }
            }

            output.Text += "Not a youtube link [" + url + "]" + Environment.NewLine;
            GetThumbnail_Busy_sw(false);
            return;
        }
        
        private void dl_Click(object sender, EventArgs e)
        {
            GetThumbnail_Thread(URL.Text);
        }

        #region other

        //other
        private static string ROund(double roundMe)
        {
            // 1 Byte = 8 Bit
            // 1 Kilobyte = 1024 Bytes
            // 1 Megabyte = 1048576 Bytes
            // 1 Gigabyte = 1073741824 Bytes
            // 1 Terabyte = 1099511627776 Bytes

            double roundMe_CONVERTED = 0;
            string roundMe_CONVERTED_STRING = "";

            if (roundMe > 1099511627776) //TB
            {
                roundMe_CONVERTED = roundMe / 1099511627776;
                roundMe_CONVERTED_STRING = Math.Round(roundMe_CONVERTED, 2) + " TB";
            }
            else if (roundMe > 1073741824) //GB
            {
                roundMe_CONVERTED = roundMe / 1073741824;
                roundMe_CONVERTED_STRING = Math.Round(roundMe_CONVERTED, 2) + " GB";
            }
            else if (roundMe > 1048576) //MB
            {
                roundMe_CONVERTED = roundMe / 1048576;
                roundMe_CONVERTED_STRING = Math.Round(roundMe_CONVERTED, 2) + " MB";
            }
            else if (roundMe > 1024) //KB
            {
                roundMe_CONVERTED = roundMe / 1024;
                roundMe_CONVERTED_STRING = Math.Round(roundMe_CONVERTED, 2) + " KB";
            }

            return roundMe_CONVERTED_STRING;
        }
        private static string GetTime()
        {
            TimeSpan diff = (new DateTime(2011, 02, 10) - new DateTime(2011, 02, 01));
            return diff.TotalMilliseconds.ToString();
        }

        #endregion

        private void URL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dl_Click(null, null);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (pb.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Images|*.png;*.bmp;*.jpg", FileName = "thumbnail" };

                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pb.Image.Save(sfd.FileName, format);
                }
            }
            else
            {
                output.Text += "No image has been downloaded (picture box is empty...)" + Environment.NewLine;
            }
        }
    }
}
