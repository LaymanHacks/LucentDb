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
    public class Project_ConnectionList : Collection<Project_Connection>
    {
        public Project_Connection First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class Project_Connection
    {
        private int _connectionId;
        private int _projectId;

        public Project_Connection()
        {
        }

        public Project_Connection(int projectId, int connectionId)
        {
            _projectId = projectId;
            _connectionId = connectionId;
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
        ///     Public Property ConnectionId
        /// </summary>
        /// <returns>ConnectionId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int ConnectionId
        {
            get { return _connectionId; }
            set { _connectionId = value; }
        }

        [DataMember]
        public virtual Connection ConnectionConnection { get; set; }

        [DataMember]
        public virtual Project ProjectProject { get; set; }
    }
}