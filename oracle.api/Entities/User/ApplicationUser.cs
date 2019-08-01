using System;
using Microsoft.AspNetCore.Identity;
using oracle.api.Entities.Interfaces;

namespace oracle.api.Entities.User
{
    public class ApplicationUser : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FirstNameEn { get; set; }
        public string SecondNameEn { get; set; }
        public string LastNameEn { get; set; }
        public string ProfileImg { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool IsDelete { get; set; }


    }
}