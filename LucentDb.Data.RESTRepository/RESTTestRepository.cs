using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;
using Newtonsoft.Json;

namespace LucentDb.Data.RESTRepository
{
    public class RESTTestRepository : ITestRepository
    {

        private string _urlBase = "/api/tests";
        private string _baseAddress = "http://localhost:9000/";

        public  ICollection<Test> GetData()
        {
            ICollection<Test> testResult;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response =  client.GetAsync(_urlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var data =  response.Content.ReadAsStringAsync().Result;
                testResult =  JsonConvert.DeserializeObject<ICollection<Test>>(data);
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

        public ICollection<Test> GetActiveDataByGroupIdPageable(int groupId, string sortExpression, int page, int pageSize)
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

        public ICollection<Test> GetActiveDataByProjectIdPageable(int projectId, string sortExpression, int page, int pageSize)
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

        public ICollection<Test> GetActiveDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page, int pageSize)
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

        public ICollection<Test> GetDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page, int pageSize)
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

        public void Update(int testTypeId, int? projectId, int? groupId, string name, string testValue, bool isActive, int id)
        {
            throw new NotImplementedException();
        }
    }
}
