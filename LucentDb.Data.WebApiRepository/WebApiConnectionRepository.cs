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
    public class WebApiConnectionRepository : IConnectionRepository, IDisposable
    {
        private const string UrlBase = "/api/connections";
        private readonly string _baseAddress;
        private bool _disposedValue;
        private HttpMessageHandler _messageHandler;

        public WebApiConnectionRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<Connection> GetData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public void Update(int connectionProviderId, string name, string connectionString, bool isActive,
            int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var connection = new Connection
                {
                    ConnectionProviderId = connectionProviderId,
                    Name = name,
                    ConnectionString = connectionString,
                    IsActive = isActive,
                    ConnectionId = connectionId
                };
                var response = client.PutAsync(UrlBase, connection, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(Connection connection)
        {
            Update(connection.ConnectionProviderId, connection.Name, connection.ConnectionString, connection.IsActive,
                connection.ConnectionId);
        }

        public void Delete(int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.DeleteAsync(UrlBase + "?connectionId=" + connectionId).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Delete(Connection connection)
        {
            Delete(connection.ConnectionId);
        }

        public int Insert(int connectionProviderId, string name, string connectionString, bool isActive)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var connection = new Connection
                {
                    ConnectionProviderId = connectionProviderId,
                    Name = name,
                    ConnectionString = connectionString,
                    IsActive = isActive
                };
                var response = client.PostAsync(UrlBase, connection, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt32(responseString);
                return returnValue;
            }
        }

        public int Insert(Connection connection)
        {
            return Insert(connection.ConnectionProviderId, connection.Name, connection.ConnectionString,
                connection.IsActive);
        }

        public PagedResult<Connection> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetDataByConnectionId(int connectionId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/connections/" + connectionId).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetActiveData()
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all/active").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync(UrlBase + "/active" + "?sortExpression=" + sortExpression + "&page=" + page +
                                    "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetConnectionsForProjectByProjectId(int projectId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId + "/connections/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetConnectionsForProjectByProjectIdPageable(int projectId, string sortExpression,
            int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/projects/" + projectId + "/connections" + "?projectId=" + projectId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetDataByConnectionProviderId(int connectionProviderId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/all").Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetDataByConnectionProviderIdPageable(int connectionProviderId,
            string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections" +
                                    "?connectionProviderId=" + connectionProviderId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(responseString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetActiveDataByConnectionProviderId(int connectionProviderId)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/all/active")
                        .Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<Collection<Connection>>(responseString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetActiveDataByConnectionProviderIdPageable(int connectionProviderId,
            string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler, false))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/active" +
                                    "?connectionProviderId=" + connectionProviderId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                response.EnsureSuccessStatusCode();
                var responseString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(responseString);
                return returnValue;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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