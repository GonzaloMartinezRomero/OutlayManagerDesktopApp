using OutlayManagerWF.Manager;
using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.View.ResumeTransactions;
using System;
using System.Collections.Generic;
using System.Data;
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

                double totalAmount = transactionManager.GetTotalAmount();

                this.textBoxYear.Text = resume.Date.Year.ToString();
                this.textBoxMonth.Text = resume.Date.Month.ToString();
                this.textBoxIncoming.Text = resume.Incoming.ToString() + " €";
                this.textBoxExpenses.Text = resume.Spenses.ToString() + " €";
                this.textBoxSaving.Text = (resume.Incoming - resume.Spenses).ToString() + " €";
                
                this.textBoxTotalAmount.Text = $"{Math.Round(totalAmount,3)} €";
            }
        }

        private void BackupOnClose(object sender, EventArgs e)
        {
            if (this.autoBackupCheck.Checked)
            {
                TransactionManager transacionManager = new TransactionManager();
                ResultInfo resultInfo = transacionManager.SaveBackupAsCsv();

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
