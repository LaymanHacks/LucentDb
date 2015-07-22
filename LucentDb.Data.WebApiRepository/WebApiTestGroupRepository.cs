
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
    public class WebApiTestGroupRepository : ITestGroupRepository, IDisposable
    {

        private const string UrlBase = "/api/testGroups";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiTestGroupRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<TestGroup> GetData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<TestGroup>>(responseString);
                return returnValue;
            }
        }

        public void Update(Int32 projectId, string name, Boolean isActive, Int32 id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var testGroup = new TestGroup()
                    {
                    ProjectId = projectId, 
                    Name = name, 
                    IsActive = isActive, 
                    Id = id
                    };
                var response = client.PutAsync(UrlBase, testGroup, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(TestGroup testGroup)
        {
            Update(testGroup.ProjectId, testGroup.Name, testGroup.IsActive, testGroup.Id);
        }


        public void Delete(Int32 id)
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

        public void Delete(TestGroup testGroup)
        {
            Delete(testGroup.Id);
        }


        public Int32 Insert(Int32 projectId, string name, Boolean isActive)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var testGroup = new TestGroup()
                    {
                    ProjectId = projectId, 
                    Name = name, 
                    IsActive = isActive
                    };
                var response = client.PostAsync(UrlBase, testGroup, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue  = Convert.ToInt32(responseString);
                return returnValue;
            }
        }

        public Int32 Insert(TestGroup testGroup)
        {
            return Insert(testGroup.ProjectId, testGroup.Name, testGroup.IsActive);
        }


        public PagedResult<TestGroup> GetDataPageable(string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "?sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestGroup>>(responseString);
                return returnValue;
            }
        }


        public ICollection<TestGroup> GetDataById(Int32 id)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/testGroups/" + id).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<TestGroup>>(responseString);
                return returnValue;
            }
        }

        public ICollection<TestGroup> GetActiveData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all/active").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<TestGroup>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<TestGroup> GetActiveDataPageable(string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/active" + "?sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestGroup>>(responseString);
                return returnValue;
            }
        }


        public ICollection<TestGroup> GetDataByProjectId(Int32 projectId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId  + "/testGroups/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<TestGroup>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<TestGroup> GetDataByProjectIdPageable(Int32 projectId, string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId  + "/testGroups" + "?projectId=" + projectId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestGroup>>(responseString);
                return returnValue;
            }
        }


        public ICollection<TestGroup> GetActiveDataByProjectId(Int32 projectId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId  + "/testGroups/all/active").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<TestGroup>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<TestGroup> GetActiveDataByProjectIdPageable(Int32 projectId, string sortExpression, Int32 page, Int32 pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId  + "/testGroups/active" + "?projectId=" + projectId + "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<TestGroup>>(responseString);
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
