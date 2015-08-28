using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class RunHistoryList : Collection<RunHistory>
    {
        public RunHistory First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class RunHistory
    {
        private long _id;
        private bool _isValid;
        private string _resultString;
        private DateTime _runDateTime;
        private string _runLog;
        private int _testId;

        public RunHistory()
        {
        }

        public RunHistory(long id, int testId, DateTime runDateTime, bool isValid, string runLog, string resultString)
        {
            _id = id;
            _testId = testId;
            _runDateTime = runDateTime;
            _isValid = isValid;
            _runLog = runLog;
            _resultString = resultString;
        }

        /// <summary>
        ///     Public Property Id
        /// </summary>
        /// <returns>Id as Int64</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        ///     Public Property TestId
        /// </summary>
        /// <returns>TestId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }

        /// <summary>
        ///     Public Property RunDateTime
        /// </summary>
        /// <returns>RunDateTime as DateTime</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual DateTime RunDateTime
        {
            get { return _runDateTime; }
            set { _runDateTime = value; }
        }

        /// <summary>
        ///     Public Property IsValid
        /// </summary>
        /// <returns>IsValid as Boolean</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        /// <summary>
        ///     Public Property RunLog
        /// </summary>
        /// <returns>RunLog as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string RunLog
        {
            get { return _runLog; }
            set { _runLog = value; }
        }

        /// <summary>
        ///     Public Property ResultString
        /// </summary>
        /// <returns>ResultString as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string ResultString
        {
            get { return _resultString; }
            set { _resultString = value; }
        }

        [DataMember]
        public virtual Test Test { get; set; }
    }
}