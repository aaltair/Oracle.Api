using AutoMapper;
using oracle.api.Dtos.Author;
using oracle.api.Dtos.Course;
using oracle.api.Entities.Auther;
using oracle.api.Entities.Course;

namespace oracle.api.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, AuthorCourseDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseAuthorDto>().ReverseMap();
        }
    }
}