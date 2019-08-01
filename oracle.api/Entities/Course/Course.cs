using System;
using System.ComponentModel.DataAnnotations;
using oracle.api.Entities.Auther;
using oracle.api.Entities.Interfaces;

namespace oracle.api.Entities.Course
{
    public class Course : IBaseEntity
    {
        public int CourseId { get; set; }
        [MaxLength(50)]
        public string CourseName { get; set; }
        [MaxLength(50)]
        public string CourseNameEn { get; set; }
        [MaxLength(50)]
        public string CourseCategory { get; set; }
        [MaxLength(50)]
        public string CourseCategoryEn { get; set; }
        public int AuthorId { get; set; }
        public Author Author { set; get; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool IsDelete { get; set; }
    }
}