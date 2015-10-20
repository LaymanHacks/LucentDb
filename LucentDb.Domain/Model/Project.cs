using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucentDb.Domain.Model
{
    public class Project : Entities.Project
    {
        private readonly ILucentDbRepositoryContext _dataRepository;

        public Project(ILucentDbRepositoryContext dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public bool ValidateConnection(int connectionId)
        {
            return
                _dataRepository.ConnectionRepository.GetDataByProjectId(ProjectId)
                    .Any(x => x.ConnectionId == connectionId);
        }
    }
}
