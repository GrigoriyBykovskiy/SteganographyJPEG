using System.ComponentModel;

namespace SteganographyJPEG
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.groupBoxStatisticalCharacteristics = new System.Windows.Forms.GroupBox();
            this.buttonСalculate = new System.Windows.Forms.Button();
            this.textBoxMaxDifference = new System.Windows.Forms.TextBox();
            this.labelMaxDifferenceName = new System.Windows.Forms.Label();
            this.groupBoxStatisticalCharacteristics.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStatisticalCharacteristics
            // 
            this.groupBoxStatisticalCharacteristics.Controls.Add(this.buttonСalculate);
            this.groupBoxStatisticalCharacteristics.Controls.Add(this.textBoxMaxDifference);
            this.groupBoxStatisticalCharacteristics.Controls.Add(this.labelMaxDifferenceName);
            this.groupBoxStatisticalCharacteristics.Location = new System.Drawing.Point(10, 10);
            this.groupBoxStatisticalCharacteristics.Name = "groupBoxStatisticalCharacteristics";
            this.groupBoxStatisticalCharacteristics.Size = new System.Drawing.Size(560, 530);
            this.groupBoxStatisticalCharacteristics.TabIndex = 0;
            this.groupBoxStatisticalCharacteristics.TabStop = false;
            this.groupBoxStatisticalCharacteristics.Text = "Статистические характеристики";
            // 
            // buttonСalculate
            // 
            this.buttonСalculate.Location = new System.Drawing.Point(10, 484);
            this.buttonСalculate.Name = "buttonСalculate";
            this.buttonСalculate.Size = new System.Drawing.Size(150, 40);
            this.buttonСalculate.TabIndex = 2;
            this.buttonСalculate.Text = "рассчитать";
            this.buttonСalculate.UseVisualStyleBackColor = true;
            this.buttonСalculate.Click += new System.EventHandler(this.buttonСalculate_Click);
            // 
            // textBoxMaxDifference
            // 
            this.textBoxMaxDifference.Location = new System.Drawing.Point(10, 50);
            this.textBoxMaxDifference.Name = "textBoxMaxDifference";
            this.textBoxMaxDifference.Size = new System.Drawing.Size(400, 22);
            this.textBoxMaxDifference.TabIndex = 1;
            // 
            // labelMaxDifferenceName
            // 
            this.labelMaxDifferenceName.Location = new System.Drawing.Point(10, 20);
            this.labelMaxDifferenceName.Name = "labelMaxDifferenceName";
            this.labelMaxDifferenceName.Size = new System.Drawing.Size(500, 30);
            this.labelMaxDifferenceName.TabIndex = 0;
            this.labelMaxDifferenceName.Text = "Максимальная разность:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.groupBoxStatisticalCharacteristics);
            this.Name = "Form2";
            this.Text = "SteganographyJPEGStatParams";
            this.groupBoxStatisticalCharacteristics.ResumeLayout(false);
            this.groupBoxStatisticalCharacteristics.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonСalculate;
        private System.Windows.Forms.TextBox textBoxMaxDifference;

        private System.Windows.Forms.Label labelMaxDifferenceName;

        private System.Windows.Forms.GroupBox groupBoxStatisticalCharacteristics;

        #endregion
    }
}