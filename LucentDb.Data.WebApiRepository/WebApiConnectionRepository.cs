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
    public class WebApiConnectionRepository : IConnectionRepository, IDisposable
    {
        private const string UrlBase = "/api/connections";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiConnectionRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<Connection> GetData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public void Update(int projectId, int connectionProviderId, string name, string connectionString, bool isDefault,
            bool isActive, int connectionId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var connection = new Connection(connectionId, projectId, connectionProviderId, name, connectionString,
                    isDefault, isActive);
                var response = client.PutAsync(UrlBase, connection, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(Connection connection)
        {
            Update(connection.ProjectId, connection.ConnectionProviderId, connection.Name, connection.ConnectionString,
                connection.IsDefault, connection.IsActive, connection.ConnectionId);
        }

        public void Delete(int connectionId)
        {
            using (var client = new HttpClient(_messageHandler))
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

        public int Insert(int? projectId, int connectionProviderId, string name, string connectionString, bool isDefault,
            bool isActive)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase).Result;
                if (!response.IsSuccessStatusCode) return -1;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = Convert.ToInt32(resultString);
                return returnValue;
            }
        }

        public int Insert(Connection connection)
        {
            return Insert(connection.ProjectId, connection.ConnectionProviderId, connection.Name,
                connection.ConnectionString, connection.IsDefault, connection.IsActive);
        }

        public PagedResult<Connection> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetDataByConnectionId(int connectionId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetActiveData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all/active").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetActiveDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetDataByConnectionProviderId(int connectionProviderId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetDataByConnectionProviderIdPageable(int connectionProviderId,
            string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections" +
                                    "?connectionProviderId=" + connectionProviderId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetActiveDataByConnectionProviderId(int connectionProviderId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/all/active")
                        .Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetActiveDataByConnectionProviderIdPageable(int connectionProviderId,
            string sortExpression, int page, int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/connectionProviders/" + connectionProviderId + "/connections/active" +
                                    "?connectionProviderId=" + connectionProviderId + "&sortExpression=" +
                                    sortExpression + "&page=" + page + "&pageSize=" + pageSize).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetDataByProjectId(int projectId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId + "/connections/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/projects/" + projectId + "/connections" + "?projectId=" + projectId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
                return returnValue;
            }
        }

        public ICollection<Connection> GetActiveDataByProjectId(int projectId)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/projects/" + projectId + "/connections/all/active").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<Connection>>(resultString);
                return returnValue;
            }
        }

        public PagedResult<Connection> GetActiveDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response =
                    client.GetAsync("/api/projects/" + projectId + "/connections/active" + "?projectId=" + projectId +
                                    "&sortExpression=" + sortExpression + "&page=" + page + "&pageSize=" + pageSize)
                        .Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<PagedResult<Connection>>(resultString);
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