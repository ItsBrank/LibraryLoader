namespace LibraryLoader
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            ProcessGroupBx = new System.Windows.Forms.GroupBox();
            StatusLbl = new System.Windows.Forms.Label();
            LoadBtn = new System.Windows.Forms.Button();
            AutoBx = new System.Windows.Forms.CheckBox();
            DelayBx = new System.Windows.Forms.NumericUpDown();
            DelayLbl = new System.Windows.Forms.Label();
            BrowseBtn = new System.Windows.Forms.Button();
            FileBx = new System.Windows.Forms.TextBox();
            FileLbl = new System.Windows.Forms.Label();
            RefreshBtn = new System.Windows.Forms.Button();
            PIDBx = new System.Windows.Forms.NumericUpDown();
            ProcessBx = new System.Windows.Forms.ComboBox();
            ProcessLbl = new System.Windows.Forms.Label();
            DelayTmr = new System.Windows.Forms.Timer(components);
            ProcessTmr = new System.Windows.Forms.Timer(components);
            MenuStrp = new System.Windows.Forms.MenuStrip();
            AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ProcessGroupBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DelayBx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PIDBx).BeginInit();
            MenuStrp.SuspendLayout();
            SuspendLayout();
            // 
            // ProcessGroupBx
            // 
            ProcessGroupBx.Controls.Add(StatusLbl);
            ProcessGroupBx.Controls.Add(LoadBtn);
            ProcessGroupBx.Controls.Add(AutoBx);
            ProcessGroupBx.Controls.Add(DelayBx);
            ProcessGroupBx.Controls.Add(DelayLbl);
            ProcessGroupBx.Controls.Add(BrowseBtn);
            ProcessGroupBx.Controls.Add(FileBx);
            ProcessGroupBx.Controls.Add(FileLbl);
            ProcessGroupBx.Controls.Add(RefreshBtn);
            ProcessGroupBx.Controls.Add(PIDBx);
            ProcessGroupBx.Controls.Add(ProcessBx);
            ProcessGroupBx.Controls.Add(ProcessLbl);
            ProcessGroupBx.Location = new System.Drawing.Point(13, 28);
            ProcessGroupBx.Name = "ProcessGroupBx";
            ProcessGroupBx.Size = new System.Drawing.Size(495, 145);
            ProcessGroupBx.TabIndex = 0;
            ProcessGroupBx.TabStop = false;
            ProcessGroupBx.Text = "Process";
            // 
            // StatusLbl
            // 
            StatusLbl.BackColor = System.Drawing.Color.Transparent;
            StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            StatusLbl.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            StatusLbl.Location = new System.Drawing.Point(260, 113);
            StatusLbl.Name = "StatusLbl";
            StatusLbl.Size = new System.Drawing.Size(225, 25);
            StatusLbl.TabIndex = 20;
            StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoadBtn
            // 
            LoadBtn.Enabled = false;
            LoadBtn.Location = new System.Drawing.Point(260, 82);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new System.Drawing.Size(225, 25);
            LoadBtn.TabIndex = 18;
            LoadBtn.Text = "Load File";
            LoadBtn.UseVisualStyleBackColor = true;
            LoadBtn.Click += LoadBtn_Click;
            // 
            // AutoBx
            // 
            AutoBx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            AutoBx.Location = new System.Drawing.Point(120, 113);
            AutoBx.Name = "AutoBx";
            AutoBx.Size = new System.Drawing.Size(135, 25);
            AutoBx.TabIndex = 19;
            AutoBx.Text = "Auto load file";
            AutoBx.UseVisualStyleBackColor = true;
            AutoBx.CheckedChanged += AutoBx_CheckedChanged;
            // 
            // DelayBx
            // 
            DelayBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DelayBx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DelayBx.Location = new System.Drawing.Point(120, 82);
            DelayBx.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            DelayBx.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            DelayBx.Name = "DelayBx";
            DelayBx.Size = new System.Drawing.Size(135, 25);
            DelayBx.TabIndex = 18;
            DelayBx.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            DelayBx.ValueChanged += DelayBx_ValueChanged;
            // 
            // DelayLbl
            // 
            DelayLbl.BackColor = System.Drawing.Color.Transparent;
            DelayLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            DelayLbl.Location = new System.Drawing.Point(5, 82);
            DelayLbl.Name = "DelayLbl";
            DelayLbl.Size = new System.Drawing.Size(110, 25);
            DelayLbl.TabIndex = 18;
            DelayLbl.Text = "Auto Delay:";
            DelayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new System.Drawing.Point(385, 50);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new System.Drawing.Size(100, 25);
            BrowseBtn.TabIndex = 17;
            BrowseBtn.Text = "Browse";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // FileBx
            // 
            FileBx.BackColor = System.Drawing.Color.WhiteSmoke;
            FileBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FileBx.Enabled = false;
            FileBx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FileBx.Location = new System.Drawing.Point(120, 51);
            FileBx.Name = "FileBx";
            FileBx.ReadOnly = true;
            FileBx.Size = new System.Drawing.Size(260, 25);
            FileBx.TabIndex = 16;
            // 
            // FileLbl
            // 
            FileLbl.BackColor = System.Drawing.Color.Transparent;
            FileLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FileLbl.Location = new System.Drawing.Point(5, 50);
            FileLbl.Name = "FileLbl";
            FileLbl.Size = new System.Drawing.Size(110, 25);
            FileLbl.TabIndex = 15;
            FileLbl.Text = "Selected File:";
            FileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RefreshBtn
            // 
            RefreshBtn.Location = new System.Drawing.Point(385, 20);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new System.Drawing.Size(100, 25);
            RefreshBtn.TabIndex = 14;
            RefreshBtn.Text = "Refresh";
            RefreshBtn.UseVisualStyleBackColor = true;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // PIDBx
            // 
            PIDBx.BackColor = System.Drawing.Color.White;
            PIDBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PIDBx.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            PIDBx.ForeColor = System.Drawing.Color.Black;
            PIDBx.Location = new System.Drawing.Point(316, 20);
            PIDBx.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            PIDBx.Name = "PIDBx";
            PIDBx.Size = new System.Drawing.Size(64, 25);
            PIDBx.TabIndex = 13;
            PIDBx.Value = new decimal(new int[] { 1, 0, 0, 0 });
            PIDBx.KeyUp += PIDBx_KeyUp;
            // 
            // ProcessBx
            // 
            ProcessBx.BackColor = System.Drawing.Color.White;
            ProcessBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ProcessBx.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            ProcessBx.ForeColor = System.Drawing.Color.Black;
            ProcessBx.FormattingEnabled = true;
            ProcessBx.Location = new System.Drawing.Point(120, 20);
            ProcessBx.Name = "ProcessBx";
            ProcessBx.Size = new System.Drawing.Size(188, 25);
            ProcessBx.TabIndex = 12;
            ProcessBx.SelectedValueChanged += ProcessBx_SelectedValueChanged;
            // 
            // ProcessLbl
            // 
            ProcessLbl.BackColor = System.Drawing.Color.Transparent;
            ProcessLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            ProcessLbl.Location = new System.Drawing.Point(5, 20);
            ProcessLbl.Name = "ProcessLbl";
            ProcessLbl.Size = new System.Drawing.Size(110, 25);
            ProcessLbl.TabIndex = 11;
            ProcessLbl.Text = "Process/PID:";
            ProcessLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DelayTmr
            // 
            DelayTmr.Interval = 10000;
            DelayTmr.Tick += DelayTmr_Tick;
            // 
            // ProcessTmr
            // 
            ProcessTmr.Interval = 1500;
            ProcessTmr.Tick += ProcessTmr_Tick;
            // 
            // MenuStrp
            // 
            MenuStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { AboutMenuItem });
            MenuStrp.Location = new System.Drawing.Point(0, 0);
            MenuStrp.Name = "MenuStrp";
            MenuStrp.Size = new System.Drawing.Size(522, 24);
            MenuStrp.TabIndex = 1;
            MenuStrp.Text = "menuStrip1";
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new System.Drawing.Size(52, 20);
            AboutMenuItem.Text = "About";
            AboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 186);
            Controls.Add(ProcessGroupBx);
            Controls.Add(MenuStrp);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrp;
            MaximizeBox = false;
            Name = "MainFrm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ItsBrank's Library Loader";
            Load += MainFrm_Load;
            ProcessGroupBx.ResumeLayout(false);
            ProcessGroupBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DelayBx).EndInit();
            ((System.ComponentModel.ISupportInitialize)PIDBx).EndInit();
            MenuStrp.ResumeLayout(false);
            MenuStrp.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox ProcessGroupBx;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.NumericUpDown PIDBx;
        private System.Windows.Forms.ComboBox ProcessBx;
        private System.Windows.Forms.Label ProcessLbl;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox FileBx;
        private System.Windows.Forms.Label FileLbl;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.CheckBox AutoBx;
        private System.Windows.Forms.NumericUpDown DelayBx;
        private System.Windows.Forms.Label DelayLbl;
        private System.Windows.Forms.Timer DelayTmr;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Timer ProcessTmr;
        private System.Windows.Forms.MenuStrip MenuStrp;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.PictureBox FileImg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
