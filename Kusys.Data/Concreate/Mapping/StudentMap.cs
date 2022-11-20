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
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);
            builder.Property(s => s.StudentId).ValueGeneratedOnAdd();
            builder.Property(s => s.FirstName).HasMaxLength(255);
            builder.Property(s => s.username).HasMaxLength(255);
            builder.Property(s => s.password).HasMaxLength(255);
            builder.Property(s => s.LastName).HasMaxLength(255);
            builder.HasOne<Role>(s => s.Role).WithMany(r => r.Students).HasForeignKey(s => s.RoleID);
            //builder.HasMany<Course>(s => s.Courses).WithMany(r => r.Students);
            builder.ToTable("Students");


           
        }
    }
}
