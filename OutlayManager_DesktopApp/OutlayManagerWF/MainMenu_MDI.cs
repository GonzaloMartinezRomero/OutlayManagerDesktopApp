using OutlayManagerWF.Manager;
using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.Utilities;
using OutlayManagerWF.View.ResumeTransactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OutlayManagerWF
{
    public partial class MainMenu_MDI : Form
    {  
        private readonly Dictionary<string, int> monthNumberCorrespondence;
        private readonly HashSet<DateTime> formsLoaded;

        private int monthSelected = 0;
        private int yearSelected = 0;

        public MainMenu_MDI()
        {
            InitializeComponent();

            string[] months = DateTimeFormatInfo.CurrentInfo.MonthNames;

            //Load months in dictionary
            monthNumberCorrespondence = new Dictionary<string, int>();
            for (int i = 0; i < months.Length; ++i)
                monthNumberCorrespondence.Add(months[i], i + 1);

            //Loads years
            List<object> rangeYears = new List<object>();            
            for(int year = 2017; year <= DateTime.Today.Year; ++year)
                rangeYears.Add(year);

            this.dropDownMonth.Items.AddRange(months);
            this.dropDownYear.Items.AddRange(rangeYears.ToArray());

            this.dropDownYear.SelectedItem = DateTime.Today.Year;
            this.dropDownMonth.SelectedItem = monthNumberCorrespondence.Where(x => x.Value == DateTime.Today.Month)
                                                                       .Select(x => x.Key)
                                                                       .Single();

            formsLoaded = new HashSet<DateTime>();

            this.FormClosed += BackupOnClose;
            this.autoBackupCheck.Checked = true;

            //Autoload default month selected
            this.CalendarTransactions_Click(this, null);
        }

        private void CalendarTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedDate();

                DateTime dateSelected = new DateTime(yearSelected, monthSelected, 01);

                if (formsLoaded.Contains(dateSelected))
                    throw new Exception("Calendar selected its already loaded");
                else
                {
                    CalendarTransaction calendarTransaction = new CalendarTransaction(yearSelected, monthSelected);
                    calendarTransaction.MdiParent = this;
                    
                    this.splitContainer1.Panel2.Controls.Add(calendarTransaction);
                    this.splitContainer1.Dock = DockStyle.Fill;

                    formsLoaded.Add(dateSelected);
                    calendarTransaction.FormClosed += UnloadFormCalendar;
                    calendarTransaction.OnChangesInCalendar += LoadResumeFromSelectedFormMDI;

                    calendarTransaction.BringToFront();
                    calendarTransaction.Show();

                    LoadResumeFromSelectedFormMDI(calendarTransaction, null);
                }
            }
            catch(Exception except)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, except.Message, this);
            }            
        }

        private void UpdateSelectedDate()
        {
            monthSelected = monthNumberCorrespondence[this.dropDownMonth.SelectedItem.ToString()];
            yearSelected = Int32.Parse(this.dropDownYear.SelectedItem.ToString());
        }

        private void UnloadFormCalendar(object sender, FormClosedEventArgs e)
        {
            if(sender is CalendarTransaction calendarClosed)
            {
                if (formsLoaded.Contains(calendarClosed.DateTimeLoaded()))
                    formsLoaded.Remove(calendarClosed.DateTimeLoaded());
            }
        }

        private void LoadResumeFromSelectedFormMDI(object sender, EventArgs e)
        {
            if(sender is CalendarTransaction calendar)
            {
                int year = calendar.year;
                int month = calendar.month;

                TransactionManager transactionManager = new TransactionManager();
                ResumeMonth resume =  transactionManager.GetResume(year,month);
                
                this.textBoxYear.Text = resume.Date.Year.ToString();
                this.textBoxMonth.Text = resume.Date.Month.ToString();

                this.textBoxIncoming.Text = Normalizer.SpainFormatAmount(resume.Incoming);
                this.textBoxExpenses.Text = Normalizer.SpainFormatAmount(resume.Spenses);

                double savingAmount = Math.Round(resume.Incoming - resume.Spenses, 2);
                this.textBoxSaving.Text = Normalizer.SpainFormatAmount(savingAmount);
                this.textBoxSaving.BackColor = (savingAmount > 0) ? Color.GreenYellow : Color.Red;

                double totalAmount = transactionManager.GetTotalAmount() + resume.Adjust;
                this.textBoxTotalAmount.Text = Normalizer.SpainFormatAmount(totalAmount);
            }
        }

        private void BackupOnClose(object sender, EventArgs e)
        {
            if (this.autoBackupCheck.Checked)
            {
                BackupManager bckManager = new BackupManager();
                ResultInfo resultInfo = bckManager.SaveBackupAsCsv();

                if (resultInfo.IsError)
                {
                    new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception,
                                                   "Backup has not been executed:" + resultInfo.Message,
                                                   this);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate();

            ResumeForm resumeForm = new ResumeForm(this.yearSelected,this.monthSelected);
            resumeForm.MdiParent = this;

            this.splitContainer1.Panel2.Controls.Add(resumeForm);
            this.splitContainer1.Dock = DockStyle.Fill;

            resumeForm.BringToFront();
            resumeForm.Show();
        }

        private void buttonBackupFolder_Click(object sender, EventArgs e)
        {
            new BackupManager().OpenBackupDirectory();
        }

        /*    VERY DANGEROUS CODE    */
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    using (var fbd = new FolderBrowserDialog())
        //    {
        //        var result = fbd.ShowDialog();

        //        string path = fbd.SelectedPath;

        //        TransactionManager tm = new TransactionManager();
        //        tm.LoadTransactionToBDFromCSV(path);
        //    }   
        //}
    }
}
