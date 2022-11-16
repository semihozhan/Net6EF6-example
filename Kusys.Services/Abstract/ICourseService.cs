using Kusys.Entities;
using Kusys.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Abstract
{
    public interface ICourseService
    {
        //client ile data arası kontrol
        Task<IDataResult<Course>> Get(int courseId);
        Task<IDataResult<IList<Course>>> GetAll();
        Task<IResult> Add(Course course);
        Task<IResult> Update(Course course);
        Task<IResult> Delete(Course courseId);
    }
}
