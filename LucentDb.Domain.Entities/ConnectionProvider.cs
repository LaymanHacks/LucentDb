using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class ConnectionProviderList : Collection<ConnectionProvider>
    {
        public ConnectionProvider First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class ConnectionProvider
    {
        private int _id;
        private string _name;
        private string _value;

        public ConnectionProvider()
        {
        }

        public ConnectionProvider(int id, string name, string value)
        {
            _id = id;
            _name = name;
            _value = value;
        }

        /// <summary>
        ///     Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
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
        ///     Public Property Value
        /// </summary>
        /// <returns>Value as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [DataMember]
        public virtual Collection<Connection> Connections { get; set; }
    }
}