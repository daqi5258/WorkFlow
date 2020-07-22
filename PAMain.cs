
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    class PAMain: System.Windows.Forms.TableLayoutPanel
    {
        public RichTextBox pRTB;
        public void init(RichTextBox RTB)
        {
            pRTB = RTB;
            pAInformation = new PAInformation();
            pAInformation.Init(pRTB);
            Panel = new Panel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                //BackColor = System.Drawing.Color.Red
            };

            Button saveB = new Button()
            {
                Text = "保存",
                Location = new System.Drawing.Point(300,3),
                Dock = System.Windows.Forms.DockStyle.Right
                
            };
            saveB.Click +=  new System.EventHandler(saveB_click);

            Panel.Controls.Add(saveB);
            tab = new TabControl
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Name = "Tab",
                SelectedIndex=0
            };

            mtp = new TabPage() {
                Name = "mtp",
                Text= "项目信息",
                TabIndex = 0,
                UseVisualStyleBackColor = true
            };
            dtp = new TabPage()
            {
                Name = "dtp",
                Text = "人员安排详细",
                UseVisualStyleBackColor = true
            };
            tab.Controls.Add(mtp);
            tab.Controls.Add(dtp);
            mtp.Controls.Add(pAInformation);
            initDataGrid(dtp);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //区域分为2*1的表格区域
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(Panel, 0, 1);
            this.Controls.Add(tab, 0,0);
            this.TabIndex = 0;

            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.Size = new System.Drawing.Size(770, 460);
            
            
        }


        public void initDataGrid(TabPage parent)
        {
            DataGridView = new DataGridView();
            DataGridView.RowHeadersVisible = false;
            DataGridViewComboBoxColumn C0 = new DataGridViewComboBoxColumn()
            {
                Name = "专业",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            };
            C0.Items.Add("建筑专业");
            C0.Items.Add("结构专业");
            C0.Items.Add("水专业");
            C0.Items.Add("电专业");
            C0.Items.Add("暖通专业");

            DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn()
            {
                Name = "文件夹开头",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn C2 = new DataGridViewTextBoxColumn()
            {
                Name = "子项号",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn C3 = new DataGridViewTextBoxColumn()
            {
                Name = "子项名称",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,

            };
           
            DataGridViewTextBoxColumn C4 = new DataGridViewTextBoxColumn()
            {
                Name = "审核人",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,

            };
            DataGridViewTextBoxColumn C5 = new DataGridViewTextBoxColumn()
            {
                Name = "专负（校核）人",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,

            };
            DataGridViewTextBoxColumn C6 = new DataGridViewTextBoxColumn()
            {
                Name = "校对人",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,

            };
            DataGridViewTextBoxColumn C7 = new DataGridViewTextBoxColumn()
            {
                Name = "设计人",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,

            };
            DataGridViewComboBoxColumn C8 = new DataGridViewComboBoxColumn()
            {
                Name = "建筑类型",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };
            /*
            List<String> type = new List<string>() { "宿舍","高层-纯高层","高层-高层+","高层-超高","幼儿园"
                ,"地下室","总图-山地","总图-山势平坦","大型商业","小型商业、会所","酒店","酒店式公寓","多次办公楼","高层办公楼"
                ,"学校-教学、实验","学校-图书馆","学校-体育馆","学校-食堂、风雨操场","学校-综合楼","学校-实训楼","学校-宿舍楼","创业园","其他-停车楼、调度楼"};
            foreach (String str in type)
            {
                C8.Items.Add(str);
            }
            */
            String typePath = @"C: \Users\jdq\Desktop\HCType.xls";
            HCTypes = new List<HCType>();
            ExcelManagement em = new ExcelManagement();
            HCTypes = em.Read(typePath);
            foreach (HCType hCType in HCTypes)
            {
                C8.Items.Add(hCType.TypeName);
            }

            DataGridViewComboBoxColumn C9 = new DataGridViewComboBoxColumn()
            {
                Name = "建筑面积",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true

            };
            DataGridViewTextBoxColumn C10 = new DataGridViewTextBoxColumn()
            {
                Name = "规模系数",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                // Frozen = true
                ReadOnly = true
            };
            DataGridViewTextBoxColumn C11 = new DataGridViewTextBoxColumn()
            {
                Name = "备注",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };

            /*
            DataGridViewComboBoxColumn C2 = new  DataGridViewComboBoxColumn();
            C2.Items.Add("T1");
            C2.Items.Add("T2");
            */
            ((System.ComponentModel.ISupportInitialize)(DataGridView)).BeginInit();
            parent.SuspendLayout();

            // 
            // dataGridView1
            // 
            DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            C0,C1,C2,
            C3,C4,C5,
            C6,C7,C8,
            C9,C10,C11
            
            });
            DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            DataGridView.Location = new System.Drawing.Point(0, 0);
            DataGridView.Name = "DataGridView";
            DataGridView.RowTemplate.Height = 23;
            //DataGridView.Size = new System.Drawing.Size(800, 450);
            DataGridView.AutoSize = true;
            DataGridView.TabIndex = 0;
            DataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(DataGridView_DefaultValuesNeeded);
            DataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(DataGridView_CurrentCellDirtyStateChanged);
            DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(DataGridView_CellValueChanged);
            DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(DataGridView_DataError);
            parent.Controls.Add(DataGridView);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            parent.ResumeLayout(false);
            DataGridView.Rows[0].Cells[0].Value = "建筑专业";
            DataGridView.Sort(C1, 0);
        }


        private void DataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int index = e.Row.Index;
            if (index>0)
            {
                e.Row.Cells[0].Value = DataGridView.Rows[index - 1].Cells[0].Value;
            }

        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            pRTB.AppendText(e.ToString()+",\nr="+e.RowIndex+",c="+e.ColumnIndex+",ct="+e.Context);
        }
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var c = DataGridView.CurrentCell;
            
            if (c != null)
            {
                int rowId = c.DataGridView.CurrentCell.RowIndex;
                int colId = c.DataGridView.CurrentCell.ColumnIndex;
                
                
                if (colId==8)
                {
                    String value = c.Value.ToString();
                   // int count = 0;
                    foreach (HCType hCType in  HCTypes)
                    {
                        if (hCType.TypeName==value)
                        {
                            //Console.WriteLine("类型：" + value+",面积数："+ hCType.Detail.Count);
                            DataGridViewComboBoxCell cell = DataGridView.Rows[rowId].Cells[9] as DataGridViewComboBoxCell;
                            if(cell.Items.Count>0)
                                cell.Items.Clear();
                            if (hCType.Detail.Count==1)
                            {
                                 cell.Items.Add(hCType.Detail[0].Area);
                                 cell.Value = hCType.Detail[0].Area;
                                if( DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("建筑"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].jz;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("结构"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].jg;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("水"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].water;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("电"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].ele;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("暖通"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].nt;
                                cell.ReadOnly = true;
                            }
                            else if (hCType.Detail.Count> 1){
                                 foreach (ScoreInArea sia in hCType.Detail) {
                                    cell.Items.Add(sia.Area);
                                    //count++;
                                  }
                                cell.Value= hCType.Detail[0].Area;//Combox必须有默认值，不然报错
                                if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("建筑"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].jz;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("结构"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].jg;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("水"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].water;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("电"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].ele;
                                else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("暖通"))
                                    DataGridView.Rows[rowId].Cells[10].Value = hCType.Detail[0].nt;
                                cell.ReadOnly = false;
                            }
                            //Console.WriteLine("c="+count);
                            break;
                        }
                    }
                }
                if (colId == 9|| colId == 0)
                {
                    DataGridViewCell C8 = DataGridView.Rows[rowId].Cells[8];
                    DataGridViewCell C9 = DataGridView.Rows[rowId].Cells[9];
                    Console.WriteLine("colId="+ colId + C8.Value+","+C9.Value);
                    if (C8.Value == null)
                        return;
                    else
                        Console.WriteLine("c8="+C8.Value);
                    foreach (HCType hCType in HCTypes)
                    {
                        if (hCType.TypeName == C8.Value.ToString())
                        {
                            foreach (ScoreInArea sia in hCType.Detail)
                            {
                                if (sia.Area == C9.Value.ToString())
                                {
                                    if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("建筑"))
                                        DataGridView.Rows[rowId].Cells[10].Value = sia.jz;
                                    else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("结构"))
                                        DataGridView.Rows[rowId].Cells[10].Value = sia.jg;
                                    else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("水"))
                                        DataGridView.Rows[rowId].Cells[10].Value = sia.water;
                                    else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("电"))
                                        DataGridView.Rows[rowId].Cells[10].Value = sia.ele;
                                    else if (DataGridView.Rows[rowId].Cells[0].Value.ToString().Contains("暖通"))
                                        DataGridView.Rows[rowId].Cells[10].Value = sia.nt;
                                    break;
                                }
                            }

                        }
                    }

                }
               
            }

        }
        private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DataGridView.IsCurrentCellDirty)
            {
                if(DataGridView.CurrentCell.ColumnIndex ==9 || DataGridView.CurrentCell.ColumnIndex == 8 || DataGridView.CurrentCell.ColumnIndex == 0)
                DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Console.WriteLine("执行！"+DateTime.Now);
            }
        }


        private void saveB_click(object sender, EventArgs e)
        {
            try
            {
                ExcelManagement em = new ExcelManagement();
                List<String[]> pList = pAInformation.GetValue();
                String path = @"\\Hcdata\和创施工图设计平台\" + pAInformation.filePath + "\\项师-工作目录\\ISO\\ISO表格";
                String fileName = em.Write(path, pList, pAInformation.DataGridView, DataGridView);
                if (fileName.IndexOf("ERROR") > -1)
                    pRTB.Text="\n保存失败，请联系程序员，错误信息：" + fileName;
                else
                    pRTB.Text="\n保存成功，文件：" + fileName;
            }
            catch (Exception e1)
            {
                pRTB.Text="\n操作失败，错误信息：" + e1.ToString();
            }
        }
        public Panel Panel;
        public TabControl tab;
        public TabPage mtp;
        public TabPage dtp;
        public DataGridView DataGridView;
        public List<HCType> HCTypes;
        public PAInformation pAInformation;
    }
}