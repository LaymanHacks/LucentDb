
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class Project_ConnectionList :  Collection<Project_Connection>
    {
        public Project_Connection First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class Project_Connection{
      
        private Int32 _projectId;
        private Int32 _connectionId; 
        private Connection _connection; 
        private Project _project;  

      public Project_Connection() : base()
      {
      }

      public Project_Connection(Int32 projectId, Int32 connectionId) : base()
      {
          
           _projectId = projectId;
           _connectionId = connectionId;
      }
  
    
        /// <summary>
        /// Public Property ProjectId
        /// </summary>
        /// <returns>ProjectId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 ProjectId
        {
            get{return this._projectId;}
            set{this._projectId = value;}
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

        [DataMember]
        public virtual Connection Connection 
        {
          get { return  _connection;}
          set { _connection = value;}
        }
  
      
        [DataMember]
        public virtual Project Project 
        {
          get { return  _project;}
          set { _project = value;}
        }
  
      
    }
 }     
