using OutlayManagerWF.Model;
using OutlayManagerWF.Model.Info;
using OutlayManagerWF.Model.View;
using OutlayManagerWF.WebServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.Manager
{
    public class TransactionManager
    {  
        private readonly List<TransactionDTO> addedTransactions;
        private readonly List<TransactionDTO> modifiedTransactions;
        private readonly List<TransactionDTO> deletedTransactions;

        private int idNewTransaction;

        public TransactionManager()
        {
            addedTransactions = new List<TransactionDTO>();
            modifiedTransactions = new List<TransactionDTO>();
            deletedTransactions = new List<TransactionDTO>();
            idNewTransaction = 1;
        }

        public TransactionDTO AddNewTransaction(TransactionDTO transaction)
        {
            //Create as a copy
            TransactionDTO newTransaction = new TransactionDTO(transaction);

            //Configure as a new transaction
            newTransaction.Source = TransactionDTO.SourceGeneration.NewTransaction;
            newTransaction.Internal_ID = idNewTransaction++;

            //Add to list
            addedTransactions.Add(newTransaction);

            return newTransaction;
        }

        public TransactionDTO ModifyTransaction(TransactionDTO transaction)
        {
            TransactionDTO transactionModify = new TransactionDTO(transaction);

            switch (transaction.Source)
            {
                case TransactionDTO.SourceGeneration.DataBase:
                  
                    //Update register of modified entities
                    modifiedTransactions.RemoveAll(x => x.ID == transactionModify.ID);
                    modifiedTransactions.Add(new TransactionDTO(transactionModify));
                    break;

                case TransactionDTO.SourceGeneration.NewTransaction:

                    addedTransactions.RemoveAll(x => x.Internal_ID == transactionModify.Internal_ID);
                    addedTransactions.Add(transactionModify);
                    break;

                default:
                    throw new Exception("Transaction source not defined");
            }

            return transactionModify;
        }

        public TransactionDTO DeleteTransaction(TransactionDTO transaction)
        {
            TransactionDTO transactionDeleted = new TransactionDTO(transaction);

            switch (transaction.Source)
            {
                case TransactionDTO.SourceGeneration.DataBase:
                    deletedTransactions.Add(transactionDeleted);                   
                    break;

                case TransactionDTO.SourceGeneration.NewTransaction:
                    addedTransactions.RemoveAll(x => x.Internal_ID == transactionDeleted.Internal_ID);
                    break;

                default:
                    break;
            }

            return transactionDeleted;
        }

        public List<ResultInfo> SaveChanges()
        {
            using (OutlayAPIManager manager = new OutlayAPIManager())
            {
                List<ResultInfo> resultList = new List<ResultInfo>();

                resultList.AddRange(manager.SaveTransaction(addedTransactions));
                resultList.AddRange(manager.ModifyTransaction(modifiedTransactions));
                resultList.AddRange(manager.DeleteTransaction(deletedTransactions));

                return resultList;
            }
        }

        public bool ChangesDetected()
        {
            bool added = addedTransactions.Count > 0;
            bool modified = modifiedTransactions.Count > 0;
            bool deleted = deletedTransactions.Count > 0;

            return added || modified || deleted;
        }

        public List<TransactionDTO> AddedTransactionList => new List<TransactionDTO>(addedTransactions);

        public List<TransactionDTO> ModifiedTransactionList => new List<TransactionDTO>(modifiedTransactions);

        public List<TransactionDTO> DeletedTransactionList => new List<TransactionDTO>(deletedTransactions);
  
        public ResumeMonth GetResume(int year,int month)
        {
            ResumeMonth resumeMonth = new ResumeMonth(year, month);

            using (OutlayAPIManager API_Manager = new OutlayAPIManager())
            {
                List<TransactionDTO> monthTransaction = API_Manager.GetTransaction(year, month);

                if (monthTransaction != null)
                {
                    double totalAdjust = monthTransaction.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.ADJUST.ToString())
                                                   .Select(x => x.Amount)
                                                   .Sum();

                    double totalSpenses = monthTransaction.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.SPENDING.ToString())
                                                       .Select(x => x.Amount)
                                                       .Sum();

                    double totalIncoming = monthTransaction.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.INCOMING.ToString())
                                                       .Select(x => x.Amount)
                                                       .Sum();

                    var groupingCode = monthTransaction.GroupBy(x => x.DetailTransaction.Code)
                                                       .ToDictionary(key => key.Key, value => value.Sum(x => x.Amount));

                    resumeMonth.Spenses = totalSpenses - totalAdjust;
                    resumeMonth.Incoming = totalIncoming;
                    resumeMonth.GroupCodeTransactions = groupingCode;
                }
            }

            return resumeMonth;
        }

        public List<ResumeCodeTransaction> GetResumeByCode(int year, int month)
        {
            ResumeCodeTransaction resume = new ResumeCodeTransaction();

            try
            {
                OutlayAPIManager managerAPI = new OutlayAPIManager();

                List<TransactionDTO> transactions = managerAPI.GetTransaction(year, month);

                List<ResumeCodeTransaction> listResume = transactions.GroupBy(x => x.DetailTransaction.Code + x.DetailTransaction.Type)
                                                                     .Select(value =>
                                                                             {
                                                                                 return new ResumeCodeTransaction()
                                                                                 {
                                                                                     Code = value.FirstOrDefault()?.DetailTransaction.Code,
                                                                                     Type = value.FirstOrDefault()?.DetailTransaction.Type,
                                                                                     Amount = value.Sum(x => x.Amount),
                                                                                     Date = new DateTime(year, month, 01),
                                                                                 };
                                                                             })
                                                                     .ToList();
                return listResume;

            }
            catch (Exception e)
            {
                throw new Exception("Error while procesing resume by code", e);
            }
        }

        public List<string> TransactionCodes()
        {
            List<string> transactionCodesList = null;

            using (OutlayAPIManager managerAPI = new OutlayAPIManager())
            {
                List<TransactionDTO> transactions = managerAPI.GetAllTransactions();

                transactionCodesList = transactions.Select(x => x.DetailTransaction.Code)
                                                   .Distinct()
                                                   .ToList();

            }

            return transactionCodesList ?? new List<string>();
        }

        public double GetTotalAmount()
        {  
            OutlayAPIManager apiManager = new OutlayAPIManager();

            List<TransactionDTO> allTransactionsList = apiManager.GetAllTransactions();

            double totalIncomings = allTransactionsList.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.INCOMING.ToString())
                                                       .Select(x => x.Amount)
                                                       .Sum();

            double totalSpenses = allTransactionsList.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.SPENDING.ToString())
                                                       .Select(x => x.Amount)
                                                       .Sum();

            double totalAdjust = allTransactionsList.Where(x => x.DetailTransaction.Type == OutlayDataHelper.OutlayTypesEnum.ADJUST.ToString())
                                                     .Select(x => x.Amount)
                                                     .Sum();

            return totalIncomings - totalSpenses + totalAdjust;
        }

        public void LoadTransactionToBDFromCSV(string path)
        {
            if(File.Exists(path))
            {
                string[] transactionFileLines = File.ReadAllLines(path);
                string dateLoad = DateTime.Today.ToString("yyyy_MM_dd");

                using (OutlayAPIManager manager = new OutlayAPIManager())
                {
                    List<TransactionDTO> transactionList = new List<TransactionDTO>();

                    for (int indexLine = 1; indexLine < transactionFileLines.Length; ++indexLine)
                    {
                        string[] columns = transactionFileLines[indexLine].Split(';');

                        TransactionDTO transaction = new TransactionDTO()
                        {
                            Date = DateTime.Parse(columns[0].Trim()),
                            Amount = Double.Parse(columns[2].Trim(),System.Globalization.NumberStyles.AllowDecimalPoint),
                            DetailTransaction = new DetailTransacionDTO()
                            {
                                Type = columns[1].Trim(),
                                Code = "LOAD_CSV",
                                Description = $"LOAD_CS_{dateLoad}"
                            }
                        };

                        transactionList.Add(transaction);
                    }

                    manager.SaveTransaction(transactionList);
                }
            }
            else
            {
                throw new Exception($"Path {path} not found");
            }
        }     
    }
}
