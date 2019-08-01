using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using oracle.api.Entities.Interfaces;

namespace oracle.api.Entities.Auther
{
    public class Author : IBaseEntity
    {
        public int AuthorId { get; set; }
        [MaxLength(100)]
        public string AuthorName { get; set; }
        [MaxLength(100)]
        public string AuthorNameEn { get; set; }
        public ICollection<Course.Course> Courses { set; get; }
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(100)]
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool IsDelete { get; set; }
    }
}