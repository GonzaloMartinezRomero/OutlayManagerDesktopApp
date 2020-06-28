namespace OutlayManagerWF
{
    partial class TransactionSettings
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
            this.text_description = new System.Windows.Forms.TextBox();
            this.text_amount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimeSpend = new System.Windows.Forms.DateTimePicker();
            this.textBoxSpendType = new System.Windows.Forms.TextBox();
            this.transactionCodeSelector = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // text_description
            // 
            this.text_description.Location = new System.Drawing.Point(118, 97);
            this.text_description.Multiline = true;
            this.text_description.Name = "text_description";
            this.text_description.Size = new System.Drawing.Size(433, 27);
            this.text_description.TabIndex = 9;
            // 
            // text_amount
            // 
            this.text_amount.Location = new System.Drawing.Point(396, 54);
            this.text_amount.Multiline = true;
            this.text_amount.Name = "text_amount";
            this.text_amount.Size = new System.Drawing.Size(155, 26);
            this.text_amount.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save Transaction";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_ConfirmChanges);
            // 
            // dateTimeSpend
            // 
            this.dateTimeSpend.Enabled = false;
            this.dateTimeSpend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeSpend.Location = new System.Drawing.Point(396, 12);
            this.dateTimeSpend.Name = "dateTimeSpend";
            this.dateTimeSpend.Size = new System.Drawing.Size(155, 22);
            this.dateTimeSpend.TabIndex = 3;
            this.dateTimeSpend.Value = new System.DateTime(2019, 11, 1, 18, 10, 24, 0);
            // 
            // textBoxSpendType
            // 
            this.textBoxSpendType.Location = new System.Drawing.Point(118, 12);
            this.textBoxSpendType.Multiline = true;
            this.textBoxSpendType.Name = "textBoxSpendType";
            this.textBoxSpendType.ReadOnly = true;
            this.textBoxSpendType.Size = new System.Drawing.Size(155, 26);
            this.textBoxSpendType.TabIndex = 1;
            // 
            // transactionCodeSelector
            // 
            this.transactionCodeSelector.FormattingEnabled = true;
            this.transactionCodeSelector.Location = new System.Drawing.Point(118, 54);
            this.transactionCodeSelector.Name = "transactionCodeSelector";
            this.transactionCodeSelector.Size = new System.Drawing.Size(155, 24);
            this.transactionCodeSelector.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 27);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Type Spend";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(290, 12);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Date";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Code";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(290, 54);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 27);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Amount";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(12, 97);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 27);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "Description";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TransactionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 188);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.transactionCodeSelector);
            this.Controls.Add(this.textBoxSpendType);
            this.Controls.Add(this.dateTimeSpend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_amount);
            this.Controls.Add(this.text_description);
            this.Name = "TransactionSettings";
            this.Text = "TransactionSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text_description;
        private System.Windows.Forms.TextBox text_amount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimeSpend;
        private System.Windows.Forms.TextBox textBoxSpendType;
        private System.Windows.Forms.ComboBox transactionCodeSelector;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}