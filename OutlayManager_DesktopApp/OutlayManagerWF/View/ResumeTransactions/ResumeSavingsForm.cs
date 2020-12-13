﻿using OutlayManagerWF.Manager;
using OutlayManagerWF.Model.View;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OutlayManagerWF.View.ResumeTransactions
{
    public partial class ResumeSavingsForm : Form
    {
        private const string DATE_FORMAT = "MM/yyyy";
        private readonly DateTime MIN_DATETIME = new DateTime(2019,01,01);
        private readonly Queue<Color> queueSerieColors = new Queue<Color>();

        public ResumeSavingsForm()
        {
            InitializeComponent();
            ConfigureForm();
            RefreshSeriesColors();
        }

        private void RefreshSeriesColors()
        {
            queueSerieColors.Clear();

            queueSerieColors.Enqueue(Color.Green);
            queueSerieColors.Enqueue(Color.Yellow);
            queueSerieColors.Enqueue(Color.Orange);
            queueSerieColors.Enqueue(Color.Blue);
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
            this.savingChart.Series.Clear();

            this.chartTypeSelector.Items.AddRange(new object[]
            {
                SeriesChartType.Line,
                SeriesChartType.Spline,
                SeriesChartType.Area,
                SeriesChartType.Column,
            });

            //Line by default
            this.chartTypeSelector.SelectedItem = SeriesChartType.Line;

        }

        private void buttonCalculateSaving_Click(object sender, EventArgs e)
        {
            try
            {
                using OutlayAPIManager apiManager = new OutlayAPIManager();
                List<TransactionView> transacionsList = apiManager.GetAllTransactions()
                                                                  .Select(x => Utilities.CastObject.TransactionToTransactionView(x))
                                                                  .ToList();

                DateTime dateFrom = new DateTime(this.dateTimeFrom.Value.Year, this.dateTimeFrom.Value.Month, 1);
                DateTime dateTo = new DateTime(this.dateTimeTo.Value.Year, this.dateTimeTo.Value.Month, DateTime.DaysInMonth(this.dateTimeTo.Value.Year, this.dateTimeTo.Value.Month));

                if (dateTo.Year != dateFrom.Year)
                    throw new Exception("Range of time must be 1 year per serie");

                Dictionary<DateKey, string> result = transacionsList.Where(x => x.Date >= dateFrom && x.Date <= dateTo)
                               .GroupBy(x => new DateKey(x.Date.Month, x.Date.Year))
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

                AddNewSerie(result, dateFrom.Year);
            }
            catch(Exception ex)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, ex.Message, this);
            }
        }

        private void AddNewSerie(Dictionary<DateKey, string> dictValues, int year)
        {
            if (queueSerieColors.Count > 0)
            {
                Color serieColor = queueSerieColors.Dequeue();

                Series savingSerie = new Series
                {
                    Name = $"{year.ToString()}_{this.savingChart.Series.Count}",
                    Color = serieColor,                    
                    IsVisibleInLegend = true,
                    IsXValueIndexed = true,
                    ChartType = this.chartTypeSelector.SelectedItem as SeriesChartType? ?? SeriesChartType.Line,
                    IsValueShownAsLabel = true,
                    MarkerStyle = MarkerStyle.Circle                    
                };

                this.savingChart.Series.Add(savingSerie);

                foreach (var kvpValues in dictValues)
                {
                    savingSerie.Points.AddXY(kvpValues.Key.Month.ToString(), kvpValues.Value );
                }

                this.savingChart.AlignDataPointsByAxisLabel();
            }
            else
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Information, "Max number of series reached", this);
            }          
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.savingChart.Series.Clear();
            RefreshSeriesColors();
        }

        private void buttonMergeByMonth_Click(object sender, EventArgs e)
        {
           var chartArea = this.savingChart.ChartAreas.Add("AAAA");


            foreach (var seriesAux in this.savingChart.Series)
            {
                foreach (var pointsOfSeriesAux in seriesAux.Points)
                {
                    DateKey dateKey = DateKey.ToDateKey(pointsOfSeriesAux.AxisLabel);
                    pointsOfSeriesAux.AxisLabel = dateKey.Month.ToString();
                }
            }
        }
        private sealed class DateKey
        {
            public int Month { get; private set; }
            public int Year { get; private set; }

            private DateKey() { }

            public DateKey (int month, int year)
            {
                this.Month = month;
                this.Year = year;
            }
            
            /// <summary>
            /// Format: Month_Year
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            public static DateKey ToDateKey(string date)
            {
                string[] splittedValues = date.Split('_');

                int month = Convert.ToInt32(splittedValues[0]);
                int year = Convert.ToInt32(splittedValues[1]);

                return new DateKey(month, year);
            }

            public override string ToString()
            {
                return $"{Month}_{Year}";
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if(obj is DateKey dateKeyAux)
                {
                    return this.Month == dateKeyAux.Month &&
                           this.Year == dateKeyAux.Year;  
                }

                return false;
            }
        }
    }
}
