using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WorkFlow
{
    class FolderPanel : TableLayoutPanel
    {
        public RichTextBox RTB;
        public String flag;
        public ProgressBar ProgressBar;
        public String exportPath;
        /// <summary>
        /// 项目选择界面初始化
        /// </summary>
        /// <param name="RTB">主界面消息栏</param>
        /// <param name="Flag">功能选择标注</param>
        /// <param name="exportPath">导出文件路径</param>
        /// <param name="ProgressBar">进度条</param>
        public void init(RichTextBox RTB, String Flag, String exportPath, ProgressBar ProgressBar)
        {
            this.RTB = RTB;
            this.flag = Flag;
            this.ProgressBar = ProgressBar;
            this.exportPath = exportPath;
            Panel = new TableLayoutPanel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            Panel.ColumnCount = 3;
            Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel.RowCount = 1;
            Button saveA = new Button()
            {
                Text = "选择项目",
                Location = new System.Drawing.Point(220, 3),
                Dock = System.Windows.Forms.DockStyle.Right
            };
            saveA.Click += new System.EventHandler(saveA_click);
            Button saveB = new Button()
            {
                Text = "检索",
                Location = new System.Drawing.Point(300, 3),
                Dock = System.Windows.Forms.DockStyle.Left
            };
            saveB.Click += new System.EventHandler(saveB_click);
            Button saveC = new Button()
            {
                Text = "清空",
                Location = new System.Drawing.Point(300, 3),
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            saveC.Click += new System.EventHandler(saveC_click);
            Panel.Controls.Add(saveA, 0, 0);
            Panel.Controls.Add(saveB, 2, 0);
            Panel.Controls.Add(saveC, 1, 0);

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //区域分为2*1的表格区域
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(Panel, 0, 0);
            initDataGrid();
            this.Controls.Add(DataGridView, 0, 1);
            this.TabIndex = 0;

            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.Size = new System.Drawing.Size(770, 460);


        }


        public void initDataGrid()
        {
            DataGridView = new DataGridView();

            DataGridViewTextBoxColumn C0 = new DataGridViewTextBoxColumn()
            {
                Name = "选择的项目",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                Width = 200

            };
            DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn()
            {
                Name = "项目路径",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
            };

            DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { C0, C1 });
            DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            DataGridView.Location = new System.Drawing.Point(0, 0);
            DataGridView.Name = "DataGridView";
            DataGridView.RowTemplate.Height = 23;
            DataGridView.AutoSize = true;
            DataGridView.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            DataGridView.Columns[1].ToolTipText = "路径到项目文件夹即可";
        }

        private void saveA_click(object sender, EventArgs e)
        {
            String path = @"\\Hcdata\和创施工图设计平台";
            String fdPath = SelectFoldPath(path);
            Console.WriteLine(fdPath);
            if (fdPath.LastIndexOf("\\") > 23)
            {
                if (DataGridView.RowCount > 1)
                {
                    foreach (DataGridViewRow erow in DataGridView.Rows)
                    {
                        if (erow.Cells[0] != null && erow.Cells[0].Value != null && erow.Cells[0].Value.ToString() == fdPath.Substring(fdPath.LastIndexOf("\\") + 1))
                        {
                            return;
                        }
                    }
                }
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = fdPath.Substring(fdPath.LastIndexOf("\\") + 1);
                row.Cells.Add(cell);
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = fdPath;
                row.Cells.Add(cell2);
                DataGridView.Rows.Add(row);
            }
            if (fdPath.LastIndexOf("\\") == 23)
            {
                String[] folders = Directory.GetDirectories(fdPath, "*", SearchOption.TopDirectoryOnly);
                foreach (String folder in folders)
                {
                    Boolean flag = true;
                    if (DataGridView.RowCount > 1)
                    {
                        foreach (DataGridViewRow erow in DataGridView.Rows)
                        {
                            if (erow.Cells[0] != null && erow.Cells[0].Value != null && erow.Cells[0].Value.ToString() == folder.Substring(folder.LastIndexOf("\\") + 1))
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        cell.Value = folder.Substring(folder.LastIndexOf("\\") + 1);
                        row.Cells.Add(cell);
                        DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                        cell2.Value = folder;
                        row.Cells.Add(cell2);
                        DataGridView.Rows.Add(row);
                    }
                }
            }
        }
        private void saveB_click(object sender, EventArgs e)
        {
            if (DataGridView.RowCount<2)
            {
                RTB.Text = "请先选择项目";
                return;
            }
            RTB.Text = "检索开始，请等待结果";
            GetScore getScore = new GetScore();
            List<string> folders = new List<string>();
            int item = 0;
            ProgressBar.Value = 5;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    folders.Add(row.Cells[1].Value.ToString());
                    item++;
                }
            }
            ProgressBar.Value = 20;
            int c = 0;
            String unFolder ="";
             
            Thread mythread = new Thread(x => GetScore.Check(folders, exportPath, flag, ref c,ref unFolder)) { IsBackground = true };
            mythread.Start();
            mythread.Join();
            ProgressBar.Value = 100;
            if (c==item)
                RTB.AppendText("\n检索完成，总共导出"+c+"个项目，路径： "+exportPath);
            else

                RTB.AppendText("\n检索完成，总共导出" + c + "个项目，路径： " + exportPath+"\n未导出项目如下：\t"+unFolder);
        }

        private void saveC_click(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
        }

        /// <summary>
        /// 获取项目文件路径
        /// </summary>
        /// <returns>大项目的顶层文件夹路径</returns>
        public String SelectFoldPath(String selectedPath)
        {
            String path = null;
            FolderBrowserForm dialog = new FolderBrowserForm();
            dialog.DirectoryPath = selectedPath;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                path = dialog.DirectoryPath;
            }
            else
                path = selectedPath;
            return path;
        }
        public TableLayoutPanel Panel;
        public DataGridView DataGridView;






    }
}
