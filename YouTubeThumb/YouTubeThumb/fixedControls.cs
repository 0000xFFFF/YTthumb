using System;
using System.Windows.Forms;
using System.Drawing;

namespace patch
{
    class fixedControls
    {
        public partial class toolStripProfessionalColorTable : ProfessionalColorTable
        {
            private readonly Color ThemeColor = Color.Cyan;

            public toolStripProfessionalColorTable(Color themeColor)
            {
                base.UseSystemColors = false;

                ThemeColor = themeColor;
            }

            public override Color MenuBorder     { get { return ThemeColor; } }
            public override Color MenuItemBorder { get { return ThemeColor; } }

            // MENU SUBITEM HOVER & BORDER
            public override Color ToolStripDropDownBackground { get { return Color.FromArgb(15, 15, 15); } }
            public override Color ToolStripBorder             { get { return Color.Cyan; } }

            public override Color ToolStripGradientBegin  { get { return Color.Transparent; } }
            public override Color ToolStripGradientEnd    { get { return Color.Transparent; } }
            public override Color ToolStripGradientMiddle { get { return Color.Transparent; } }

            public override Color OverflowButtonGradientBegin  { get { return ThemeColor; } }
            public override Color OverflowButtonGradientMiddle { get { return ThemeColor; } }
            public override Color OverflowButtonGradientEnd    { get { return ThemeColor; } }

            public override Color CheckBackground         { get { return Color.FromArgb(15, 15, 15); } }
            public override Color CheckPressedBackground  { get { return Color.FromArgb(15, 15, 15); } }
            public override Color CheckSelectedBackground { get { return Color.FromArgb(15, 15, 15); } }

            public override Color ButtonSelectedHighlightBorder { get { return ThemeColor; } }
            public override Color ButtonPressedHighlightBorder  { get { return ThemeColor; } }
            public override Color ButtonCheckedHighlightBorder  { get { return ThemeColor; } }
            public override Color ButtonPressedBorder           { get { return ThemeColor; } }
            public override Color ButtonSelectedBorder          { get { return ThemeColor; } }


            // MENU HOVER
            public override Color MenuItemSelectedGradientBegin { get { return Color.Transparent; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.Transparent; } }
            public override Color MenuItemSelectedGradientEnd   { get { return Color.MidnightBlue; } }

            // MENU PRESS
            public override Color MenuItemPressedGradientBegin { get { return Color.MidnightBlue; } }
            public override Color MenuItemPressedGradientEnd   { get { return Color.Transparent; } }

            // hover over subitem
            public override Color MenuItemSelected { get { return Color.FromArgb(0, 0, 30); } }


            public override Color ImageMarginGradientBegin  { get { return Color.Transparent; } }
            public override Color ImageMarginGradientMiddle { get { return Color.Transparent; } }
            public override Color ImageMarginGradientEnd    { get { return Color.Transparent; } }
        }
        public partial class BetterToolStripRenderer : ToolStripProfessionalRenderer
        {
            public BetterToolStripRenderer(Color ThemeColor) : base(new toolStripProfessionalColorTable(ThemeColor))
            {

            }

            //arrow color
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)e.Item;
                if (tsMenuItem != null) { e.ArrowColor = Color.Silver; }
                base.OnRenderArrow(e);
            }
        }

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
