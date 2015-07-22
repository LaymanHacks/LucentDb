
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;
using Newtonsoft.Json;


namespace LucentDb.Data.WebApiRepository
{

    [DataObject(true)]
    public class WebApiRunHistoryRepository : IRunHistoryRepository, IDisposable
    {

        private const string UrlBase = "/api/runHistories";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiRunHistoryRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<RunHistory> GetData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<RunHistory>>(responseString);
                return returnValue;
            }
        }

        public void Update(Int32 testId, DateTime runDateTime, Boolean isPass, string runLog, string resultString, Int64 id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var runHistory = new RunHistory()
                    {
                    TestId = testId, 
                    RunDateTime = runDateTime, 
                    IsPass = isPass, 
                    RunLog = runLog, 
                    ResultString = resultString, 
                    Id = id
                    };
                var response = client.PutAsync(UrlBase, runHistory, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(RunHistory runHistory)
        {
            Update(runHistory.TestId, runHistory.RunDateTime, runHistory.IsPass, runHistory.RunLog, runHistory.ResultString, runHistory.Id);
        }


        public void Delete(Int64 id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.DeleteAsync(UrlBase + "?id=" + id).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Delete(RunHistory runHistory)
        {
            Delete(runHistory.Id);
        }


        public Int64 Insert(Int32 testId, DateTime runDateTime, Boolean isPass, string runLog, string resultString)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var runHistory = new RunHistory()
                    {
                    TestId = testId, 
                    RunDateTime = runDateTime, 
                    IsPass = isPass, 
                    RunLog = runLog, 
                    ResultString = resultString
                    };
                var response = client.PostAsync(UrlBase, runHistory, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue  = Convert.ToInt64(responseString);
                return returnValue;
            }
        }

        public Int64 Insert(RunHistory runHistory)
        {
            return Insert(runHistory.TestId, runHistory.RunDateTime, runHistory.IsPass, runHistory.RunLog, runHistory.ResultString);
        }


        public PagedResult<RunHistory> GetDataPageable(string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "?sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistory>>(responseString);
                return returnValue;
            }
        }


        public ICollection<RunHistory> GetDataById(Int64 id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<RunHistory>>(responseString);
                return returnValue;
            }
        }

        public ICollection<RunHistory> GetDataByTestId(Int32 testId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/tests/" + testId  + "/runHistories/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<RunHistory>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<RunHistory> GetDataByTestIdPageable(Int32 testId, string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/tests/" + testId  + "/runHistories" + "?testId=" + testId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistory>>(responseString);
                return returnValue;
            }
        }


        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _messageHandler = null;
                }
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
