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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.TabPersonArrange = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainGrid = new System.Windows.Forms.DataGridView();
            this.project_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.person_des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.person_jd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.person_sh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailTab = new System.Windows.Forms.TabPage();
            this.detailGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_TP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DG_PD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_PJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_PS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_XS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.detailArrangeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TopMenu.SuspendLayout();
            this.TabPersonArrange.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.DetailTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailArrangeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GN,
            this.Settings});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(784, 25);
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
            this.MessageText.Location = new System.Drawing.Point(0, 512);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(784, 50);
            this.MessageText.TabIndex = 1;
            this.MessageText.Text = "";
            // 
            // TabPersonArrange
            // 
            this.TabPersonArrange.Controls.Add(this.MainTab);
            this.TabPersonArrange.Controls.Add(this.DetailTab);
            this.TabPersonArrange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPersonArrange.Location = new System.Drawing.Point(0, 25);
            this.TabPersonArrange.Name = "TabPersonArrange";
            this.TabPersonArrange.SelectedIndex = 0;
            this.TabPersonArrange.Size = new System.Drawing.Size(784, 487);
            this.TabPersonArrange.TabIndex = 2;
            this.TabPersonArrange.Visible = false;
            // 
            // MainTab
            // 
            this.MainTab.AutoScroll = true;
            this.MainTab.Controls.Add(this.tableLayoutPanel1);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(776, 461);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "项目信息";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.MainGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.21978F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.78022F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainGrid
            // 
            this.MainGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.project_id,
            this.project_name,
            this.person_des,
            this.person_jd,
            this.person_sh,
            this.xs});
            this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainGrid.Location = new System.Drawing.Point(3, 185);
            this.MainGrid.Name = "MainGrid";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MainGrid.RowTemplate.Height = 23;
            this.MainGrid.Size = new System.Drawing.Size(764, 267);
            this.MainGrid.TabIndex = 0;
            // 
            // project_id
            // 
            this.project_id.HeaderText = "子项目序号";
            this.project_id.Name = "project_id";
            // 
            // project_name
            // 
            this.project_name.HeaderText = "子项目名称";
            this.project_name.Name = "project_name";
            // 
            // person_des
            // 
            this.person_des.HeaderText = "设计人";
            this.person_des.Name = "person_des";
            // 
            // person_jd
            // 
            this.person_jd.HeaderText = "校核人";
            this.person_jd.Name = "person_jd";
            // 
            // person_sh
            // 
            this.person_sh.HeaderText = "审核人";
            this.person_sh.Name = "person_sh";
            // 
            // xs
            // 
            this.xs.HeaderText = "系数";
            this.xs.Name = "xs";
            // 
            // DetailTab
            // 
            this.DetailTab.AutoScroll = true;
            this.DetailTab.Controls.Add(this.detailGrid);
            this.DetailTab.Location = new System.Drawing.Point(4, 22);
            this.DetailTab.Name = "DetailTab";
            this.DetailTab.Padding = new System.Windows.Forms.Padding(3);
            this.DetailTab.Size = new System.Drawing.Size(776, 461);
            this.DetailTab.TabIndex = 1;
            this.DetailTab.Text = "人员安排信息";
            this.DetailTab.UseVisualStyleBackColor = true;
            // 
            // detailGrid
            // 
            this.detailGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.detailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DG_ID,
            this.DG_PN,
            this.DG_TP,
            this.DG_PD,
            this.DG_PJ,
            this.DG_PS,
            this.DG_XS});
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.detailGrid.Location = new System.Drawing.Point(3, 3);
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.RowTemplate.Height = 23;
            this.detailGrid.Size = new System.Drawing.Size(770, 455);
            this.detailGrid.TabIndex = 0;
            this.detailGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellValueChanged);
            this.detailGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.detailGrid_CurrentCellDirtyStateChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            // 
            // DG_ID
            // 
            this.DG_ID.HeaderText = "子项目序号";
            this.DG_ID.Name = "DG_ID";
            // 
            // DG_PN
            // 
            this.DG_PN.HeaderText = "子项目名称";
            this.DG_PN.Name = "DG_PN";
            // 
            // DG_TP
            // 
            this.DG_TP.HeaderText = "子项目类型";
            this.DG_TP.Items.AddRange(new object[] {
            "T1",
            "T2",
            "T3"});
            this.DG_TP.Name = "DG_TP";
            this.DG_TP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_TP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DG_PD
            // 
            this.DG_PD.HeaderText = "设计人";
            this.DG_PD.Name = "DG_PD";
            // 
            // DG_PJ
            // 
            this.DG_PJ.HeaderText = "校对人";
            this.DG_PJ.Name = "DG_PJ";
            // 
            // DG_PS
            // 
            this.DG_PS.HeaderText = "审核人";
            this.DG_PS.Name = "DG_PS";
            // 
            // DG_XS
            // 
            this.DG_XS.HeaderText = "难度系数";
            this.DG_XS.Name = "DG_XS";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(0, 552);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(784, 10);
            this.progressBar.TabIndex = 3;
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            // 
            // detailArrangeBindingSource
            // 
            this.detailArrangeBindingSource.DataSource = typeof(WorkFlow.DetailArrange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.TabPersonArrange);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.TopMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TopMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "和创设计-WorkFlow";
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.TabPersonArrange.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).EndInit();
            this.DetailTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailArrangeBindingSource)).EndInit();
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
        public System.Windows.Forms.TabControl TabPersonArrange;

        public System.Windows.Forms.TabPage MainTab;
        public System.Windows.Forms.TabPage DetailTab;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView MainGrid;
        public System.Windows.Forms.DataGridViewTextBoxColumn project_id;
        public System.Windows.Forms.DataGridViewTextBoxColumn project_name;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_des;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_jd;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_sh;
        public System.Windows.Forms.DataGridViewTextBoxColumn xs;
        public System.Windows.Forms.DataGridView detailGrid;
        public System.Windows.Forms.DataGridViewTextBoxColumn ID;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_ID;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_PN;
        public System.Windows.Forms.DataGridViewComboBoxColumn DG_TP;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_PD;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_PJ;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_PS;
        public System.Windows.Forms.DataGridViewTextBoxColumn DG_XS;
        public System.Windows.Forms.BindingSource detailArrangeBindingSource;
        public System.Windows.Forms.ProgressBar progressBar;
    }
}

