using Kusys.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Concreate.Mapping
{
    public class StudentCourseMap : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.CourseId);
            builder.HasKey(sc => sc.StudentId);
            builder.HasOne<Student>(sc => sc.Student).WithMany(s => s.StudentCourse).HasForeignKey(sc => sc.StudentId);
            builder.HasOne<Course>(sc => sc.Course).WithMany(c => c.StudentCourse).HasForeignKey(sc => sc.CourseId);

        

        }
    }
}