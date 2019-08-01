using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using oracle.api.Entities.Auther;
using oracle.api.Entities.Course;
using oracle.api.Entities.User;

namespace oracle.api.Infrastructure.Contexts
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {



        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            FluentApi(builder);
            SeedData(builder);
            GlobalFilters(builder);

        }

        private void GlobalFilters(ModelBuilder builder)
        {

            builder.Entity<ApplicationUser>().HasQueryFilter(w => !w.IsDelete);
        }

        private void SeedData(ModelBuilder builder)
        {


            var hash = new PasswordHasher<ApplicationUser>();
            var ADMIN_ID = Guid.NewGuid().ToString();
            var ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { Id = ROLE_ID, Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper() });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "aaltair.developer@gmail.com",
                NormalizedEmail = "aaltair.developer@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+962788260020",
                PhoneNumberConfirmed = true,
                FirstName = "علاء",
                SecondName = "عباس",
                LastName = "الطير",
                FirstNameEn = "Alaa",
                SecondNameEn = "Abbas",
                LastNameEn = "Altair",
                BirthDate = new DateTime(1993, 1, 27),
                Address = "Amman",
                City = "Amman",
                PasswordHash = hash.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = String.Empty,
                CreatedOn = DateTime.Now
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<Author>().HasData(new Author[]
            {
                new Author {AuthorId = 1,AuthorName = "علاء عباس الطير", AuthorNameEn = "Alaa Abbas Altair", CreatedOn = DateTime.Now},

            });

            builder.Entity<Course>().HasData(new Course[]
                {
                    new Course
                    {
                        CourseId = 1, CourseCategory = "شامل" ,
                        CourseCategoryEn = "FullStack",
                        AuthorId = 1,
                        CourseNameEn = ".Net Core With React",
                        CourseName = "دوره (.Net Core With React) ",
                        CreatedOn = DateTime.Now
                    },
                    new Course
                    {
                        CourseId = 2,
                        CourseCategory = "تصمم وجهات",
                        CourseCategoryEn = "FrontEnd",
                        AuthorId = 1,
                        CourseNameEn = "React With Redux",
                        CourseName = "دوره (React With Redux)",
                        CreatedOn = DateTime.Now
                    },
                    new Course
                    {
                        CourseId = 3,
                        CourseCategory = "برمجه",
                        CourseCategoryEn = "BackEnd",
                        AuthorId = 1,
                        CourseNameEn = ".Net Core WebApi",
                        CourseName = "دوره (.Net Core WebApi)",
                        CreatedOn = DateTime.Now
                    },
                }
            );

        }

        private void FluentApi(ModelBuilder builder)
        {

        }




    }
}