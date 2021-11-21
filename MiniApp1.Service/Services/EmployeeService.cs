using MiniApp1.Core.DTOs;
using MiniApp1.Core.Models;
using MiniApp1.Core.Repositories;
using MiniApp1.Core.Services;
using MiniApp1.Core.UnitOfWork;
using SharedLibrary.Dtos;
using System.Threading.Tasks;

namespace MiniApp1.Service.Services
{
    public class EmployeeService : GenericService<Employee, EmployeeDto>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> genericRepository) : base(unitOfWork, genericRepository)
        {
        }

        public async Task<Response<EmployeeDto>> GetEmployeeByUserId(string userId)
        {
            var user = await _unitOfWork.Employees.GetEmployeeByUserId(userId);
            if(user == null)
            {
                return Response<EmployeeDto>.Fail("User Id not found", 404, true);
            }
            return Response<EmployeeDto>.Success(ObjectMapper.Mapper.Map<EmployeeDto>(user),200);
        }

    }
}
