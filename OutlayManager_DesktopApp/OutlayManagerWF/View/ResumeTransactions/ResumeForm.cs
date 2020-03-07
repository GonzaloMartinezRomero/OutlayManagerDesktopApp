using OutlayManagerWF.Manager;
using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OutlayManagerWF.View.ResumeTransactions
{
    public partial class ResumeForm : Form
    {
        private ResumeForm()
        {
            InitializeComponent();
        }

        public ResumeForm(int year, int month) : this()
        { 
            FillResumeMonthData(year, month);
            FillComparationExpenses(year, month);
        }

        private void FillComparationExpenses(int year, int month)
        {
            try
            {
                List<ResumeMonth> resumeMonthList = new List<ResumeMonth>();

                DateTime dateRequested = new DateTime(year, month, 1);

                TransactionManager trManager = new TransactionManager();
                resumeMonthList.Add(trManager.GetResume(dateRequested.Year, dateRequested.Month));

                DateTime pastMonth = dateRequested.AddMonths(-1);
                resumeMonthList.Add(trManager.GetResume(pastMonth.Year, pastMonth.Month));

                DateTime pastYear = dateRequested.AddYears(-1);
                resumeMonthList.Add(trManager.GetResume(pastYear.Year, pastYear.Month));

                BindingSource bindingSource = new BindingSource
                {
                    DataSource = resumeMonthList.Select(x =>
                    {
                        return new
                        {
                            x.Date,
                            x.Spenses,
                            x.Incoming,
                            Saving = Math.Round(x.Incoming - x.Spenses,2)
                        };
                    })
                };

                this.dataGridComparisionDate.DataSource = bindingSource;

            }catch(Exception e)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, e.Message, this);
            }

        }

        private void FillResumeMonthData(int year, int month)
        {
            try
            {
                List<ResumeCodeTransaction> resumeTransactions = new TransactionManager().GetResumeByCode(year, month)
                                                                                         .Where(x => x.Type.ToUpper().Trim() != OutlayDataHelper.OutlayTypesEnum.INCOMING.ToString())
                                                                                         .OrderByDescending(x => x.Amount)
                                                                                         .ToList();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = resumeTransactions;

                this.dataGridCodeExpenses.DataSource = bindingSource;
            }
            catch (Exception e)
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Exception, e.Message, this);
            }
           
        }
    }
}
