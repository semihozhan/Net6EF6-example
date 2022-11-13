using Kusys.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Concreate.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c=>c.CourseId);
            builder.Property(c=>c.CourseId).ValueGeneratedOnAdd();
            builder.Property(c => c.CourseName).HasMaxLength(255);
            //builder.HasMany<Student>(c => c.Students).WithMany(r => r.Courses);
            builder.ToTable("Courses");


            builder.HasData(new Course
            {
                CourseId = 101,
                CourseName = "Introduction to Computer Science"
            },new Course
            {
                CourseId = 102,
                CourseName = "Algorithms"
            },new Course
            {
                CourseId = 103,
                CourseName = "Calculus"
            },new Course
            {
                CourseId = 104,
                CourseName = "Physics"
            });
        }
    }
}
