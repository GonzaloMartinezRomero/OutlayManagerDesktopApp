using Newtonsoft.Json;
using OutlayManagerWF.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace OutlayManagerWF.WebServices
{
    public class OutlayAPIManager :IDisposable
    {
        private readonly HttpClient client;
        private readonly string applicationURI;
        private OutlayDataHelper dataHelper = new OutlayDataHelper();

        public OutlayAPIManager()
        {
            applicationURI = ConfigurationManager.AppSettings["applicationURL"] ?? String.Empty;

            this.client = new HttpClient();
        }

        public List<TransactionDTO> GetAllTransactions()
        {
            string path = $"{applicationURI}/Outlay/All";

            try
            {
                var response = client.GetAsync(path);
                var content = response.Result.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<TransactionDTO>>(content);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error while getting all transactions", e);
            }
        }

        public List<TransactionDTO> GetTransaction(int year, int month)
        {
            string path = $"{applicationURI}/Outlay?year={year}&month={month}";

            var response = client.GetAsync(path);
            var content = response.Result.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<List<TransactionDTO>>(content);

            return result;
        }

        public List<string> GetOutlayTypes()
        {
            string path = $"{applicationURI}/OutlayInfo/TypeOutlays";

            List<string> outlayTypes = null;

            try
            {
                var response = client.GetAsync(path);
                var content = response.Result.Content.ReadAsStringAsync().Result;

                outlayTypes = JsonConvert.DeserializeObject<List<string>>(content);

            }catch(Exception e)
            {
                throw new Exception($"Error while loading {nameof(this.GetOutlayTypes)}", e);
            }

            return outlayTypes ?? new List<string>();
        }

        public List<ResultInfo> SaveTransaction(List<TransactionDTO> transactionCollection)
        {
            List<ResultInfo> responseCollection = new List<ResultInfo>();
            string path = $"{applicationURI}/Outlay";

            foreach (var transactionAux in transactionCollection)
            {
                string bodyJSON = JsonConvert.SerializeObject(transactionAux);

                StringContent contentSTR = new StringContent(bodyJSON, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, contentSTR).Result;

                responseCollection.Add(new ResultInfo()
                {
                    IsError = !response.IsSuccessStatusCode,
                    Message = $"{response.ReasonPhrase}"
                });
            }

            return responseCollection;
        }

        public List<ResultInfo> ModifyTransaction(List<TransactionDTO> transactionCollection)
        {
            List<ResultInfo> responseCollection = new List<ResultInfo>();
            string path = $"{applicationURI}/Outlay";

            foreach (var transactionAux in transactionCollection)
            {
                string bodyJSON = JsonConvert.SerializeObject(transactionAux);

                StringContent contentSTR = new StringContent(bodyJSON, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(path, contentSTR).Result;

                responseCollection.Add(new ResultInfo()
                {
                    IsError = !response.IsSuccessStatusCode,
                    Message = $"{response.ReasonPhrase}"
                });
            }

            return responseCollection;
        }

        public List<ResultInfo> DeleteTransaction(List<TransactionDTO> transactionCollection)
        {
            List<ResultInfo> responseCollection = new List<ResultInfo>();
            string path = $"{applicationURI}/Outlay";

            foreach (var transactionAux in transactionCollection)
            {
                path += $"/{transactionAux.ID}";

                HttpResponseMessage response = client.DeleteAsync(path).Result;

                responseCollection.Add(new ResultInfo()
                {
                    IsError = !response.IsSuccessStatusCode,
                    Message = $"{response.ReasonPhrase}"
                });
            }

            return responseCollection;
        }

        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
