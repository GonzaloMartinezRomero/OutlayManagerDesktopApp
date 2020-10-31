using OutlayManagerWF.Model.View;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OutlayManagerWF.View.ResumeTransactions
{
    public partial class ResumeSavingsForm : Form
    {
        private const string DATE_FORMAT = "MM/yyyy";
        private readonly DateTime MIN_DATETIME = new DateTime(2019,01,01);

        public ResumeSavingsForm()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.dateTimeFrom.Format = DateTimePickerFormat.Custom;
            this.dateTimeFrom.CustomFormat = DATE_FORMAT;
            this.dateTimeFrom.Value = MIN_DATETIME;

            this.dateTimeTo.Format = DateTimePickerFormat.Custom;
            this.dateTimeTo.CustomFormat = DATE_FORMAT;
            this.dateTimeTo.Value = DateTime.Today;

            this.savingChart.Titles.Add("Savings Resume");
        }

        private void buttonCalculateSaving_Click(object sender, EventArgs e)
        {
            using OutlayAPIManager apiManager = new OutlayAPIManager();
            List<TransactionView> transacionsList = apiManager.GetAllTransactions()
                                                              .Select(x => Utilities.CastObject.TransactionToTransactionView(x))
                                                              .ToList();

            DateTime dateFrom = new DateTime(this.dateTimeFrom.Value.Year, this.dateTimeFrom.Value.Month, 1);
            DateTime dateTo = new DateTime(this.dateTimeTo.Value.Year, this.dateTimeTo.Value.Month, DateTime.DaysInMonth(this.dateTimeTo.Value.Year, this.dateTimeTo.Value.Month));

            var result = transacionsList.Where(x => x.Date >= dateFrom && x.Date <= dateTo)
                           .GroupBy(x => $"{x.Date.Month}_{x.Date.Year}")
                                                .Select(x =>
                                                {
                                                    double totalIncoming = x.Where(y => OutlayDataHelper.GetOutlayType(y.Type) == OutlayDataHelper.OutlayTypesEnum.ADJUST ||
                                                                                         OutlayDataHelper.GetOutlayType(y.Type) == OutlayDataHelper.OutlayTypesEnum.INCOMING)
                                                                            .Select(x => x.Amount)
                                                                            .Sum();

                                                    double totalSpend = x.Where(y => OutlayDataHelper.GetOutlayType(y.Type) == OutlayDataHelper.OutlayTypesEnum.SPENDING)
                                                                          .Select(x => x.Amount)
                                                                          .Sum();

                                                    string totalMonthSave = Utilities.Normalizer.SpainFormatAmount((totalIncoming - totalSpend));

                                                    return new
                                                    {
                                                        x.Key,
                                                        totalMonthSave
                                                    };
                                                })
                                                .ToDictionary(key => key.Key, value => value.totalMonthSave);
            FillChart(result);
        }

        private void FillChart(Dictionary<string, string> dictValues)
        {
            this.savingChart.Series.Clear();

            Series savingSerie = new Series
            {
                Name = "Months_Saves",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.SplineArea,
                IsValueShownAsLabel = true, 
                MarkerStyle = MarkerStyle.Circle,
            };

            this.savingChart.Series.Add(savingSerie);

            foreach (var kvpValues in dictValues)
            {
                savingSerie.Points.AddXY(kvpValues.Key, kvpValues.Value);
            }
        }
    }
}
