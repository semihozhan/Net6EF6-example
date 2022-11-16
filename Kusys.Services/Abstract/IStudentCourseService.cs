using Kusys.Entities;
using Kusys.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Abstract
{
    public interface IStudentCourseService
    {
        Task<IDataResult<StudentCourse>> Get(int studentId);
        Task<IDataResult<IList<StudentCourse>>> GetAll(int? studentId);
        Task<IResult> Add(StudentCourse student);
        Task<IResult> Update(StudentCourse student);
        Task<IResult> Delete(StudentCourse student);
    }
}
