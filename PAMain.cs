
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    class PAMain: System.Windows.Forms.TableLayoutPanel
    {
        public void init()
        {
            PAInformation pAInformation = new PAInformation();
            pAInformation.Init();
            Panel = new Panel()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.Red
            };


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
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //区域分为2*1的表格区域
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(Panel, 0, 0);
            this.Controls.Add(tab, 0,1);
            this.TabIndex = 0;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.Size = new System.Drawing.Size(770, 460);
        }



        public Panel Panel;
        public TabControl tab;
        public TabPage mtp;
        public TabPage dtp;
    }
}