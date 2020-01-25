using Newtonsoft.Json;
using OutlayManagerWF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OutlayManagerWF.WebServices
{
    public class OutlayAPIManager :IDisposable
    {
        private readonly HttpClient client;
        private const string URI = "http://localhost:51044/Outlay";
        private OutlayDataHelper dataHelper = new OutlayDataHelper();

        public OutlayAPIManager()
        {
            this.client = new HttpClient();
        }

        public List<TransactionDTO> GetAllTransactions()
        {
            string path = $"{URI}/All";

            var response = client.GetAsync(path);
            var content = response.Result.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<List<TransactionDTO>>(content);

            return result;
        }

        public List<TransactionDTO> GetTransaction(int year, int month)
        {
            string path = $"{URI}?year={year}&month={month}";

            var response = client.GetAsync(path);
            var content = response.Result.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<List<TransactionDTO>>(content);

            return result;
        }

        public List<string> GetOutlayTypes()
        {
            string path = "http://localhost:51044/OutlayInfo/TypeOutlays";

            List<string> outlayTypes =null;

            var response = client.GetAsync(path);
            var content = response.Result.Content.ReadAsStringAsync().Result;

            outlayTypes= JsonConvert.DeserializeObject<List<string>>(content);

            return outlayTypes ?? new List<string>();
        }

        public List<ResultInfo> SaveTransaction(List<TransactionDTO> transactionCollection)
        {
            List<ResultInfo> responseCollection = new List<ResultInfo>();
            string path = $"{URI}";

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
            string path = $"{URI}";

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
            string path = $"{URI}";

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
