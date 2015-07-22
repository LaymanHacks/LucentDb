
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class ExpectedResultList :  Collection<ExpectedResult>
    {
        public ExpectedResult First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class ExpectedResult{
      
        private Int32 _id;
        private Int32 _testId;
        private Nullable<Int32> _expectedResultTypeId;
        private Nullable<Int32> _assertTypeId;
        private String _expectedValue;
        private Int32 _resultIndex; 
        private AssertType _assertType; 
        private ExpectedResultType _expectedResultType; 
        private Test _test;  

      public ExpectedResult() : base()
      {
      }

      public ExpectedResult(Int32 id, Int32 testId, Nullable<Int32> expectedResultTypeId, Nullable<Int32> assertTypeId, String expectedValue, Int32 resultIndex) : base()
      {
          
           _id = id;
           _testId = testId;
           _expectedResultTypeId = expectedResultTypeId;
           _assertTypeId = assertTypeId;
           _expectedValue = expectedValue;
           _resultIndex = resultIndex;
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
        /// Public Property TestId
        /// </summary>
        /// <returns>TestId as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 TestId
        {
            get{return this._testId;}
            set{this._testId = value;}
        }

        /// <summary>
        /// Public Property ExpectedResultTypeId
        /// </summary>
        /// <returns>ExpectedResultTypeId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> ExpectedResultTypeId
        {
            get{return this._expectedResultTypeId;}
            set{this._expectedResultTypeId = value;}
        }

        /// <summary>
        /// Public Property AssertTypeId
        /// </summary>
        /// <returns>AssertTypeId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Nullable<Int32> AssertTypeId
        {
            get{return this._assertTypeId;}
            set{this._assertTypeId = value;}
        }

        /// <summary>
        /// Public Property ExpectedValue
        /// </summary>
        /// <returns>ExpectedValue as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String ExpectedValue
        {
            get{return this._expectedValue;}
            set{this._expectedValue = value;}
        }

        /// <summary>
        /// Public Property ResultIndex
        /// </summary>
        /// <returns>ResultIndex as Int32</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int32 ResultIndex
        {
            get{return this._resultIndex;}
            set{this._resultIndex = value;}
        }

        [DataMember]
        public virtual AssertType AssertType 
        {
          get { return  _assertType;}
          set { _assertType = value;}
        }
  
      
        [DataMember]
        public virtual ExpectedResultType ExpectedResultType 
        {
          get { return  _expectedResultType;}
          set { _expectedResultType = value;}
        }
  
      
        [DataMember]
        public virtual Test Test 
        {
          get { return  _test;}
          set { _test = value;}
        }
  
      
    }
 }     
