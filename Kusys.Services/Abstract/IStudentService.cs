using Kusys.Entities;
using Kusys.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Abstract
{
    public interface IStudentService
    {
        //client ile data arası kontrol
        Task<IDataResult<Student>> Get(int studentId);
        Task<IDataResult<IList<Student>>> GetAll();
        Task<IResult> Add(Student student);
        Task<IResult> Update(Student student);
        Task<IResult> Delete(Student student);

        Task<IDataResult<Student>> LoginControl(string username, string password);
    }
}
