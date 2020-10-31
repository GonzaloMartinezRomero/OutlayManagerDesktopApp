namespace OutlayManagerWF.View.ResumeTransactions
{
    partial class ResumeSavingsForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.savingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonCalculateSaving = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonCalculateSaving);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimeTo);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimeFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.savingChart);
            this.splitContainer1.Size = new System.Drawing.Size(1255, 520);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // savingChart
            // 
            chartArea1.Name = "ChartArea1";
            this.savingChart.ChartAreas.Add(chartArea1);
            this.savingChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.savingChart.Legends.Add(legend1);
            this.savingChart.Location = new System.Drawing.Point(0, 0);
            this.savingChart.Name = "savingChart";
            this.savingChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.savingChart.Series.Add(series1);
            this.savingChart.Size = new System.Drawing.Size(1255, 447);
            this.savingChart.TabIndex = 0;
            this.savingChart.Text = "chart1";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFrom.Location = new System.Drawing.Point(12, 36);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(168, 22);
            this.dateTimeFrom.TabIndex = 0;
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTo.Location = new System.Drawing.Point(203, 35);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(168, 22);
            this.dateTimeTo.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "From Date";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(203, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(168, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "To Date";
            // 
            // buttonCalculateSaving
            // 
            this.buttonCalculateSaving.Location = new System.Drawing.Point(413, 7);
            this.buttonCalculateSaving.Name = "buttonCalculateSaving";
            this.buttonCalculateSaving.Size = new System.Drawing.Size(106, 50);
            this.buttonCalculateSaving.TabIndex = 4;
            this.buttonCalculateSaving.Text = "Calculate Savings";
            this.buttonCalculateSaving.UseVisualStyleBackColor = true;
            this.buttonCalculateSaving.Click += new System.EventHandler(this.buttonCalculateSaving_Click);
            // 
            // ResumeSavingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 520);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ResumeSavingsForm";
            this.Text = "Saving Resume";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.savingChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DataVisualization.Charting.Chart savingChart;
        private System.Windows.Forms.Button buttonCalculateSaving;
    }
}