using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;
using Newtonsoft.Json;

namespace LucentDb.Data.WebApiClient
{
    public class WebApiTestRepository : ITestRepository
    {
        private const string UrlBase = "api/tests";
        private readonly string _baseAddress;
        private readonly HttpMessageHandler _messageHandler;

        public  WebApiTestRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<Test> GetData()
        {
            ICollection<Test> testResult;
            using (var client = new HttpJsonClient(_baseAddress, _messageHandler))
            {
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var data = response.Content.ReadAsStringAsync().Result;
                testResult = JsonConvert.DeserializeObject<ICollection<Test>>(data);
            }
            return testResult;
        }

        public void Delete(Test test)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveData()
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByGroupIdPageable(int groupId, string sortExpression, int page,
            int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetActiveDataByGroupIdRowCount(int groupId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetActiveDataByProjectIdRowCount(int projectId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByTestTypeId(int testTypeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page,
            int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetActiveDataByTestTypeIdRowCount(int testTypeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetActiveDataRowCount()
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByGroupIdPageable(int groupId, string sortExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetDataByGroupIdRowCount(int groupId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByProjectId(int projectId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByProjectIdPageable(int projectId, string sortExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetDataByProjectIdRowCount(int projectId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByTestTypeId(int testTypeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page,
            int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetDataByTestTypeIdRowCount(int testTypeId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Test> GetDataPageable(string sortExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetRowCount()
        {
            throw new NotImplementedException();
        }

        public int Insert(Test test)
        {
            throw new NotImplementedException();
        }

        public int Insert(int testTypeId, int? projectId, int? groupId, string name, string testValue, bool isActive)
        {
            throw new NotImplementedException();
        }

        public void Update(Test test)
        {
            throw new NotImplementedException();
        }

        public void Update(int testTypeId, int? projectId, int? groupId, string name, string testValue, bool isActive,
            int id)
        {
            throw new NotImplementedException();
        }
    }

    public class HttpJsonClient : HttpClient
    {
        public HttpJsonClient(string baseAddress, HttpMessageHandler httpMessageHandler)
        {
            BaseAddress = new Uri(baseAddress);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpJsonClient(string baseAddress) : this(baseAddress, new HttpClientHandler())
        {
        }
    }
}