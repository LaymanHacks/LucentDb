
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class TestList :  Collection<Test>
    {
        public Test First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class Test{
      
        private Int32 _id;
        private Int32 _testTypeId;
        private Nullable<Int32> _projectId;
        private Nullable<Int32> _groupId;
        private String _name;
        private String _testValue;
        private Boolean _isActive;
        private Collection<ExpectedResult> _expectedResults;
        private Collection<RunHistory> _runHistories; 
        private Project _project; 
        private TestGroup _testGroup; 
        private TestType _testType;  

      public Test() : base()
      {
      }

      public Test(Int32 id, Int32 testTypeId, Nullable<Int32> projectId, Nullable<Int32> groupId, String name, String testValue, Boolean isActive) : base()
      {
          
           _id = id;
           _testTypeId = testTypeId;
           _projectId = projectId;
           _groupId = groupId;
           _name = name;
           _testValue = testValue;
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
        /// Public Property TestTypeId
        /// </summary>
        /// <returns>TestTypeId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 TestTypeId
        {
            get{return this._testTypeId;}
            set{this._testTypeId = value;}
        }

        /// <summary>
        /// Public Property ProjectId
        /// </summary>
        /// <returns>ProjectId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> ProjectId
        {
            get{return this._projectId;}
            set{this._projectId = value;}
        }

        /// <summary>
        /// Public Property GroupId
        /// </summary>
        /// <returns>GroupId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> GroupId
        {
            get{return this._groupId;}
            set{this._groupId = value;}
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
        /// Public Property TestValue
        /// </summary>
        /// <returns>TestValue as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String TestValue
        {
            get{return this._testValue;}
            set{this._testValue = value;}
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
        public virtual Collection<ExpectedResult> ExpectedResults 
        {
          get { return  _expectedResults;}
          set { _expectedResults = value;}
        }
  
      
        [DataMember]
        public virtual Collection<RunHistory> RunHistories 
        {
          get { return  _runHistories;}
          set { _runHistories = value;}
        }
  
      
        [DataMember]
        public virtual Project Project 
        {
          get { return  _project;}
          set { _project = value;}
        }
  
      
        [DataMember]
        public virtual TestGroup TestGroup 
        {
          get { return  _testGroup;}
          set { _testGroup = value;}
        }
  
      
        [DataMember]
        public virtual TestType TestType 
        {
          get { return  _testType;}
          set { _testType = value;}
        }
  
      
    }
 }     
