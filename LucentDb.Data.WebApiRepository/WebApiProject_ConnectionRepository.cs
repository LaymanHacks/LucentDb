using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;
using LucentDb.Web;
using Newtonsoft.Json;

namespace LucentDb.Data.WebApiRepository
{
    [DataObject(true)]
    public class WebApiProject_ConnectionRepository : IProject_ConnectionRepository, IDisposable
    {
        private const string UrlBase = "/api/project_Connection";
        private readonly string _baseAddress;
        private bool _disposedValue;
        private HttpMessageHandler _messageHandler;

        public WebApiProject_ConnectionRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICollection<Project_Connection> GetData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public void Update(int projectId, int connectionId, int original_ProjectId, int original_ConnectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var projectConnectionValues = new Dictionary<string, string>
                {
                    {"ProjectId", projectId.ToString()},
                    {"ConnectionId", connectionId.ToString()},
                    {"Original_ProjectId", original_ProjectId.ToString()},
                    {"Original_ConnectionId", original_ConnectionId.ToString()}
                };
                var urlParams = new UrlParameterEncodedContent(projectConnectionValues);

                var response = client.PutAsync(UrlBase + urlParams, null).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(Project_Connection project_Connection, int original_ProjectId, int original_ConnectionId)
        {
            Update(project_Connection.ProjectId, project_Connection.ConnectionId, original_ProjectId,
                original_ConnectionId);
        }

        public void Delete(int projectId, int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.DeleteAsync(UrlBase + "?projectId=" + projectId + "&connectionId=" + connectionId).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Delete(Project_Connection project_Connection)
        {
            Delete(project_Connection.ProjectId, project_Connection.ConnectionId);
        }

        public ICollection<Project_Connection> Insert(int projectId, int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var project_Connection = new Project_Connection
                {
                    ProjectId = projectId,
                    ConnectionId = connectionId
                };
                var response = client.PostAsync(UrlBase, project_Connection, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Project_Connection> Insert(Project_Connection project_Connection)
        {
            return Insert(project_Connection.ProjectId, project_Connection.ConnectionId);
        }

        public PagedResult<Project_Connection> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Project_Connection> GetDataByProjectIdConnectionId(int projectId, int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Project_Connection> GetDataByConnectionId(int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/project_Connection/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Project_Connection> GetDataByConnectionIdPageable(int connectionId, string sortExpression,
            int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "/project_Connection" + "?connectionId=" + connectionId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Project_Connection> GetDataByProjectId(int projectId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/project_Connection/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Project_Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Project_Connection> GetDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "/project_Connection" + "?projectId=" + projectId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Project_Connection>>(responseString);
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