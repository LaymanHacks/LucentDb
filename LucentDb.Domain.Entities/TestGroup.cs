using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class TestGroupList : Collection<TestGroup>
    {
        public TestGroup First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class TestGroup
    {
        private int _id;
        private bool _isActive;
        private string _name;
        private int _projectId;

        public TestGroup()
        {
        }

        public TestGroup(int id, int projectId, string name, bool isActive)
        {
            _id = id;
            _projectId = projectId;
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
        ///     Public Property ProjectId
        /// </summary>
        /// <returns>ProjectId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
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
        public virtual Project Project { get; set; }
    }
}