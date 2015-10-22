//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class TestValueTypeList : Collection<TestValueType>
    {
        public TestValueType First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class TestValueType
    {
        private int _id;
        private bool _isActive;
        private string _name;
        private int _testTypeId;

        public TestValueType()
        {
        }

        public TestValueType(int id, int testTypeId, string name, bool isActive)
        {
            _id = id;
            _testTypeId = testTypeId;
            _name = name;
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
        ///     Public Property TestTypeId
        /// </summary>
        /// <returns>TestTypeId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int TestTypeId
        {
            get { return _testTypeId; }
            set { _testTypeId = value; }
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

        [DataMember]
        public virtual TestType TestType { get; set; }
    }
}