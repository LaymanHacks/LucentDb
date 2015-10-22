using System.Collections.ObjectModel;
using System.Linq;
using LucentDb.Domain;
using Newtonsoft.Json;

namespace LucentDb.Validator.Model
{
    public class ValidationProject
    {
        private readonly ILucentDbRepositoryContext _dataRepository;

        public ValidationProject(ILucentDbRepositoryContext dataRepository)
        {
            _dataRepository = dataRepository;
            ValidationResponses = new Collection<ValidationResponse>();
            ValidationTests =new Collection<ValidationTest>();
        }

        public int ProjectId { get; set; }
        [JsonIgnore]
        public Collection<ValidationTest> ValidationTests { get; set; }
        public Collection<ValidationResponse> ValidationResponses { get; private set; }

        public void Validate()
        {
            if (ValidationTests.Count == 0) return;
            foreach (var vTest in ValidationTests)
            {
                ValidationResponses.Add(vTest.Validate());
            }
        }

        public bool ValidateConnection(int connectionId)
        {
            return
                _dataRepository.ConnectionRepository.GetDataByProjectId(ProjectId)
                    .Any(x => x.ConnectionId == connectionId & x.IsActive);
        }
    }
}