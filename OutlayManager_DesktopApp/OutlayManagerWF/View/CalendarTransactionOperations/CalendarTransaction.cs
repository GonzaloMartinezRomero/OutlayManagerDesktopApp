using OutlayManagerWF.Model;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OutlayManagerWF
{
    public partial class CalendarTransaction : Form
    {
        private const int MAX_COLUMNS = 7;
        private readonly Color EmptyDayColor = Color.OrangeRed;

        private Dictionary<TextBox, DateTime> textBoxDayBinding = new Dictionary<TextBox, DateTime>();
        private Dictionary<DateTime, List<TransactionDTO>> calendarTransaction= new Dictionary<DateTime, List<TransactionDTO>>();

        private readonly OutlayAPIManager outlayServiceAPI;
        private readonly OutlayDataHelper dataHelper;

        public readonly int year, month;

        public delegate void NotifyChanges(object sender, EventArgs e);
        public event NotifyChanges OnChangesInCalendar;

        private readonly Dictionary<DayOfWeek, int> matrixDayPosition = new Dictionary<DayOfWeek, int>()
        {
            {DayOfWeek.Monday, 0 },
            {DayOfWeek.Tuesday, 1 },
            {DayOfWeek.Wednesday, 2 },
            {DayOfWeek.Thursday, 3 },
            {DayOfWeek.Friday, 4 },
            {DayOfWeek.Saturday, 5 },
            {DayOfWeek.Sunday, 6 },
        };

        private CalendarTransaction()
        {
            InitializeComponent();
        }

        public CalendarTransaction(int year, int month):this()
        {
            this.year = year;
            this.month = month;

            outlayServiceAPI = new OutlayAPIManager();
            dataHelper = new OutlayDataHelper();

            dataHelper.SetOutlayTypes(outlayServiceAPI.GetOutlayTypes());

            InitializeAllComponents();            
        }

        public DateTime DateTimeLoaded() => new DateTime(this.year, this.month, 01);

        private void InitializeAllComponents()
        {
            List<TransactionDTO> transactionList = outlayServiceAPI.GetTransaction(year, month);

            calendarTransaction = new Dictionary<DateTime, List<TransactionDTO>>();

            if (transactionList != null && transactionList.Count > 0)
            {
                calendarTransaction = transactionList.ToLookup(key => key.Date, value => value)
                                                .ToDictionary(key => key.Key, value => value.ToList());
            }

            InitializeMatrixCalendarControllers(new DateTime(year, month, 01), calendarTransaction);

            InitializeCalendarColorDesing();
        }

        private void InitializeCalendarColorDesing()
        {  
            int maxRow = this.tableLayoutPanel1.RowCount;
         
            for (int row = 1; row < maxRow; ++row)
            {
                for(int column = 0; column < MAX_COLUMNS; ++column)
                {
                    var matrixControlCalendar = this.tableLayoutPanel1.GetControlFromPosition(column, row);

                    if (matrixControlCalendar is TextBox t && !textBoxDayBinding.ContainsKey(t))
                        t.BackColor = EmptyDayColor; 
                }
            }
        }

        private void InitializeMatrixCalendarControllers(DateTime currentDay, Dictionary<DateTime, List<TransactionDTO>> calendarTransaction)
        {
            //Initialize month
            this.TextCurrentMonth.Text = currentDay.ToString("MMMM", CultureInfo.CurrentCulture).ToUpper();

            //Initialize matrix days
            DateTime initMonth = new DateTime(currentDay.Year, currentDay.Month, 1);
            DateTime endMonth = initMonth.AddMonths(1).Date;

            DayOfWeek day = initMonth.DayOfWeek;
            int colPosition = matrixDayPosition[day];

            int maxRowAllowed = this.tableLayoutPanel1.RowCount;
            int currentRow = 1;
           
            while(initMonth < endMonth)
            {
                if (currentRow >= maxRowAllowed)
                    throw new Exception("Row limit has been surpassed");

                var matrixControlCalendar = this.tableLayoutPanel1.GetControlFromPosition(colPosition, currentRow);

                if (matrixControlCalendar is TextBox textBoxDayMatrix)
                {
                    textBoxDayBinding.Add(textBoxDayMatrix, initMonth);

                    textBoxDayMatrix.Text = initMonth.ToShortDateString() + Utilities.TextBuilder.EndOfLineCustom("-", 30);
                    
                    if (calendarTransaction.ContainsKey(initMonth))                    
                        textBoxDayMatrix.Text += Utilities.TextBuilder.TransactionToText(calendarTransaction[initMonth]) + Utilities.TextBuilder.EndOfLineCustom(); 
                }         

                colPosition += 1;

                if (colPosition == MAX_COLUMNS)
                {
                    colPosition = 0;
                    currentRow += 1;
                }

                initMonth = initMonth.AddDays(1);
            }
        }

        private void OnClick_CalendarDay(object sender, EventArgs e)
        {
            TextBox textBoxSelected = (TextBox)sender;
            if (textBoxDayBinding.ContainsKey(textBoxSelected))
            {
                DateTime date = this.textBoxDayBinding[textBoxSelected];
                List<TransactionDTO> transactionsSelected = (calendarTransaction.ContainsKey(date)) ? calendarTransaction[date] : null;
                this.Enabled = false;

                TransactionInfo formTransaction = new TransactionInfo(transactionsSelected, date);
                formTransaction.FormClosed += RefreshCalendarForm;
                formTransaction.Show();
            }
        }

        private void RefreshCalendarForm(object sender, FormClosedEventArgs e)
        {
            textBoxDayBinding.Clear();
            calendarTransaction.Clear();

            InitializeAllComponents();

            OnChangesInCalendar?.Invoke(this, null);

            this.Enabled = true;
        }
    }
}
