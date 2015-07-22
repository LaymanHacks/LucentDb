
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace LucentDb.Domain.Entities
{
    [Serializable]
    public partial class RunHistoryList :  Collection<RunHistory>
    {
        public RunHistory First()
        {
          return base.Count > 0 ? base[0] : null;
        }
    }
    
    [DataContract]
    public partial class RunHistory{
      
        private Int64 _id;
        private Int32 _testId;
        private DateTime _runDateTime;
        private Boolean _isPass;
        private String _runLog;
        private String _resultString; 
        private Test _test;  

      public RunHistory() : base()
      {
      }

      public RunHistory(Int64 id, Int32 testId, DateTime runDateTime, Boolean isPass, String runLog, String resultString) : base()
      {
          
           _id = id;
           _testId = testId;
           _runDateTime = runDateTime;
           _isPass = isPass;
           _runLog = runLog;
           _resultString = resultString;
      }
  
    
        /// <summary>
        /// Public Property Id
        /// </summary>
        /// <returns>Id as Int64</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Int64 Id
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
        /// Public Property RunDateTime
        /// </summary>
        /// <returns>RunDateTime as DateTime</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual DateTime RunDateTime
        {
            get{return this._runDateTime;}
            set{this._runDateTime = value;}
        }

        /// <summary>
        /// Public Property IsPass
        /// </summary>
        /// <returns>IsPass as Boolean</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual Boolean IsPass
        {
            get{return this._isPass;}
            set{this._isPass = value;}
        }

        /// <summary>
        /// Public Property RunLog
        /// </summary>
        /// <returns>RunLog as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String RunLog
        {
            get{return this._runLog;}
            set{this._runLog = value;}
        }

        /// <summary>
        /// Public Property ResultString
        /// </summary>
        /// <returns>ResultString as String</returns>
        /// <remarks></remarks>
        [DataMember()]
        public virtual String ResultString
        {
            get{return this._resultString;}
            set{this._resultString = value;}
        }

        [DataMember]
        public virtual Test Test 
        {
          get { return  _test;}
          set { _test = value;}
        }
  
      
    }
 }     
