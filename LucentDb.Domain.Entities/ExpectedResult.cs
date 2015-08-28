using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class ExpectedResultList : Collection<ExpectedResult>
    {
        public ExpectedResult First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class ExpectedResult
    {
        private int? _assertTypeId;
        private int? _expectedResultTypeId;
        private string _expectedValue;
        private int _id;
        private int _resultIndex;
        private int _testId;

        public ExpectedResult()
        {
        }

        public ExpectedResult(int id, int testId, int? expectedResultTypeId, int? assertTypeId, string expectedValue,
            int resultIndex)
        {
            _id = id;
            _testId = testId;
            _expectedResultTypeId = expectedResultTypeId;
            _assertTypeId = assertTypeId;
            _expectedValue = expectedValue;
            _resultIndex = resultIndex;
        }

        /// <summary>
        ///     Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int Id
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
        ///     Public Property ExpectedResultTypeId
        /// </summary>
        /// <returns>ExpectedResultTypeId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? ExpectedResultTypeId
        {
            get { return _expectedResultTypeId; }
            set { _expectedResultTypeId = value; }
        }

        /// <summary>
        ///     Public Property AssertTypeId
        /// </summary>
        /// <returns>AssertTypeId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? AssertTypeId
        {
            get { return _assertTypeId; }
            set { _assertTypeId = value; }
        }

        /// <summary>
        ///     Public Property ExpectedValue
        /// </summary>
        /// <returns>ExpectedValue as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string ExpectedValue
        {
            get { return _expectedValue; }
            set { _expectedValue = value; }
        }

        /// <summary>
        ///     Public Property ResultIndex
        /// </summary>
        /// <returns>ResultIndex as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int ResultIndex
        {
            get { return _resultIndex; }
            set { _resultIndex = value; }
        }

        [DataMember]
        public virtual AssertType AssertType { get; set; }

        [DataMember]
        public virtual ExpectedResultType ExpectedResultType { get; set; }

        [DataMember]
        public virtual Test Test { get; set; }
    }
}