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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MainLabel1 = new System.Windows.Forms.Label();
            this.MainLabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.DetailPanel = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.TopMenu.SuspendLayout();
            this.TabPersonArrange.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.MessageText.Location = new System.Drawing.Point(0, 639);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(801, 50);
            this.MessageText.TabIndex = 1;
            this.MessageText.Text = "";
            // 
            // TabPersonArrange
            // 
            this.TabPersonArrange.Controls.Add(this.MainTab);
            this.TabPersonArrange.Controls.Add(this.DetailPanel);
            this.TabPersonArrange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPersonArrange.Location = new System.Drawing.Point(0, 25);
            this.TabPersonArrange.Name = "TabPersonArrange";
            this.TabPersonArrange.SelectedIndex = 0;
            this.TabPersonArrange.Size = new System.Drawing.Size(801, 614);
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
            this.MainTab.Size = new System.Drawing.Size(793, 588);
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.21978F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.78022F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 582);
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
            this.MainGrid.Location = new System.Drawing.Point(3, 237);
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
            this.MainGrid.Size = new System.Drawing.Size(781, 342);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.MainLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.MainLabel2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox6, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox7, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox8, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox9, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBox10, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox11, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox12, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBox13, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBox14, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBox15, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox16, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox17, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(781, 228);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // MainLabel1
            // 
            this.MainLabel1.AutoSize = true;
            this.MainLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLabel1.Location = new System.Drawing.Point(0, 0);
            this.MainLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.MainLabel1.Name = "MainLabel1";
            this.MainLabel1.Size = new System.Drawing.Size(195, 21);
            this.MainLabel1.TabIndex = 0;
            this.MainLabel1.Text = "部门";
            this.MainLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainLabel2
            // 
            this.MainLabel2.AutoSize = true;
            this.MainLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLabel2.Location = new System.Drawing.Point(390, 0);
            this.MainLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.MainLabel2.Name = "MainLabel2";
            this.MainLabel2.Size = new System.Drawing.Size(195, 21);
            this.MainLabel2.TabIndex = 1;
            this.MainLabel2.Text = "年份";
            this.MainLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "合同号（项目编号）";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "业主名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "项目名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "项目负责人";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "暖通";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "电";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "建筑";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "结构";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "水";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(198, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 21);
            this.label10.TabIndex = 11;
            this.label10.Text = "专业负责人（校对人）";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(393, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 21);
            this.label11.TabIndex = 12;
            this.label11.Text = "注册师";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(195, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 21);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox2, 3);
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(195, 21);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(586, 21);
            this.textBox2.TabIndex = 15;
            // 
            // textBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox3, 3);
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(195, 42);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(586, 21);
            this.textBox3.TabIndex = 16;
            // 
            // textBox4
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox4, 3);
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(198, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(580, 21);
            this.textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Location = new System.Drawing.Point(198, 87);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(189, 21);
            this.textBox5.TabIndex = 18;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(198, 129);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(189, 21);
            this.textBox6.TabIndex = 19;

            PAInformation paIf = new PAInformation();
            paIf.Init();
            this.DetailPanel.Controls.Add(paIf);
            
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(198, 150);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(189, 21);
            this.textBox7.TabIndex = 20;
            // 
            // textBox8
            // 
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox8.Location = new System.Drawing.Point(393, 129);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(189, 21);
            this.textBox8.TabIndex = 21;
            // 
            // textBox9
            // 
            this.textBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox9.Location = new System.Drawing.Point(393, 150);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(189, 21);
            this.textBox9.TabIndex = 22;
            // 
            // textBox10
            // 
            this.textBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox10.Location = new System.Drawing.Point(393, 171);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(189, 21);
            this.textBox10.TabIndex = 23;
            // 
            // textBox11
            // 
            this.textBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox11.Location = new System.Drawing.Point(393, 192);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(189, 21);
            this.textBox11.TabIndex = 24;
            // 
            // textBox12
            // 
            this.textBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox12.Location = new System.Drawing.Point(393, 213);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(189, 21);
            this.textBox12.TabIndex = 25;
            // 
            // textBox13
            // 
            this.textBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox13.Location = new System.Drawing.Point(198, 171);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(189, 21);
            this.textBox13.TabIndex = 26;
            // 
            // textBox14
            // 
            this.textBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox14.Location = new System.Drawing.Point(198, 192);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(189, 21);
            this.textBox14.TabIndex = 27;
            // 
            // textBox15
            // 
            this.textBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox15.Location = new System.Drawing.Point(198, 213);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(189, 15);
            this.textBox15.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(393, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 21);
            this.label12.TabIndex = 29;
            this.label12.Text = "项目秘书";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox16
            // 
            this.textBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox16.Location = new System.Drawing.Point(588, 87);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(190, 21);
            this.textBox16.TabIndex = 30;
            // 
            // textBox17
            // 
            this.textBox17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox17.Location = new System.Drawing.Point(588, 3);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(190, 21);
            this.textBox17.TabIndex = 31;
            // 
            // DetailPanel
            // 
            this.DetailPanel.Location = new System.Drawing.Point(4, 22);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Padding = new System.Windows.Forms.Padding(3);
            this.DetailPanel.Size = new System.Drawing.Size(793, 588);
            this.DetailPanel.TabIndex = 1;
            this.DetailPanel.Text = "人员安排信息";
            this.DetailPanel.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(0, 629);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(801, 10);
            this.progressBar.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(801, 689);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView MainGrid;
        public System.Windows.Forms.DataGridViewTextBoxColumn project_id;
        public System.Windows.Forms.DataGridViewTextBoxColumn project_name;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_des;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_jd;
        public System.Windows.Forms.DataGridViewTextBoxColumn person_sh;
        public System.Windows.Forms.DataGridViewTextBoxColumn xs;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label MainLabel1;
        private System.Windows.Forms.Label MainLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage DetailPanel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
    }
}

