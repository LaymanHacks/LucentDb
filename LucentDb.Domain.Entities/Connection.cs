using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class ConnectionList : Collection<Connection>
    {
        public Connection First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class Connection
    {
        private int _connectionId;
        private int _connectionProviderId;
        private string _connectionString;
        private bool _isActive;
        private string _name;

        public Connection()
        {
        }

        public Connection(int connectionId, int connectionProviderId, string name, string connectionString,
            bool isActive)
        {
            _connectionId = connectionId;
            _connectionProviderId = connectionProviderId;
            _name = name;
            _connectionString = connectionString;
            _isActive = isActive;
        }

        /// <summary>
        ///     Public Property ConnectionId
        /// </summary>
        /// <returns>ConnectionId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int ConnectionId
        {
            get { return _connectionId; }
            set { _connectionId = value; }
        }

        /// <summary>
        ///     Public Property ConnectionProviderId
        /// </summary>
        /// <returns>ConnectionProviderId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int ConnectionProviderId
        {
            get { return _connectionProviderId; }
            set { _connectionProviderId = value; }
        }

        /// <summary>
        ///     Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        ///     Public Property ConnectionString
        /// </summary>
        /// <returns>ConnectionString as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        ///     Public Property IsActive
        /// </summary>
        /// <returns>IsActive as Boolean</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [DataMember]
        public virtual Collection<Project> Projects { get; set; }

        [DataMember]
        public virtual ConnectionProvider ConnectionProvider { get; set; }
    }
}