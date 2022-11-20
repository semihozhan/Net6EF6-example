using Kusys.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin"
            }, new Role
            {
                Id = 2,
                Name = "User"
            });


            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 1,
                username = "username",
                password = "password",
                RoleID = 1,
                BirthDate = DateTime.Now,
                FirstName = "Semih",
                LastName = "Özhan",

            },
             new Student
             {
                 StudentId = 2,
                 username = "username2",
                 password = "password",
                 RoleID = 2,
                 BirthDate = DateTime.Now,
                 FirstName = "Semih2",
                 LastName = "Özhan2",

             },
             new Student
             {
                 StudentId = 3,
                 username = "username3",
                 password = "password",
                 RoleID = 2,
                 BirthDate = DateTime.Now,
                 FirstName = "Semih3",
                 LastName = "Özhan3",

             });



            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 101,
                CourseName = "Introduction to Computer Science"
            }, new Course
            {
                CourseId = 102,
                CourseName = "Algorithms"
            }, new Course
            {
                CourseId = 103,
                CourseName = "Calculus"
            }, new Course
            {
                CourseId = 104,
                CourseName = "Physics"
            });


            

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse
            {
                StudentCourseId = 1,
                StudentId = 1,
                CourseId = 101

            },
               new StudentCourse
               {
                   StudentCourseId = 2,
                   StudentId = 1,
                   CourseId = 102

               });

        }
    }
}
