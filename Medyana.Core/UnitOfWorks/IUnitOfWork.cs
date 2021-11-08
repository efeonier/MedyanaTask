using System.Threading.Tasks;
using Medyana.Core.Repositories;

namespace Medyana.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        Task CommitAsync();

        void Commit();
    }
}