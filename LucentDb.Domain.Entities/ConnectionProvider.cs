
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class ConnectionProviderList :  Collection<ConnectionProvider>
    {
        public ConnectionProvider First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class ConnectionProvider{
      
        private Int32 _id;
        private String _name;
        private String _value;
        private Collection<Connection> _connections;  

      public ConnectionProvider() : base()
      {
      }

      public ConnectionProvider(Int32 id, String name, String value) : base()
      {
          
           _id = id;
           _name = name;
           _value = value;
      }
  
    
        /// <summary>
        /// Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 Id
        {
            get{return this._id;}
            set{this._id = value;}
        }

        /// <summary>
        /// Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String Name
        {
            get{return this._name;}
            set{this._name = value;}
        }

        /// <summary>
        /// Public Property Value
        /// </summary>
        /// <returns>Value as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String Value
        {
            get{return this._value;}
            set{this._value = value;}
        }

        [DataMember]
        public virtual Collection<Connection> Connections 
        {
          get { return  _connections;}
          set { _connections = value;}
        }
  
      
    }
 }     
