using MiniApp1.Core.Repositories;
using System.Threading.Tasks;

namespace MiniApp1.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees {  get; }
        Task CommmitAsync();
        void Commit();
    }
}
