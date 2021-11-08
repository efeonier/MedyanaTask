using System.Threading.Tasks;
using Medyana.Core.Entity;
using Medyana.Core.Repositories;
using Medyana.Core.Services;
using Medyana.Core.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace Medyana.Services.Services
{
    public class PatientService:Service<Patient>,IPatientService
    {
        private readonly ILogger<PatientService> _logger;
        public PatientService(IUnitOfWork unitOfWork, IRepository<Patient> repository,ILogger<PatientService> logger) : base(unitOfWork, repository)
        {
            _logger = logger;
            _logger.LogInformation("PatientService");
        }

        public async Task<Patient> GetWithDoctorIdAsync(int doctorId)
        {
            return await _unitOfWork.Patient.GetWithDoctorIdAsync(doctorId);
        }
    }
}