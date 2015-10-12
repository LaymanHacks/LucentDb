

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
        private int? _connectionId;
        private int? _groupId;
        private long _id;
        private bool _isValid;
        private int? _projectId;
        private DateTime _runDateTime;
        private string _runLog;
        private int? _testId;
        private decimal? _totalDuration;

        public RunHistory()
        {
        }

        public RunHistory(long id, int? testId, int? projectId, int? groupId, int? connectionId, DateTime runDateTime,
            decimal? totalDuration, bool isValid, string runLog)
        {
            _id = id;
            _testId = testId;
            _projectId = projectId;
            _groupId = groupId;
            _connectionId = connectionId;
            _runDateTime = runDateTime;
            _totalDuration = totalDuration;
            _isValid = isValid;
            _runLog = runLog;
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
        /// <returns>TestId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }

        /// <summary>
        ///     Public Property ProjectId
        /// </summary>
        /// <returns>ProjectId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        /// <summary>
        ///     Public Property GroupId
        /// </summary>
        /// <returns>GroupId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        /// <summary>
        ///     Public Property ConnectionId
        /// </summary>
        /// <returns>ConnectionId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? ConnectionId
        {
            get { return _connectionId; }
            set { _connectionId = value; }
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
        ///     Public Property TotalDuration
        /// </summary>
        /// <returns>TotalDuration as Nullable<Decimal></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual decimal? TotalDuration
        {
            get { return _totalDuration; }
            set { _totalDuration = value; }
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

        [DataMember]
        public virtual Collection<RunHistoryDetail> RunHistoryDetails { get; set; }

        [DataMember]
        public virtual Project Project { get; set; }

        [DataMember]
        public virtual Test Test { get; set; }

        [DataMember]
        public virtual TestGroup TestGroup { get; set; }
    }
}