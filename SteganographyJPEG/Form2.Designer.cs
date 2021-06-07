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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxStatisticalCharacteristics = new System.Windows.Forms.GroupBox();
            this.chartPSNRfromP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelPSNRfromPName = new System.Windows.Forms.Label();
            this.buttonСalculate = new System.Windows.Forms.Button();
            this.textBoxMaxDifference = new System.Windows.Forms.TextBox();
            this.labelMaxDifferenceName = new System.Windows.Forms.Label();
            this.groupBoxStatisticalCharacteristics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.chartPSNRfromP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStatisticalCharacteristics
            // 
            this.groupBoxStatisticalCharacteristics.Controls.Add(this.chartPSNRfromP);
            this.groupBoxStatisticalCharacteristics.Controls.Add(this.labelPSNRfromPName);
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
            // chartPSNRfromP
            // 
            chartArea1.AxisX.Title = "P";
            chartArea1.AxisY.Title = "PSNR";
            chartArea1.Name = "ChartArea1";
            this.chartPSNRfromP.ChartAreas.Add(chartArea1);
            this.chartPSNRfromP.Location = new System.Drawing.Point(10, 118);
            this.chartPSNRfromP.Name = "chartPSNRfromP";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.EmptyPointStyle.AxisLabel = "F";
            series1.Name = "Series1";
            this.chartPSNRfromP.Series.Add(series1);
            this.chartPSNRfromP.Size = new System.Drawing.Size(544, 360);
            this.chartPSNRfromP.TabIndex = 4;
            this.chartPSNRfromP.Text = "chartPSNRfromP";
            // 
            // labelPSNRfromPName
            // 
            this.labelPSNRfromPName.Location = new System.Drawing.Point(10, 85);
            this.labelPSNRfromPName.Name = "labelPSNRfromPName";
            this.labelPSNRfromPName.Size = new System.Drawing.Size(500, 30);
            this.labelPSNRfromPName.TabIndex = 3;
            this.labelPSNRfromPName.Text = "Графики зависимости PSNR от P:";
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
            this.ClientSize = new System.Drawing.Size(594, 565);
            this.Controls.Add(this.groupBoxStatisticalCharacteristics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteganographyJPEGStatParams";
            this.groupBoxStatisticalCharacteristics.ResumeLayout(false);
            this.groupBoxStatisticalCharacteristics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.chartPSNRfromP)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelPSNRfromPName;
        
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPSNRfromP;

        private System.Windows.Forms.Button buttonСalculate;
        private System.Windows.Forms.TextBox textBoxMaxDifference;

        private System.Windows.Forms.Label labelMaxDifferenceName;

        private System.Windows.Forms.GroupBox groupBoxStatisticalCharacteristics;

        #endregion
    }
}