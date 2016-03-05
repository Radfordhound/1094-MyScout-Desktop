﻿namespace MyScout
{
    partial class GenReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.reportTypeCB = new System.Windows.Forms.ComboBox();
            this.totalScoreRB = new System.Windows.Forms.RadioButton();
            this.crossScoreRB = new System.Windows.Forms.RadioButton();
            this.autoScoreRB = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.roundNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.roundNumLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.selectTeamPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.roundNumUpDown)).BeginInit();
            this.selectTeamPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate a(n):";
            // 
            // reportTypeCB
            // 
            this.reportTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportTypeCB.FormattingEnabled = true;
            this.reportTypeCB.Items.AddRange(new object[] {
            "Event Report",
            "Round Report",
            "Prescout Report"});
            this.reportTypeCB.Location = new System.Drawing.Point(129, 9);
            this.reportTypeCB.Name = "reportTypeCB";
            this.reportTypeCB.Size = new System.Drawing.Size(126, 28);
            this.reportTypeCB.TabIndex = 1;
            this.reportTypeCB.Text = "Event Report";
            this.reportTypeCB.SelectedIndexChanged += new System.EventHandler(this.reportTypeCB_SelectedIndexChanged);
            // 
            // totalScoreRB
            // 
            this.totalScoreRB.AutoSize = true;
            this.totalScoreRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.totalScoreRB.Location = new System.Drawing.Point(76, 44);
            this.totalScoreRB.Name = "totalScoreRB";
            this.totalScoreRB.Size = new System.Drawing.Size(122, 18);
            this.totalScoreRB.TabIndex = 2;
            this.totalScoreRB.TabStop = true;
            this.totalScoreRB.Text = "Sort by Total Score";
            this.totalScoreRB.UseVisualStyleBackColor = true;
            // 
            // crossScoreRB
            // 
            this.crossScoreRB.AutoSize = true;
            this.crossScoreRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.crossScoreRB.Location = new System.Drawing.Point(76, 68);
            this.crossScoreRB.Name = "crossScoreRB";
            this.crossScoreRB.Size = new System.Drawing.Size(124, 18);
            this.crossScoreRB.TabIndex = 3;
            this.crossScoreRB.TabStop = true;
            this.crossScoreRB.Text = "Sort by Cross Score";
            this.crossScoreRB.UseVisualStyleBackColor = true;
            // 
            // autoScoreRB
            // 
            this.autoScoreRB.AutoSize = true;
            this.autoScoreRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.autoScoreRB.Location = new System.Drawing.Point(76, 91);
            this.autoScoreRB.Name = "autoScoreRB";
            this.autoScoreRB.Size = new System.Drawing.Size(120, 18);
            this.autoScoreRB.TabIndex = 4;
            this.autoScoreRB.TabStop = true;
            this.autoScoreRB.Text = "Sort by Auto Score";
            this.autoScoreRB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundNumUpDown
            // 
            this.roundNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundNumUpDown.Location = new System.Drawing.Point(76, 115);
            this.roundNumUpDown.Name = "roundNumUpDown";
            this.roundNumUpDown.Size = new System.Drawing.Size(62, 23);
            this.roundNumUpDown.TabIndex = 6;
            // 
            // roundNumLabel
            // 
            this.roundNumLabel.AutoSize = true;
            this.roundNumLabel.Location = new System.Drawing.Point(144, 119);
            this.roundNumLabel.Name = "roundNumLabel";
            this.roundNumLabel.Size = new System.Drawing.Size(49, 13);
            this.roundNumLabel.TabIndex = 7;
            this.roundNumLabel.Text = "Round #";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(0, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Select Team";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectTeamPanel
            // 
            this.selectTeamPanel.Controls.Add(this.button2);
            this.selectTeamPanel.Location = new System.Drawing.Point(76, 144);
            this.selectTeamPanel.Name = "selectTeamPanel";
            this.selectTeamPanel.Size = new System.Drawing.Size(120, 31);
            this.selectTeamPanel.TabIndex = 12;
            // 
            // GenReport
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(266, 302);
            this.Controls.Add(this.selectTeamPanel);
            this.Controls.Add(this.roundNumLabel);
            this.Controls.Add(this.roundNumUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.autoScoreRB);
            this.Controls.Add(this.crossScoreRB);
            this.Controls.Add(this.totalScoreRB);
            this.Controls.Add(this.reportTypeCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Report";
            ((System.ComponentModel.ISupportInitialize)(this.roundNumUpDown)).EndInit();
            this.selectTeamPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportTypeCB;
        private System.Windows.Forms.RadioButton totalScoreRB;
        private System.Windows.Forms.RadioButton crossScoreRB;
        private System.Windows.Forms.RadioButton autoScoreRB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown roundNumUpDown;
        private System.Windows.Forms.Label roundNumLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel selectTeamPanel;
    }
}