namespace WorkFlow
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。1
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.GN = new System.Windows.Forms.ToolStripMenuItem();
            this.总工办 = new System.Windows.Forms.ToolStripMenuItem();
            this.ZGB_Tool1_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ZGD_TOOL1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportPath = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageText = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GN,
            this.Settings});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(801, 25);
            this.TopMenu.TabIndex = 0;
            this.TopMenu.Text = "menuStrip1";
            // 
            // GN
            // 
            this.GN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.总工办});
            this.GN.Name = "GN";
            this.GN.Size = new System.Drawing.Size(44, 21);
            this.GN.Text = "部门";
            // 
            // 总工办
            // 
            this.总工办.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZGB_Tool1_1,
            this.ZGD_TOOL1_2,
            this.PersonArrange});
            this.总工办.Name = "总工办";
            this.总工办.Size = new System.Drawing.Size(112, 22);
            this.总工办.Text = "总工办";
            // 
            // ZGB_Tool1_1
            // 
            this.ZGB_Tool1_1.Name = "ZGB_Tool1_1";
            this.ZGB_Tool1_1.Size = new System.Drawing.Size(184, 22);
            this.ZGB_Tool1_1.Text = "单项目评审记录汇总";
            this.ZGB_Tool1_1.Click += new System.EventHandler(this.ZGB_Tool1_1_Click);
            // 
            // ZGD_TOOL1_2
            // 
            this.ZGD_TOOL1_2.Name = "ZGD_TOOL1_2";
            this.ZGD_TOOL1_2.Size = new System.Drawing.Size(184, 22);
            this.ZGD_TOOL1_2.Text = "单项目评审分数汇总";
            this.ZGD_TOOL1_2.Click += new System.EventHandler(this.ZGB_Tool1_2_Click);
            // 
            // PersonArrange
            // 
            this.PersonArrange.Name = "PersonArrange";
            this.PersonArrange.Size = new System.Drawing.Size(184, 22);
            this.PersonArrange.Text = "人员安排表";
            this.PersonArrange.Click += new System.EventHandler(this.PersonArrange_Click);
            // 
            // Settings
            // 
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExportPath});
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(44, 21);
            this.Settings.Text = "设定";
            // 
            // FileExportPath
            // 
            this.FileExportPath.Name = "FileExportPath";
            this.FileExportPath.Size = new System.Drawing.Size(172, 22);
            this.FileExportPath.Text = "导出文件目录设置";
            this.FileExportPath.Click += new System.EventHandler(this.FileExportPath_Click);
            // 
            // MessageText
            // 
            this.MessageText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MessageText.Location = new System.Drawing.Point(0, 670);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(801, 50);
            this.MessageText.TabIndex = 1;
            this.MessageText.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(0, 660);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(801, 10);
            this.progressBar.TabIndex = 3;
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 25);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(801, 635);
            this.MainPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //this.ClientSize = new System.Drawing.Size(817, 758);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.TopMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenu;
            this.MinimumSize = new System.Drawing.Size(817, 758);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "和创设计-WorkFlow";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip TopMenu;
        public System.Windows.Forms.ToolStripMenuItem GN;
        public System.Windows.Forms.ToolStripMenuItem 总工办;
        public System.Windows.Forms.ToolStripMenuItem ZGB_Tool1_1;
        public System.Windows.Forms.RichTextBox MessageText;
        public System.Windows.Forms.ToolStripMenuItem ZGD_TOOL1_2;
        public System.Windows.Forms.ToolStripMenuItem Settings;
        public System.Windows.Forms.ToolStripMenuItem FileExportPath;
        public System.Windows.Forms.ToolStripMenuItem PersonArrange;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel MainPanel;
    }
}

