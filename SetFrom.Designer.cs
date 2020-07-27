using NPOI.SS.Formula.Functions;
using System;

namespace WorkFlow
{
    partial class SetFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetFrom));
            this.FileExportLabel = new System.Windows.Forms.Label();
            this.FileExportPath = new System.Windows.Forms.Label();
            this.ButtonST = new System.Windows.Forms.Button();
            this.ButtonCM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileExportLabel
            // 
            this.FileExportLabel.Location = new System.Drawing.Point(0, 0);
            this.FileExportLabel.Name = "FileExportLabel";
            this.FileExportLabel.Size = new System.Drawing.Size(120, 40);
            this.FileExportLabel.TabIndex = 0;
            this.FileExportLabel.Text =  "当前文件路径为：";
            this.FileExportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileExportPath
            // 
            this.FileExportPath.Location = new System.Drawing.Point(120, 0);
            this.FileExportPath.Name = "FileExportPath";
            this.FileExportPath.Size = new System.Drawing.Size(520, 40);
            this.FileExportPath.TabIndex = 1;
            this.FileExportPath.Text =""+fileExportPath;
            this.FileExportPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonST
            // 
            this.ButtonST.Location = new System.Drawing.Point(645, 0);
            this.ButtonST.Name = "ButtonST";
            this.ButtonST.Size = new System.Drawing.Size(75, 40);
            this.ButtonST.TabIndex = 2;
            this.ButtonST.Text = "选择路径";
            this.ButtonST.UseVisualStyleBackColor = true;
            this.ButtonST.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonST_MouseClick);
            // 
            // ButtonCM
            // 
            this.ButtonCM.Location = new System.Drawing.Point(722, 0);
            this.ButtonCM.Name = "ButtonCM";
            this.ButtonCM.Size = new System.Drawing.Size(75, 40);
            this.ButtonCM.TabIndex = 3;
            this.ButtonCM.Text = "确定";
            this.ButtonCM.UseVisualStyleBackColor = true;
            this.ButtonCM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonCM_MouseClick);
            // 
            // SetFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 39);
            this.Controls.Add(this.ButtonCM);
            this.Controls.Add(this.ButtonST);
            this.Controls.Add(this.FileExportPath);
            this.Controls.Add(this.FileExportLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(812, 77);
            this.MinimumSize = new System.Drawing.Size(812, 77);
            this.Name = "SetFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = formName; 
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label FileExportLabel;
        public System.Windows.Forms.Label FileExportPath;
        public System.Windows.Forms.Button ButtonST;
        public System.Windows.Forms.Button ButtonCM;
    }
}