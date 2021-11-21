using Microsoft.AspNetCore.Mvc;
using MiniApp1.Core.DTOs;
using MiniApp1.Core.Models;
using MiniApp1.Core.Services;
using System.Threading.Tasks;

namespace MiniApp1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : CustomBaseController
    {
        private readonly IGenericService<Assignment, AssignmentDto> _assignmentService;

        public AssignmentsController(IGenericService<Assignment,AssignmentDto> assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            return ActionResultInstance(await _assignmentService.GetAllAsync());

        }
        [HttpPost]
        public async Task<IActionResult> SaveAssignment(AssignmentDto assignmentDto)
        {
            return ActionResultInstance(await _assignmentService.AddAsync(assignmentDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAssignment(AssignmentDto assignmentDto)
        {
            return ActionResultInstance(await _assignmentService.Update(assignmentDto, assignmentDto.Id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            return ActionResultInstance(await _assignmentService.Remove(id));
        }
    }
}
