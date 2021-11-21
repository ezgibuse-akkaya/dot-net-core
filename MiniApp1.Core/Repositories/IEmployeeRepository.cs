using MiniApp1.Core.Models;
using System.Threading.Tasks;

namespace MiniApp1.Core.Repositories
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        Task<Employee> GetEmployeeByUserId(string userId);
    }
}
