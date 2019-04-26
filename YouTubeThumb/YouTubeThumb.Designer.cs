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
            this.URL = new System.Windows.Forms.TextBox();
            this.dl = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.HelpBallon = new System.Windows.Forms.ToolTip(this.components);
            this.pb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // URL
            // 
            this.URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URL.BackColor = System.Drawing.Color.Black;
            this.URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.URL.Font = new System.Drawing.Font("Consolas", 9F);
            this.URL.ForeColor = System.Drawing.Color.RoyalBlue;
            this.URL.Location = new System.Drawing.Point(63, 12);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(542, 22);
            this.URL.TabIndex = 0;
            this.URL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.URL_KeyDown);
            // 
            // dl
            // 
            this.dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dl.BackColor = System.Drawing.Color.Black;
            this.dl.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.dl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dl.ForeColor = System.Drawing.Color.RoyalBlue;
            this.dl.Location = new System.Drawing.Point(611, 12);
            this.dl.Name = "dl";
            this.dl.Size = new System.Drawing.Size(61, 22);
            this.dl.TabIndex = 1;
            this.dl.Text = "Extract";
            this.HelpBallon.SetToolTip(this.dl, "Download Thumbnail");
            this.dl.UseVisualStyleBackColor = false;
            this.dl.Click += new System.EventHandler(this.dl_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.Black;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output.Font = new System.Drawing.Font("Consolas", 9F);
            this.output.ForeColor = System.Drawing.Color.RoyalBlue;
            this.output.Location = new System.Drawing.Point(12, 38);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(660, 128);
            this.output.TabIndex = 2;
            // 
            // HelpBallon
            // 
            this.HelpBallon.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpBallon.ForeColor = System.Drawing.Color.Black;
            // 
            // pb
            // 
            this.pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(12, 172);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(660, 378);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 3;
            this.pb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL:";
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save.BackColor = System.Drawing.Color.Black;
            this.save.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.save.ForeColor = System.Drawing.Color.RoyalBlue;
            this.save.Location = new System.Drawing.Point(629, 172);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(43, 22);
            this.save.TabIndex = 5;
            this.save.Text = "SAVE";
            this.HelpBallon.SetToolTip(this.save, "Save Image");
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // YouTubeThumb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.output);
            this.Controls.Add(this.dl);
            this.Controls.Add(this.URL);
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "YouTubeThumb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract Youtube Thumbnail";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Button dl;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.ToolTip HelpBallon;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
    }
}

