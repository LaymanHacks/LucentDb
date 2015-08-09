
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class ConnectionList :  Collection<Connection>
    {
        public Connection First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class Connection{
      
        private Int32 _connectionId;
        private int _connectionProviderId;
        private String _name;
        private String _connectionString;
        private Boolean _isActive;
        private Collection<Project> _projects; 
        private ConnectionProvider _connectionProvider;  

      public Connection() : base()
      {
      }

      public Connection(Int32 connectionId, int connectionProviderId, String name, String connectionString, Boolean isActive) : base()
      {
          
           _connectionId = connectionId;
           _connectionProviderId = connectionProviderId;
           _name = name;
           _connectionString = connectionString;
           _isActive = isActive;
      }
  
    
        /// <summary>
        /// Public Property ConnectionId
        /// </summary>
        /// <returns>ConnectionId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 ConnectionId
        {
            get{return this._connectionId;}
            set{this._connectionId = value;}
        }

        /// <summary>
        /// Public Property ConnectionProviderId
        /// </summary>
        /// <returns>ConnectionProviderId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual int ConnectionProviderId
        {
            get{return this._connectionProviderId;}
            set{this._connectionProviderId = value;}
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
        /// Public Property ConnectionString
        /// </summary>
        /// <returns>ConnectionString as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String ConnectionString
        {
            get{return this._connectionString;}
            set{this._connectionString = value;}
        }

        /// <summary>
        /// Public Property IsActive
        /// </summary>
        /// <returns>IsActive as Boolean</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Boolean IsActive
        {
            get{return this._isActive;}
            set{this._isActive = value;}
        }

        [DataMember]
        public virtual Collection<Project> Projects 
        {
          get { return  _projects;}
          set { _projects = value;}
        }
  
      
        [DataMember]
        public virtual ConnectionProvider ConnectionProvider 
        {
          get { return  _connectionProvider;}
          set { _connectionProvider = value;}
        }
  
      
    }
 }     
