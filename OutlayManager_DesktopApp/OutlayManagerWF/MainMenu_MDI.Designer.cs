namespace OutlayManagerWF
{
    partial class MainMenu_MDI
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonBackupFolder = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxExpenses = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBoxSaving = new System.Windows.Forms.TextBox();
            this.textBoxIncoming = new System.Windows.Forms.TextBox();
            this.Date = new System.Windows.Forms.GroupBox();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.autoBackupCheck = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dropDownMonth = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dropDownYear = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.buttonBackupFolder);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.Date);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxTotalAmount);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxTotal);
            this.splitContainer1.Panel1.Controls.Add(this.autoBackupCheck);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.dropDownMonth);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.dropDownYear);
            this.splitContainer1.Panel1.Controls.Add(this.textBox5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox8);
            this.splitContainer1.Size = new System.Drawing.Size(1407, 723);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 14;
            // 
            // buttonBackupFolder
            // 
            this.buttonBackupFolder.Location = new System.Drawing.Point(28, 649);
            this.buttonBackupFolder.Name = "buttonBackupFolder";
            this.buttonBackupFolder.Size = new System.Drawing.Size(178, 29);
            this.buttonBackupFolder.TabIndex = 36;
            this.buttonBackupFolder.Text = "Open Backup Folder";
            this.buttonBackupFolder.UseVisualStyleBackColor = true;
            this.buttonBackupFolder.Click += new System.EventHandler(this.buttonBackupFolder_Click);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(16, 604);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(208, 34);
            this.textBox3.TabIndex = 35;
            this.textBox3.Text = "BACKUPS";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBoxExpenses);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.textBoxSaving);
            this.groupBox2.Controls.Add(this.textBoxIncoming);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 152);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resume";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(9, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(77, 22);
            this.textBox4.TabIndex = 35;
            this.textBox4.Text = "Incomings";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxExpenses
            // 
            this.textBoxExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExpenses.Location = new System.Drawing.Point(93, 31);
            this.textBoxExpenses.Name = "textBoxExpenses";
            this.textBoxExpenses.ReadOnly = true;
            this.textBoxExpenses.Size = new System.Drawing.Size(123, 22);
            this.textBoxExpenses.TabIndex = 17;
            this.textBoxExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(9, 31);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(77, 22);
            this.textBox7.TabIndex = 14;
            this.textBox7.Text = "Expenses";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(9, 113);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(77, 22);
            this.textBox9.TabIndex = 15;
            this.textBox9.Text = "Saving";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSaving
            // 
            this.textBoxSaving.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaving.Location = new System.Drawing.Point(92, 113);
            this.textBoxSaving.Name = "textBoxSaving";
            this.textBoxSaving.ReadOnly = true;
            this.textBoxSaving.Size = new System.Drawing.Size(124, 22);
            this.textBoxSaving.TabIndex = 18;
            this.textBoxSaving.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxIncoming
            // 
            this.textBoxIncoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIncoming.Location = new System.Drawing.Point(93, 72);
            this.textBoxIncoming.Name = "textBoxIncoming";
            this.textBoxIncoming.ReadOnly = true;
            this.textBoxIncoming.Size = new System.Drawing.Size(123, 22);
            this.textBoxIncoming.TabIndex = 16;
            this.textBoxIncoming.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Date
            // 
            this.Date.Controls.Add(this.textBoxMonth);
            this.Date.Controls.Add(this.textBox11);
            this.Date.Controls.Add(this.textBox10);
            this.Date.Controls.Add(this.textBoxYear);
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.Location = new System.Drawing.Point(16, 291);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(222, 110);
            this.Date.TabIndex = 33;
            this.Date.TabStop = false;
            this.Date.Text = "Date";
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMonth.Location = new System.Drawing.Point(93, 68);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.ReadOnly = true;
            this.textBoxMonth.Size = new System.Drawing.Size(123, 22);
            this.textBoxMonth.TabIndex = 27;
            this.textBoxMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(9, 29);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(77, 22);
            this.textBox11.TabIndex = 24;
            this.textBox11.Text = "Year";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(9, 68);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(77, 22);
            this.textBox10.TabIndex = 25;
            this.textBox10.Text = "Month";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYear.Location = new System.Drawing.Point(93, 28);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.ReadOnly = true;
            this.textBoxYear.Size = new System.Drawing.Size(123, 22);
            this.textBoxYear.TabIndex = 26;
            this.textBoxYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalAmount.Location = new System.Drawing.Point(108, 567);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.ReadOnly = true;
            this.textBoxTotalAmount.Size = new System.Drawing.Size(130, 24);
            this.textBoxTotalAmount.TabIndex = 32;
            this.textBoxTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(16, 567);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(86, 24);
            this.textBoxTotal.TabIndex = 31;
            this.textBoxTotal.Text = "Total";
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // autoBackupCheck
            // 
            this.autoBackupCheck.AutoSize = true;
            this.autoBackupCheck.Location = new System.Drawing.Point(31, 692);
            this.autoBackupCheck.Name = "autoBackupCheck";
            this.autoBackupCheck.Size = new System.Drawing.Size(139, 21);
            this.autoBackupCheck.TabIndex = 30;
            this.autoBackupCheck.Text = "Backup On Close";
            this.autoBackupCheck.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 29);
            this.button2.TabIndex = 29;
            this.button2.Text = "Transactions Resume";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.showResume_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(28, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "Load Calendar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.CalendarTransactionsLoad_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(51, 22);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "Month";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dropDownMonth
            // 
            this.dropDownMonth.FormattingEnabled = true;
            this.dropDownMonth.Location = new System.Drawing.Point(85, 94);
            this.dropDownMonth.Name = "dropDownMonth";
            this.dropDownMonth.Size = new System.Drawing.Size(121, 24);
            this.dropDownMonth.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(51, 22);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Year";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dropDownYear
            // 
            this.dropDownYear.FormattingEnabled = true;
            this.dropDownYear.Location = new System.Drawing.Point(85, 58);
            this.dropDownYear.Name = "dropDownYear";
            this.dropDownYear.Size = new System.Drawing.Size(121, 24);
            this.dropDownYear.TabIndex = 21;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(16, 247);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(208, 34);
            this.textBox5.TabIndex = 12;
            this.textBox5.Text = "INFORMATION";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(16, 13);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(208, 34);
            this.textBox8.TabIndex = 11;
            this.textBox8.Text = "TRANSACTIONS";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 29);
            this.button3.TabIndex = 37;
            this.button3.Text = "Months Savings ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainMenu_MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 723);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Name = "MainMenu_MDI";
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Date.ResumeLayout(false);
            this.Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBoxSaving;
        private System.Windows.Forms.TextBox textBoxExpenses;
        private System.Windows.Forms.TextBox textBoxIncoming;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox dropDownMonth;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox dropDownYear;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox autoBackupCheck;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox Date;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button buttonBackupFolder;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
    }
}