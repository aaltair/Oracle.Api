using Microsoft.AspNetCore.Mvc;
using oracle.api.Dtos.Course;
using oracle.api.Services.Interfaces;

namespace oracle.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAllCourse/{pageIndex}/{PageSize}")]
        public ActionResult GetAllCourse(int pageIndex, int pageSize)
        {
            return Ok(_courseService.GetAllCourse(pageIndex, pageSize));
        }

        [HttpGet("GetAllCourseWithAuthor/{pageIndex}/{PageSize}")]
        public ActionResult GetAllCourseWithAuthor(int pageIndex, int pageSize)
        {
            return Ok(_courseService.GetAllCourseWithAuthor(pageIndex, pageSize));
        }


        [HttpGet("GetCourseById/{id}")]
        public ActionResult GetCourseById(int id)
        {
            return Ok(_courseService.GetCourseById(id));
        }


        [HttpPost("CreateCourse")]
        public ActionResult Post([FromBody] CreateCourseDto createCourseDto)
        {
            return Ok(_courseService.CreateCourse(createCourseDto, CurrentUserId()));
        }


        [HttpPut("UpdateAuthor")]
        public ActionResult UpdateCourse([FromBody] CourseDto courseDto)
        {
            return Ok(_courseService.UpdateCourse(courseDto, CurrentUserId()));
        }


        [HttpDelete("DeleteCourse/{id}")]
        public ActionResult DeleteCourse(int id)
        {
            return Ok(_courseService.DeleteCourse(id, CurrentUserId()));
        }
    }
}