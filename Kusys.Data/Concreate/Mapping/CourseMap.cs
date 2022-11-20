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

        }
    }
}
