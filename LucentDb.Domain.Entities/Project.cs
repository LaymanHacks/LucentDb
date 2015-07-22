
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class ProjectList :  Collection<Project>
    {
        public Project First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class Project{
      
        private Int32 _projectId;
        private String _name;
        private Boolean _isActive;
        private Collection<Connection> _connections;
        private Collection<Test> _tests;
        private Collection<TestGroup> _testGroups;  

      public Project() : base()
      {
      }

      public Project(Int32 projectId, String name, Boolean isActive) : base()
      {
          
           _projectId = projectId;
           _name = name;
           _isActive = isActive;
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
        public virtual Collection<Connection> Connections 
        {
          get { return  _connections;}
          set { _connections = value;}
        }
  
      
        [DataMember]
        public virtual Collection<Test> Tests 
        {
          get { return  _tests;}
          set { _tests = value;}
        }
  
      
        [DataMember]
        public virtual Collection<TestGroup> TestGroups 
        {
          get { return  _testGroups;}
          set { _testGroups = value;}
        }
  
      
    }
 }     
