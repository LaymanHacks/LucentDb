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
    public class WebApiConnectionProviderRepository : IConnectionProviderRepository, IDisposable
    {
        private const string UrlBase = "/api/connectionProviders";
        private readonly string _baseAddress;
        private HttpMessageHandler _messageHandler;

        public WebApiConnectionProviderRepository(string baseAddress, HttpMessageHandler messageHandler = null)
        {
            _baseAddress = !baseAddress.EndsWith("/") ? baseAddress + "/" : baseAddress;
            _messageHandler = messageHandler ?? new HttpClientHandler();
        }

        public ICollection<ConnectionProvider> GetData()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(UrlBase + "/all").Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<ConnectionProvider>>(resultString);
                return returnValue;
            }
        }

        public void Update(string name, string value, int id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var connectionProvider = new ConnectionProvider(id, name, value);
                var response = client.PutAsync(UrlBase, connectionProvider, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void Update(ConnectionProvider connectionProvider)
        {
            Update(connectionProvider.Name, connectionProvider.Value, connectionProvider.Id);
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

        public void Delete(ConnectionProvider connectionProvider)
        {
            Delete(connectionProvider.Id);
        }

        public int Insert(string name, string value)
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

        public int Insert(ConnectionProvider connectionProvider)
        {
            return Insert(connectionProvider.Name, connectionProvider.Value);
        }

        public PagedResult<ConnectionProvider> GetDataPageable(string sortExpression, int page, int pageSize)
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
                var returnValue = JsonConvert.DeserializeObject<PagedResult<ConnectionProvider>>(resultString);
                return returnValue;
            }
        }

        public ICollection<ConnectionProvider> GetDataById(int id)
        {
            using (var client = new HttpClient(_messageHandler))
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/connectionProviders/" + id).Result;
                if (!response.IsSuccessStatusCode) return null;
                var resultString = response.Content.ReadAsStringAsync().Result;
                var returnValue = JsonConvert.DeserializeObject<ICollection<ConnectionProvider>>(resultString);
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