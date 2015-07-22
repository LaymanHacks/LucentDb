
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class AssertTypeList :  Collection<AssertType>
    {
        public AssertType First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class AssertType{
      
        private Int32 _id;
        private String _name;
        private Collection<ExpectedResult> _expectedResults;  

      public AssertType() : base()
      {
      }

      public AssertType(Int32 id, String name) : base()
      {
          
           _id = id;
           _name = name;
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

        [DataMember]
        public virtual Collection<ExpectedResult> ExpectedResults 
        {
          get { return  _expectedResults;}
          set { _expectedResults = value;}
        }
  
      
    }
 }     
