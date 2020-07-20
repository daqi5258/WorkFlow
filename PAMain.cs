
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    class PAMain: System.Windows.Forms.Panel
    {

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
            this.Size = new System.Drawing.Size(770, 455);


    }
}