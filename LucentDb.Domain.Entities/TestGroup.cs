
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class TestGroupList :  Collection<TestGroup>
    {
        public TestGroup First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class TestGroup{
      
        private Int32 _id;
        private Int32 _projectId;
        private String _name;
        private Boolean _isActive;
        private Collection<Test> _tests; 
        private Project _project;  

      public TestGroup() : base()
      {
      }

      public TestGroup(Int32 id, Int32 projectId, String name, Boolean isActive) : base()
      {
          
           _id = id;
           _projectId = projectId;
           _name = name;
           _isActive = isActive;
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
        public virtual Collection<Test> Tests 
        {
          get { return  _tests;}
          set { _tests = value;}
        }
  
      
        [DataMember]
        public virtual Project Project 
        {
          get { return  _project;}
          set { _project = value;}
        }
  
      
    }
 }     
