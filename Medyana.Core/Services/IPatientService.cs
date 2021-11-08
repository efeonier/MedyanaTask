using System.Threading.Tasks;
using Medyana.Core.Entity;

namespace Medyana.Core.Services
{
    public interface IPatientService : IService<Patient>
    {
        Task<Patient> GetWithDoctorIdAsync(int doctorId);
    }
}