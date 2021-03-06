//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

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
    public class WebApiTestValueTypeRepository : ITestValueTypeRepository, IDisposable
    {
        private const string UrlBase = "/api/testValueTypes";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiTestValueTypeRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<TestValueType> GetData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<TestValueType>>(resultString);
                return returnValue;
            }
        }

        public void Update(int testTypeId, string name, bool isActive, int id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var testValueType = new TestValueType(id, testTypeId, name, isActive);
                var response = client.PutAsync(UrlBase, testValueType, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(TestValueType testValueType)
        {
            Update(testValueType.TestTypeId, testValueType.Name, testValueType.IsActive, testValueType.Id);
        }


        public void Delete(int id)
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

        public void Delete(TestValueType testValueType)
        {
            Delete(testValueType.Id);
        }


        public int Insert(int testTypeId, string name, bool isActive)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase).Result;
                if (!response.IsSuccessStatusCode) return 0;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt32(resultString);
                return returnValue;
            }
        }

        public int Insert(TestValueType testValueType)
        {
            return Insert(testValueType.TestTypeId, testValueType.Name, testValueType.IsActive);
        }


        public PagedResult<TestValueType> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestValueType>>(resultString);
                return returnValue;
            }
        }


        public ICollection<TestValueType> GetDataById(int id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/testValueTypes/" + id).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<TestValueType>>(resultString);
                return returnValue;
            }
        }

        public ICollection<TestValueType> GetActiveData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all/active").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<TestValueType>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<TestValueType> GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "/active" + "?sortExpression=" + sortExpression + "&page=" + page +
                                    "&pageSize=" + pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestValueType>>(resultString);
                return returnValue;
            }
        }


        public ICollection<TestValueType> GetDataByTestTypeId(int testTypeId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/testTypes/" + testTypeId + "/testValueTypes/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<TestValueType>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<TestValueType> GetDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page,
            int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/testTypes/" + testTypeId + "/testValueTypes" + "?testTypeId=" + testTypeId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestValueType>>(resultString);
                return returnValue;
            }
        }


        public ICollection<TestValueType> GetActiveDataByTestTypeId(int testTypeId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/testTypes/" + testTypeId + "/testValueTypes/all/active").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<TestValueType>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<TestValueType> GetActiveDataByTestTypeIdPageable(int testTypeId, string sortExpression,
            int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/testTypes/" + testTypeId + "/testValueTypes/active" + "?testTypeId=" +
                                    testTypeId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" +
                                    pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestValueType>>(resultString);
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