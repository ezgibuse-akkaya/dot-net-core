using MiniApp1.Core.DTOs;
using MiniApp1.Core.Models;
using SharedLibrary.Dtos;
using System.Threading.Tasks;

namespace MiniApp1.Core.Services
{
    public interface IEmployeeService : IGenericService<Employee,EmployeeDto>
    {
        Task<Response<EmployeeDto>> GetEmployeeByUserId(string userId);

    }
}
