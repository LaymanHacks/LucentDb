//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//-----------------------------------------------------------------------------
using LucentDb.Data.Repository;
using System.Linq;
  
namespace LucentDb.Domain.Entities.Extensions 
{
  public static class ConnectionExtensions
  {
   
     
      public static Connection IncludeProject_ConnectionConnection(this Connection connection, IProjectRepository projectRepository) 
      {
         if (connection.Project_ConnectionConnection != null) return  connection;   
               connection.Project_ConnectionConnection = (ProjectList)projectRepository.GetProjectsByConnectionId(connection.ConnectionId);
         return  connection;      
      }
     
  }    
}    
