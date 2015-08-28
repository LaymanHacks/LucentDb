using System;
using System.Linq;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Domain
{
    public class ConnectionFactory
    {
        private readonly IConnectionProviderRepository _connectionProviderRepository;
        private readonly IConnectionRepository _connectionRepository;

        public ConnectionFactory(IConnectionRepository connectionRepository,
            IConnectionProviderRepository connectionProviderRepository)
        {
            _connectionRepository = connectionRepository;
            _connectionProviderRepository = connectionProviderRepository;
        }

        public Connection CreateConnection(int connectionId)
        {
            var connection = _connectionRepository.GetDataByConnectionId(connectionId).FirstOrDefault();
            if (connection == null) throw new Exception("Connection not found.");

            connection.ConnectionProvider =
                _connectionProviderRepository.GetDataById(connection.ConnectionProviderId).FirstOrDefault();
            if (connection == null) throw new Exception("Connection Provider not found.");
            return connection;
        }
    }
}