using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniApp1.Core.DTOs;
using MiniApp1.Core.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniApp1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : CustomBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetEmployees()
        //{
        //    return ActionResultInstance(await _employeeService.GetAllAsync());
        //}
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByUserId()
        {
            //var userName = HttpContext.User.Identity.Name;
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return ActionResultInstance(await _employeeService.GetEmployeeByUserId(userIdClaim.Value));
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployee(EmployeeDto employeeDto)
        {
            return ActionResultInstance(await _employeeService.AddAsync(employeeDto));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            return ActionResultInstance(await _employeeService.Update(employeeDto, employeeDto.Id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return ActionResultInstance(await _employeeService.Remove(id));
        }
    }
}
