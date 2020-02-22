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
            this.dataGridCodeExpenses = new System.Windows.Forms.DataGridView();
            this.dataGridComparisionDate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCodeExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComparisionDate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCodeExpenses
            // 
            this.dataGridCodeExpenses.AllowUserToAddRows = false;
            this.dataGridCodeExpenses.AllowUserToDeleteRows = false;
            this.dataGridCodeExpenses.AllowUserToOrderColumns = true;
            this.dataGridCodeExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCodeExpenses.Location = new System.Drawing.Point(12, 12);
            this.dataGridCodeExpenses.Name = "dataGridCodeExpenses";
            this.dataGridCodeExpenses.ReadOnly = true;
            this.dataGridCodeExpenses.RowHeadersWidth = 51;
            this.dataGridCodeExpenses.RowTemplate.Height = 24;
            this.dataGridCodeExpenses.Size = new System.Drawing.Size(625, 412);
            this.dataGridCodeExpenses.TabIndex = 4;
            // 
            // dataGridComparisionDate
            // 
            this.dataGridComparisionDate.AllowUserToAddRows = false;
            this.dataGridComparisionDate.AllowUserToDeleteRows = false;
            this.dataGridComparisionDate.AllowUserToOrderColumns = true;
            this.dataGridComparisionDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComparisionDate.Location = new System.Drawing.Point(673, 12);
            this.dataGridComparisionDate.Name = "dataGridComparisionDate";
            this.dataGridComparisionDate.ReadOnly = true;
            this.dataGridComparisionDate.RowHeadersWidth = 51;
            this.dataGridComparisionDate.RowTemplate.Height = 24;
            this.dataGridComparisionDate.Size = new System.Drawing.Size(597, 412);
            this.dataGridComparisionDate.TabIndex = 5;
            // 
            // ResumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 751);
            this.Controls.Add(this.dataGridComparisionDate);
            this.Controls.Add(this.dataGridCodeExpenses);
            this.Name = "ResumeForm";
            this.Text = "ResumeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCodeExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComparisionDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridCodeExpenses;
        private System.Windows.Forms.DataGridView dataGridComparisionDate;
    }
}