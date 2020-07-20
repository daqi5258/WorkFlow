using NPOI.SS.Formula.Functions;
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
        public void Init()
        {
            Console.WriteLine("init");
            //初始化P0
            P0 = new TableLayoutPanel();
            P0.Dock = System.Windows.Forms.DockStyle.Fill;
            P0.Location = new System.Drawing.Point(3, 3);
            P0.Size = new System.Drawing.Size(764, 176);
            //P0.BackColor = System.Drawing.Color.FromArgb(100,120,40);
            P0.ColumnCount = 4;
            P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            P0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            P0.RowCount = 13;
            /*
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            */

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
            P0.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            P0.TabIndex = 0;
            P1 = new Panel();
            P1.Dock = System.Windows.Forms.DockStyle.Fill;
            P1.Location = new System.Drawing.Point(3, 3);
           // P1.BackColor = System.Drawing.Color.FromArgb(0, 100, 0);
            P1.Size =new System.Drawing.Size(500,240);
            P1.TabIndex = 1;

            Label tl = new Label();
            tl.Name = "test";
            tl.Dock = System.Windows.Forms.DockStyle.Fill;
            tl.Location = new System.Drawing.Point(3, 3);
            tl.Text = "test";
            P1.Controls.Add(tl);


            labels = new List<Label>();
            for (int i = 0; i < 12; i++)
            {
                Label label = new Label();
                label.Name = "paL" + i;
                label.SetBounds(0,0,0,0);
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label.Location = new System.Drawing.Point(3, 3);
                label.Margin = new System.Windows.Forms.Padding(0);
                labels.Add(label);
                label.TabIndex = i;
                if(i==4)
                    P0.Controls.Add(label, 1, i);
                else if(i == 10)
                    P0.Controls.Add(label,2,3);
                else if(i==11)
                    P0.Controls.Add(label, 2, 4);
                else if (i <= 9)
                    P0.Controls.Add(label, 0, i);
            }


            P0.GetControlFromPosition(0, 0).Text = "合同号（项目编号）";
            P0.GetControlFromPosition(0, 1).Text = "业主名称";
            P0.GetControlFromPosition(0, 2).Text = "项目名称";
            P0.GetControlFromPosition(0, 3).Text = "项目负责人";
            P0.GetControlFromPosition(2, 3).Text = "项目秘书";
            P0.GetControlFromPosition(1, 4).Text = "专业负责人（校核人）";
            P0.GetControlFromPosition(2, 4).Text = "注册师";
            P0.GetControlFromPosition(0, 5).Text = "建筑";
            P0.GetControlFromPosition(0, 6).Text = "结构";
            P0.GetControlFromPosition(0, 7).Text = "水";
            P0.GetControlFromPosition(0, 8).Text = "电";
            P0.GetControlFromPosition(0, 9).Text = "暖通";

            textBoxs = new List<TextBox>();
            for (int i=0;i<15;i++)
            {
                TextBox tb = new TextBox();
                
                tb.Name = "paTB" + i;
                tb.Dock = System.Windows.Forms.DockStyle.Fill;
                tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tb.Text = "tb="+i;
                tb.Margin = new System.Windows.Forms.Padding(0);
                if (i<3)
                {
                    P0.Controls.Add(tb, 1, i);
                    P0.SetColumnSpan(tb,3);
                }else if (i==3 )
                {
                    P0.Controls.Add(tb, 1, 3);
                }
                else if (i == 4)
                {
                    P0.Controls.Add(tb, 3, 3);
                }else if (i>4 && i<10)
                {
                    P0.Controls.Add(tb, 1, i);
                }else if (i>=10)
                {
                    P0.Controls.Add(tb, 2, i-5);
                }
            }

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //区域分为2*1的表格区域
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(P0,0,0);
            this.Controls.Add(P1,1,0);
            this.TabIndex = 0;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.Size = new System.Drawing.Size(770, 480);
        }

        public List<Label> labels;
        public List<TextBox> textBoxs;
        public TableLayoutPanel P0;
        public Panel P1;


    }
}
