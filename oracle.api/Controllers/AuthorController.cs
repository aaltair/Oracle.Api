using Microsoft.AspNetCore.Mvc;
using oracle.api.Dtos.Author;
using oracle.api.Services.Interfaces;

namespace oracle.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAllAuthors/{pageIndex}/{pageSize}")]
        public ActionResult GetAllAuthors(int pageIndex, int pageSize) =>
            Ok(_authorService.GetAllAuthors(pageIndex, pageSize));


        [HttpGet("GetAllAuthorsWithCourses/{pageIndex}/{pageSize}")]
        public ActionResult GetAllAuthorsWithCourses(int pageIndex, int pageSize)
        {
            return Ok(_authorService.GetAllAuthorsWithCourses(pageIndex, pageSize));
        }

        [HttpGet("GetAuthorById/{id}")]
        public ActionResult GetAuthorById(int id)
        {
            return Ok(_authorService.GetAuthorById(id));
        }


        [HttpPost("CreateAuthor")]
        public ActionResult Post([FromBody] CreateAuthorDto createAuthor)
        {
            return Ok(_authorService.CreateAuthor(createAuthor, CurrentUserId()));
        }


        [HttpPut("UpdateAuthor")]
        public ActionResult UpdateCourse([FromBody] AuthorDto Author)
        {
            return Ok(_authorService.UpdateAuthor(Author, CurrentUserId()));
        }


        [HttpDelete("DeleteAuthor/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            return Ok(_authorService.DeleteAuthor(id, CurrentUserId()));
        }
    }
}