using Kusys.Data.Abstract;
using Kusys.Entities;
using Kusys.Shared.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Concreate.Repositories
{
    public class StudentCourseRepository : EFEntityRepositoryBase<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
