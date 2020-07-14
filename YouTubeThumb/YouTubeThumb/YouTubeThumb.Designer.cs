namespace YouTubeThumb
{
    partial class YouTubeThumb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YouTubeThumb));
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_dl = new System.Windows.Forms.Button();
            this.HelpBallon = new System.Windows.Forms.ToolTip(this.components);
            this.label_url = new System.Windows.Forms.Label();
            this.images = new fixedControls.FixedListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.txt_output = new fixedControls.FixedRichTextBox();
            this.images_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.images_RMB_explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.sc = new System.Windows.Forms.SplitContainer();
            this.images_RMB_open = new System.Windows.Forms.ToolStripMenuItem();
            this.images_RMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_url.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_url.ForeColor = System.Drawing.Color.Cyan;
            this.txt_url.Location = new System.Drawing.Point(63, 12);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(1020, 25);
            this.txt_url.TabIndex = 0;
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            // 
            // btn_dl
            // 
            this.btn_dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dl.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_dl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dl.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dl.ForeColor = System.Drawing.Color.Cyan;
            this.btn_dl.Location = new System.Drawing.Point(1089, 12);
            this.btn_dl.Name = "btn_dl";
            this.btn_dl.Size = new System.Drawing.Size(75, 25);
            this.btn_dl.TabIndex = 1;
            this.btn_dl.Text = "Extract";
            this.HelpBallon.SetToolTip(this.btn_dl, "Download Thumbnail");
            this.btn_dl.UseVisualStyleBackColor = false;
            this.btn_dl.Click += new System.EventHandler(this.btn_dl_Click);
            // 
            // HelpBallon
            // 
            this.HelpBallon.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpBallon.ForeColor = System.Drawing.Color.Black;
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_url.ForeColor = System.Drawing.Color.Cyan;
            this.label_url.Location = new System.Drawing.Point(12, 14);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(45, 19);
            this.label_url.TabIndex = 4;
            this.label_url.Text = "URL:";
            // 
            // images
            // 
            this.images.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.images.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.images.ContextMenuStrip = this.images_RMB;
            this.images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.images.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.images.ForeColor = System.Drawing.Color.Cyan;
            this.images.HideSelection = false;
            this.images.LargeImageList = this.imageList;
            this.images.Location = new System.Drawing.Point(0, 0);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(298, 504);
            this.images.SmallImageList = this.imageList;
            this.images.TabIndex = 5;
            this.images.UseCompatibleStateImageBehavior = false;
            this.images.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.images_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txt_output
            // 
            this.txt_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_output.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_output.ForeColor = System.Drawing.Color.Cyan;
            this.txt_output.Location = new System.Drawing.Point(0, 0);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(843, 504);
            this.txt_output.TabIndex = 6;
            this.txt_output.Text = "";
            this.txt_output.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txt_output_LinkClicked);
            // 
            // images_RMB
            // 
            this.images_RMB.BackColor = System.Drawing.Color.Black;
            this.images_RMB.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.images_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.images_RMB_open,
            this.images_RMB_explorer});
            this.images_RMB.Name = "images_RMB";
            this.images_RMB.ShowImageMargin = false;
            this.images_RMB.Size = new System.Drawing.Size(133, 56);
            // 
            // images_RMB_explorer
            // 
            this.images_RMB_explorer.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.images_RMB_explorer.ForeColor = System.Drawing.Color.RoyalBlue;
            this.images_RMB_explorer.Name = "images_RMB_explorer";
            this.images_RMB_explorer.Size = new System.Drawing.Size(132, 26);
            this.images_RMB_explorer.Text = "Explorer";
            this.images_RMB_explorer.Click += new System.EventHandler(this.images_RMB_explorer_Click);
            // 
            // sc
            // 
            this.sc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc.Location = new System.Drawing.Point(15, 43);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.txt_output);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.images);
            this.sc.Size = new System.Drawing.Size(1149, 506);
            this.sc.SplitterDistance = 845;
            this.sc.TabIndex = 9;
            this.sc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseDown);
            this.sc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseMove);
            this.sc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseUp);
            // 
            // images_RMB_open
            // 
            this.images_RMB_open.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.images_RMB_open.ForeColor = System.Drawing.Color.RoyalBlue;
            this.images_RMB_open.Name = "images_RMB_open";
            this.images_RMB_open.Size = new System.Drawing.Size(132, 26);
            this.images_RMB_open.Text = "Open";
            this.images_RMB_open.Click += new System.EventHandler(this.images_RMB_open_Click);
            // 
            // YouTubeThumb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1176, 561);
            this.Controls.Add(this.sc);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.btn_dl);
            this.Controls.Add(this.txt_url);
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "YouTubeThumb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract Youtube Thumbnail";
            this.Load += new System.EventHandler(this.YouTubeThumb_Load);
            this.images_RMB.ResumeLayout(false);
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_dl;
        private System.Windows.Forms.ToolTip HelpBallon;
        private System.Windows.Forms.Label label_url;
        private fixedControls.FixedListView images;
        private System.Windows.Forms.ImageList imageList;
        private fixedControls.FixedRichTextBox txt_output;
        private System.Windows.Forms.ContextMenuStrip images_RMB;
        private System.Windows.Forms.ToolStripMenuItem images_RMB_explorer;
        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.ToolStripMenuItem images_RMB_open;
    }
}

