using System;
using System.Collections.Generic;
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
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistory>>(resultString);
                return returnValue;
            }
        }

        public void Update(int? testId, int? projectId, int? testGroupId, DateTime runDateTime, bool isValid,
            string runLog, long id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var runHistory = new RunHistory(id, testId, projectId, testGroupId, runDateTime, isValid, runLog);
                var response = client.PutAsync(UrlBase, runHistory, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(RunHistory runHistory)
        {
            Update(runHistory.TestId, runHistory.ProjectId, runHistory.GroupId, runHistory.RunDateTime,
                runHistory.IsValid, runHistory.RunLog, runHistory.Id);
        }

        public void Delete(long id)
        {
            using (var client = new HttpClient(_messageHandler))
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

        public long Insert(int? testId, int? projectId, int? testGroupId, DateTime runDateTime, bool isValid,
            string runLog)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase).Result;
                if (!response.IsSuccessStatusCode) return 0;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt64(resultString);
                return returnValue;
            }
        }

        public long Insert(RunHistory runHistory)
        {
            return Insert(runHistory.TestId, runHistory.ProjectId, runHistory.GroupId, runHistory.RunDateTime,
                runHistory.IsValid, runHistory.RunLog);
        }

        public PagedResult<RunHistory> GetDataPageable(string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "?sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" +
                                    pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistory>>(resultString);
                return returnValue;
            }
        }

        public ICollection<RunHistory> GetDataById(long id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/runHistories/" + id).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistory>>(resultString);
                return returnValue;
            }
        }

        public ICollection<RunHistory> GetDataByTestId(int testId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/tests/" + testId + "/runHistories/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistory>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<RunHistory> GetDataByTestIdPageable(int testId, string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/tests/" + testId + "/runHistories" + "?testId=" + testId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistory>>(resultString);
                return returnValue;
            }
        }

        #region "IDisposable Support"

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

        #endregion
    }
}