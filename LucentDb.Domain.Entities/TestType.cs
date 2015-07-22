
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class TestTypeList :  Collection<TestType>
    {
        public TestType First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class TestType{
      
        private Int32 _id;
        private String _name;
        private String _testValidatorType;
        private Boolean _isActive;
        private Collection<Test> _tests;  

      public TestType() : base()
      {
      }

      public TestType(Int32 id, String name, String testValidatorType, Boolean isActive) : base()
      {
          
           _id = id;
           _name = name;
           _testValidatorType = testValidatorType;
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
        /// Public Property TestValidatorType
        /// </summary>
        /// <returns>TestValidatorType as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String TestValidatorType
        {
            get{return this._testValidatorType;}
            set{this._testValidatorType = value;}
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
  
      
    }
 }     
