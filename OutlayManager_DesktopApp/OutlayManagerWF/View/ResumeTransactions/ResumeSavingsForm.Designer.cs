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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxYears = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chartTypeSelector = new System.Windows.Forms.ComboBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCalculateSaving = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.savingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxYears);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.chartTypeSelector);
            this.splitContainer1.Panel1.Controls.Add(this.buttonClear);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCalculateSaving);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.savingChart);
            this.splitContainer1.Size = new System.Drawing.Size(1372, 520);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBoxYears
            // 
            this.comboBoxYears.FormattingEnabled = true;
            this.comboBoxYears.Location = new System.Drawing.Point(12, 37);
            this.comboBoxYears.Name = "comboBoxYears";
            this.comboBoxYears.Size = new System.Drawing.Size(168, 24);
            this.comboBoxYears.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(196, 9);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(168, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Chart Type";
            // 
            // chartTypeSelector
            // 
            this.chartTypeSelector.FormattingEnabled = true;
            this.chartTypeSelector.Location = new System.Drawing.Point(196, 37);
            this.chartTypeSelector.Name = "chartTypeSelector";
            this.chartTypeSelector.Size = new System.Drawing.Size(168, 24);
            this.chartTypeSelector.TabIndex = 6;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(503, 12);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(106, 50);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCalculateSaving
            // 
            this.buttonCalculateSaving.Location = new System.Drawing.Point(391, 12);
            this.buttonCalculateSaving.Name = "buttonCalculateSaving";
            this.buttonCalculateSaving.Size = new System.Drawing.Size(106, 50);
            this.buttonCalculateSaving.TabIndex = 4;
            this.buttonCalculateSaving.Text = "Load Savings";
            this.buttonCalculateSaving.UseVisualStyleBackColor = true;
            this.buttonCalculateSaving.Click += new System.EventHandler(this.buttonCalculateSaving_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(168, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Year";
            // 
            // savingChart
            // 
            this.savingChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.None;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.PointDepth = 50;
            chartArea2.Area3DStyle.PointGapDepth = 150;
            chartArea2.Area3DStyle.WallWidth = 5;
            chartArea2.BackColor = System.Drawing.Color.Honeydew;
            chartArea2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            this.savingChart.ChartAreas.Add(chartArea2);
            this.savingChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.savingChart.Legends.Add(legend2);
            this.savingChart.Location = new System.Drawing.Point(0, 0);
            this.savingChart.Name = "savingChart";
            this.savingChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series3.IsValueShownAsLabel = true;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.savingChart.Series.Add(series3);
            this.savingChart.Series.Add(series4);
            this.savingChart.Size = new System.Drawing.Size(1372, 447);
            this.savingChart.TabIndex = 0;
            this.savingChart.Text = "chart1";
            // 
            // ResumeSavingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 520);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart savingChart;
        private System.Windows.Forms.Button buttonCalculateSaving;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox chartTypeSelector;
        private System.Windows.Forms.ComboBox comboBoxYears;
    }
}