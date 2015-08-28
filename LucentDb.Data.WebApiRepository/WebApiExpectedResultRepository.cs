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
    public class WebApiExpectedResultRepository : IExpectedResultRepository, IDisposable
    {
        private const string UrlBase = "/api/expectedResults";
        private readonly string _baseAddress;
        private bool _disposedValue;
        private HttpMessageHandler _messageHandler;

        public WebApiExpectedResultRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICollection<ExpectedResult> GetData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public void Update(int testId, int? expectedResultTypeId, int? assertTypeId, string expectedValue,
            int resultIndex, int id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var expectedResult = new ExpectedResult
                {
                    TestId = testId,
                    ExpectedResultTypeId = expectedResultTypeId,
                    AssertTypeId = assertTypeId,
                    ExpectedValue = expectedValue,
                    ResultIndex = resultIndex,
                    Id = id
                };
                var response = client.PutAsync(UrlBase, expectedResult, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(ExpectedResult expectedResult)
        {
            Update(expectedResult.TestId, expectedResult.ExpectedResultTypeId, expectedResult.AssertTypeId,
                expectedResult.ExpectedValue, expectedResult.ResultIndex, expectedResult.Id);
        }

        public void Delete(int id)
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

        public void Delete(ExpectedResult expectedResult)
        {
            Delete(expectedResult.Id);
        }

        public int Insert(int testId, int? expectedResultTypeId, int? assertTypeId, string expectedValue,
            int resultIndex)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var expectedResult = new ExpectedResult
                {
                    TestId = testId,
                    ExpectedResultTypeId = expectedResultTypeId,
                    AssertTypeId = assertTypeId,
                    ExpectedValue = expectedValue,
                    ResultIndex = resultIndex
                };
                var response = client.PostAsync(UrlBase, expectedResult, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt32(responseString);
                return returnValue;
            }
        }

        public int Insert(ExpectedResult expectedResult)
        {
            return Insert(expectedResult.TestId, expectedResult.ExpectedResultTypeId, expectedResult.AssertTypeId,
                expectedResult.ExpectedValue, expectedResult.ResultIndex);
        }

        public PagedResult<ExpectedResult> GetDataPageable(string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "?sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" +
                                    pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public ICollection<ExpectedResult> GetDataById(int id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public ICollection<ExpectedResult> GetDataByAssertTypeId(int assertTypeId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/assertTypes/" + assertTypeId + "/expectedResults/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<ExpectedResult> GetDataByAssertTypeIdPageable(int assertTypeId, string sortExpression,
            int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/assertTypes/" + assertTypeId + "/expectedResults" + "?assertTypeId=" +
                                    assertTypeId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" +
                                    pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public ICollection<ExpectedResult> GetDataByExpectedResultTypeId(int expectedResultTypeId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/expectedResultTypes/" + expectedResultTypeId + "/expectedResults/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<ExpectedResult> GetDataByExpectedResultTypeIdPageable(int expectedResultTypeId,
            string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/expectedResultTypes/" + expectedResultTypeId + "/expectedResults" +
                                    "?expectedResultTypeId=" + expectedResultTypeId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public ICollection<ExpectedResult> GetDataByTestId(int testId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/tests/" + testId + "/expectedResults/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<ExpectedResult> GetDataByTestIdPageable(int testId, string sortExpression, int page,
            int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/tests/" + testId + "/expectedResults" + "?testId=" + testId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<ExpectedResult>>(responseString);
                return returnValue;
            }
        }

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
    }
}