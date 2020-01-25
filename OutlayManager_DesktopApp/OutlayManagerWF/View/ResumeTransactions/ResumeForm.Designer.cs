namespace OutlayManagerWF.View.ResumeTransactions
{
    partial class ResumeForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartSpending = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpending)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSpending
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSpending.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpending.Legends.Add(legend1);
            this.chartSpending.Location = new System.Drawing.Point(12, 52);
            this.chartSpending.Name = "chartSpending";
            this.chartSpending.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Spending";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Incoming";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Saved";
            this.chartSpending.Series.Add(series1);
            this.chartSpending.Series.Add(series2);
            this.chartSpending.Series.Add(series3);
            this.chartSpending.Size = new System.Drawing.Size(1372, 300);
            this.chartSpending.TabIndex = 0;
            this.chartSpending.Text = "chart1";
            title1.Name = "Titulo";
            this.chartSpending.Titles.Add(title1);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(585, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(419, 34);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "SPENDING BITACORA";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 751);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chartSpending);
            this.Name = "ResumeForm";
            this.Text = "ResumeForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartSpending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpending;
        private System.Windows.Forms.TextBox textBox1;
    }
}