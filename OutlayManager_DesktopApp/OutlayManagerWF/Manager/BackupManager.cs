using OutlayManagerWF.Model;
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
    internal sealed class BackupManager
    {
        public const string PATH_BACKUP_KEY = "PathBackup";
        private string BackupDirectory { get; }

        public BackupManager()
        {
            BackupDirectory = ConfigurationManager.AppSettings.Get(PATH_BACKUP_KEY);
        }

        public ResultInfo SaveBackupAsCsv()
        {
            ResultInfo result = new ResultInfo() { IsError = false, Message = "Save succesfully" };

            if (Directory.Exists(BackupDirectory))
            {
                try
                {
                    OutlayAPIManager apiManager = new OutlayAPIManager();

                    List<TransactionDTO> allTransactions = apiManager.GetAllTransactions();

                    string csvFile = WriteTransactionToCSV(allTransactions);
                    string fileName = "Backup_" + DateTime.Now.ToString("ddMMyyyy") + ".csv";

                    using (StreamWriter sw = File.CreateText(BackupDirectory + "\\" + fileName))
                    {
                        sw.WriteLine(csvFile);
                    }
                }
                catch (Exception e)
                {
                    result.IsError = true;
                    result.Message = e.Message;
                }
            }
            else
            {
                result.IsError = true;
                result.Message = $"Directory: {BackupDirectory} is not correct";
            }

            return result;
        }

        public void OpenBackupDirectory()
        {
            if (Directory.Exists(BackupDirectory))
            {
                System.Diagnostics.Process.Start(BackupDirectory);
            }
            else
            {
                new DialogManager().ShowDialog(DialogManager.DialogLevel.Information,
                                              $"Directory {BackupDirectory} not exist!",
                                              null);
            }
        }


        private string WriteTransactionToCSV(List<TransactionDTO> allTransactions)
        {
            const string HEADER = "FECHA;TIPO_GASTO;CANTIDAD;CODIGO;DESCRIPCION";
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine(HEADER);

            foreach (TransactionDTO transactionAux in allTransactions)
            {
                List<string> row = new List<string>();
                row.Add(transactionAux.Date.ToString("yyyy/MM/dd"));
                row.Add(transactionAux.DetailTransaction.Type);
                row.Add(transactionAux.Amount.ToString());
                row.Add(transactionAux.DetailTransaction.Code);
                row.Add(transactionAux.DetailTransaction.Description);

                strBuilder.AppendLine(String.Join(";", row));
            }

            return strBuilder.ToString();
        }
    }
}
