using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class TestTypeList : Collection<TestType>
    {
        public TestType First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class TestType
    {
        private int _id;
        private bool _isActive;
        private string _name;
        private string _testValidatorType;

        public TestType()
        {
        }

        public TestType(int id, string name, string testValidatorType, bool isActive)
        {
            _id = id;
            _name = name;
            _testValidatorType = testValidatorType;
            _isActive = isActive;
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
        ///     Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        ///     Public Property TestValidatorType
        /// </summary>
        /// <returns>TestValidatorType as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string TestValidatorType
        {
            get { return _testValidatorType; }
            set { _testValidatorType = value; }
        }

        /// <summary>
        ///     Public Property IsActive
        /// </summary>
        /// <returns>IsActive as Boolean</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [DataMember]
        public virtual Collection<Test> Tests { get; set; }
    }
}