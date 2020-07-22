using NPOI.SS.Formula.Functions;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Crypto.Paddings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WorkFlow
{
    public class PAInformation : TableLayoutPanel
    {
        public void Init(RichTextBox rtb)
        {
            try
            {
                //初始化P0
                P0 = new TableLayoutPanel();
                P0.Dock = System.Windows.Forms.DockStyle.Fill;
                P0.Location = new System.Drawing.Point(3, 3);
                P0.Size = new System.Drawing.Size(764, 275);
                //P0.BackColor = System.Drawing.Color.FromArgb(100,120,40);
                P0.ColumnCount = 4;
                P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                P0.RowCount = 12;

                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
                P0.TabIndex = 0;

                P1 = new Panel();
                P1.Dock = System.Windows.Forms.DockStyle.Fill;
                P1.Location = new System.Drawing.Point(3, 3);
                P1.BackColor = System.Drawing.Color.FromArgb(0, 100, 0);
                P1.Size = new System.Drawing.Size(500, 240);
                P1.TabIndex = 1;
                initDataGrid(P1);

                Label tl = new Label();
                tl.Name = "test";
                tl.Dock = System.Windows.Forms.DockStyle.Fill;
                tl.Location = new System.Drawing.Point(3, 3);
                tl.Text = "test";
                P1.Controls.Add(tl);


                labels = new List<Label>();
                for (int i = 0; i < 14; i++)
                {
                    Label label = new Label();
                    label.Name = "paL" + i;
                    label.SetBounds(0, 0, 0, 0);
                    label.Dock = System.Windows.Forms.DockStyle.Fill;
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.Location = new System.Drawing.Point(3, 3);
                    label.Margin = new System.Windows.Forms.Padding(0);
                    labels.Add(label);
                    label.TabIndex = i;
                    if (i == 0)
                        P0.Controls.Add(label, 0, 0);
                    else if (i == 1)
                        P0.Controls.Add(label, 2, 0);
                    else if (i > 1 && i < 6)
                        P0.Controls.Add(label, 0, i - 1);
                    else if (i == 6)
                        P0.Controls.Add(label, 2, i - 2);
                    else if (i == 7)
                        P0.Controls.Add(label, 1, i - 2);
                    else if (i == 8)
                        P0.Controls.Add(label, 2, i - 3);
                    else if (i > 8)
                        P0.Controls.Add(label, 0, i - 3);
                }

                textBoxs = new List<TextBox>();
                for (int i = 1; i < 16; i++)
                {
                    TextBox tb = new TextBox();

                    tb.Name = "paTB" + i;
                    tb.Dock = System.Windows.Forms.DockStyle.Fill;
                    tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    //tb.Text = "tb="+i;
                    tb.Margin = new System.Windows.Forms.Padding(0);
                    if (i < 4)
                    {
                        P0.Controls.Add(tb, 1, i);
                        tb.TextAlign = HorizontalAlignment.Center;
                        P0.SetColumnSpan(tb, 3);
                    }
                    else if (i == 4)
                    {
                        P0.Controls.Add(tb, 1, 4);
                    }
                    else if (i == 5)
                    {
                        P0.Controls.Add(tb, 3, 4);
                    }
                    else if (i > 5 && i < 11)
                    {
                        P0.Controls.Add(tb, 1, i);
                    }
                    else if (i >= 11)
                    {
                        P0.Controls.Add(tb, 2, i - 5);
                    }
                }

                ComboBox cb1 = new ComboBox();
                cb1.Name = "Dept";
                cb1.Dock = System.Windows.Forms.DockStyle.Fill;
                cb1.Items.Add("居住一所");
                cb1.Items.Add("居住二所");
                cb1.Items.Add("公建一所");
                cb1.Items.Add("公建二所");
                cb1.SelectedIndex = 0;
                cb1.Margin = new System.Windows.Forms.Padding(0);
                P0.Controls.Add(cb1, 1, 0);
                ComboBox cb2 = new ComboBox();
                cb2.Name = "Year";
                cb2.Dock = System.Windows.Forms.DockStyle.Fill;
                cb2.Items.Add("2018");
                cb2.Items.Add("2019");
                cb2.Items.Add("2020");
                cb2.Items.Add("2021");
                cb2.Items.Add("2022");
                cb2.Items.Add("2023");
                cb2.Items.Add("2024");
                cb2.Items.Add("2025");
                cb2.Items.Add("2026");
                cb2.Items.Add("2027");
                cb2.SelectedIndex = 2;
                cb2.Margin = new System.Windows.Forms.Padding(0);
                P0.Controls.Add(cb2, 3, 0);
                P0.GetControlFromPosition(0, 0).Text = "项目部门";
                P0.GetControlFromPosition(2, 0).Text = "项目年份";
                P0.GetControlFromPosition(0, 1).Text = "合同号（项目编号）";
                P0.GetControlFromPosition(0, 2).Text = "业主名称";
                P0.GetControlFromPosition(0, 3).Text = "项目名称";
                P0.GetControlFromPosition(0, 4).Text = "项目负责人";
                P0.GetControlFromPosition(2, 4).Text = "项目秘书";
                P0.GetControlFromPosition(1, 5).Text = "专业负责人（校核人）";
                P0.GetControlFromPosition(2, 5).Text = "注册师";
                P0.GetControlFromPosition(0, 6).Text = "建筑";
                P0.GetControlFromPosition(0, 7).Text = "结构";
                P0.GetControlFromPosition(0, 8).Text = "水";
                P0.GetControlFromPosition(0, 9).Text = "电";
                P0.GetControlFromPosition(0, 10).Text = "暖通";
                P0.GetControlFromPosition(1, 1).Text = "20100";
                P0.GetControlFromPosition(1, 3).Text = "总工办测试项目";
                /*
                for(int i =0;i<11;i++){
                    for (int j=0;j<4; j++)
                    {
                        TextBox tb = new TextBox();

                        tb.Name = "paTB" + i;
                        tb.Text = i+","+j;
                        tb.Dock = System.Windows.Forms.DockStyle.Fill;
                        tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        tb.Margin = new System.Windows.Forms.Padding(0);
                        P0.Controls.Add(tb);
                    }
                }
                */


                this.Dock = System.Windows.Forms.DockStyle.Fill;
                //区域分为2*1的表格区域
                this.ColumnCount = 1;
                this.RowCount = 2;
                this.Location = new System.Drawing.Point(3, 3);
                this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.Controls.Add(P0, 0, 0);
                this.Controls.Add(P1, 1, 0);
                this.TabIndex = 0;
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56F));
                this.Size = new System.Drawing.Size(770, 480);
            }
            catch (Exception e)
            {
                rtb.Text="初始化失败！原因："+e.ToString();
            }
        }


        public void initDataGrid(Panel parent)
        {
            DataGridView = new DataGridView(); 
            ((System.ComponentModel.ISupportInitialize)(DataGridView)).BeginInit();
            parent.SuspendLayout();
            DataGridView.RowHeadersVisible = false;
            DataGridViewTextBoxColumn C1 = new DataGridViewTextBoxColumn()
            {
                Name = "出图子项号",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn C2 = new DataGridViewTextBoxColumn()
            {
                Name = "出图子项名称",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewComboBoxColumn C3 = new DataGridViewComboBoxColumn()
            {
                Name = "建筑类型",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                
            };
            C3.Items.Add("T1");
            C3.Items.Add("S1");

            DataGridViewTextBoxColumn C4 = new DataGridViewTextBoxColumn()
            {
                Name = "建筑面积区间段",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            };

            /*
            DataGridViewComboBoxColumn C2 = new  DataGridViewComboBoxColumn();
            C2.Items.Add("T1");
            C2.Items.Add("T2");
            */
            
            
            // 
            // dataGridView1
            // 
            DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            C1,
            C2,
            C3,
            C4});
            DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            DataGridView.Location = new System.Drawing.Point(0, 0);
            DataGridView.Name = "DataGridView";
            DataGridView.RowTemplate.Height = 23;
            //DataGridView.Size = new System.Drawing.Size(800, 450);
            DataGridView.AutoSize = true;
            DataGridView.TabIndex = 0;
           
            parent.Controls.Add(DataGridView);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            parent.ResumeLayout(false);
        }


        public List<String[]> GetValue()
        {
            List<String[]> list = new List<string[]>();
            for (int i=0;i<P0.RowCount;i++)
            {
                String[] str= new string[4];
                for (int j=0;j<4;j++)
                {/*
                    if (i > 0 && i < 4 && j > 1)
                        str[j] = null;
                    else
                    {*/
                        if (P0.GetControlFromPosition(j, i) != null)
                            str[j] = P0.GetControlFromPosition(j, i).Text.Trim();
                        else
                            str[j] = null;
                    //}
                }
                list.Add(str);
            }
            filePath= P0.GetControlFromPosition(1, 0).Text+"\\"+ P0.GetControlFromPosition(3, 0).Text + "\\" + P0.GetControlFromPosition(1, 1).Text+" " + P0.GetControlFromPosition(1, 3).Text;
            return list;
        }
        public List<Label> labels;
        public List<TextBox> textBoxs;
        public TableLayoutPanel P0;
        public Panel P1;
        public DataGridView DataGridView;
        public String filePath;


    }
}
