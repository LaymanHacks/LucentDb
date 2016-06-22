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
    public class WebApiRunHistoryDetailRepository : IRunHistoryDetailRepository, IDisposable
    {
        private const string UrlBase = "/api/runHistoryDetails";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiRunHistoryDetailRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<RunHistoryDetail> GetData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistoryDetail>>(resultString);
                return returnValue;
            }
        }

        public void Update(long runHistoryId, int testId, DateTime runDateTime, decimal? duration, bool isValid,
            string resultString, long id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var runHistoryDetail = new RunHistoryDetail(id, runHistoryId, testId, runDateTime, duration, isValid,
                    resultString);
                var response = client.PutAsync(UrlBase, runHistoryDetail, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(RunHistoryDetail runHistoryDetail)
        {
            Update(runHistoryDetail.RunHistoryId, runHistoryDetail.TestId, runHistoryDetail.RunDateTime,
                runHistoryDetail.Duration, runHistoryDetail.IsValid, runHistoryDetail.ResultString, runHistoryDetail.Id);
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

        public void Delete(RunHistoryDetail runHistoryDetail)
        {
            Delete(runHistoryDetail.Id);
        }


        public long Insert(long runHistoryId, int testId, DateTime runDateTime, decimal? duration, bool isValid,
            string resultString)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase).Result;
                if (!response.IsSuccessStatusCode) return 0;
                var resultStringOut = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt64(resultStringOut);
                return returnValue;
            }
        }

        public long Insert(RunHistoryDetail runHistoryDetail)
        {
            return Insert(runHistoryDetail.RunHistoryId, runHistoryDetail.TestId, runHistoryDetail.RunDateTime,
                runHistoryDetail.Duration, runHistoryDetail.IsValid, runHistoryDetail.ResultString);
        }


        public PagedResult<RunHistoryDetail> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistoryDetail>>(resultString);
                return returnValue;
            }
        }


        public ICollection<RunHistoryDetail> GetDataById(long id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistoryDetail>>(resultString);
                return returnValue;
            }
        }

        public ICollection<RunHistoryDetail> GetDataByRunHistoryId(long runHistoryId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/runHistories/" + runHistoryId + "/runHistoryDetails/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<RunHistoryDetail>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<RunHistoryDetail> GetDataByRunHistoryIdPageable(long runHistoryId, string sortExpression,
            int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/runHistories/" + runHistoryId + "/runHistoryDetails" + "?runHistoryId=" +
                                    runHistoryId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" +
                                    pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<RunHistoryDetail>>(resultString);
                return returnValue;
            }
        }

        #region "IDisposable Support"

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _messageHandler = null;
                }
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}