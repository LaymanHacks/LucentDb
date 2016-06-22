using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using LucentDb.Validator.Model;

namespace LucentDb.Domain.Model
{
    [DataContract]
    public class ValidationProject
    {
        private readonly ILucentDbRepositoryContext _dataRepository;

        public ValidationProject(ILucentDbRepositoryContext dataRepository, int projectId)
        {
            _dataRepository = dataRepository;
            ProjectId = projectId;
            ValidationTestGroups = new Collection<ValidationTestGroup>();
            ValidationTests = new Collection<ValidationTest>();
        }


        [DataMember]
        public int ProjectId { get; set; }

        [DataMember]
        public Collection<ValidationTestGroup> ValidationTestGroups { get; private set; }

        [DataMember]
        public Collection<ValidationTest> ValidationTests { get; private set; }


        public Collection<ValidationResponse> Validate()
        {
            var validationResponses = new Collection<ValidationResponse>();
            if (ValidationTestGroups != null)
                foreach (var vTestGroup in ValidationTestGroups)
                {
                    var valResponses = vTestGroup.Validate();
                    foreach (var valResponse in valResponses)
                    {
                        validationResponses.Add(valResponse);
                    }
                }
            if (ValidationTests == null) return validationResponses;
            foreach (var vTest in ValidationTests)
            {
                var valResponse = vTest.Validate();
                validationResponses.Add(valResponse);
            }
            return validationResponses;
        }

        public bool ValidateConnection(int connectionId)
        {
            return
                _dataRepository.ConnectionRepository.GetDataByProjectId(ProjectId)
                    .Any(x => x.ConnectionId == connectionId & x.IsActive);
        }
    }
}