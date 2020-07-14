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
    class fixedControls
    {
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
    }
}
