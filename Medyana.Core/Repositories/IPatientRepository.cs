using System.Threading.Tasks;
using Medyana.Core.Entity;

namespace Medyana.Core.Repositories
{
    public interface IPatientRepository:IRepository<Patient>
    {
        Task<Patient> GetWithDoctorIdAsync(int doctorId);
    }
}