using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class AssertTypeList : Collection<AssertType>
    {
        public AssertType First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class AssertType
    {
        private int _id;
        private string _name;

        public AssertType()
        {
        }

        public AssertType(int id, string name)
        {
            _id = id;
            _name = name;
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

        [DataMember]
        public virtual Collection<ExpectedResult> ExpectedResults { get; set; }
    }
}