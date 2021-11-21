using Microsoft.AspNetCore.Mvc;
using MiniApp1.Core.DTOs;
using MiniApp1.Core.Models;
using MiniApp1.Core.Services;
using System.Threading.Tasks;

namespace MiniApp1.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly IGenericService<Course, CourseDto> _courseService;

        public CoursesController(IGenericService<Course, CourseDto> coruseService)
        {
            _courseService = coruseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return ActionResultInstance(await _courseService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveCourse(CourseDto courseDto)
        {
            return ActionResultInstance(await _courseService.AddAsync(courseDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto)
        {
            return ActionResultInstance(await _courseService.Update(courseDto, courseDto.Id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return ActionResultInstance(await _courseService.Remove(id));
        }
    }
}
