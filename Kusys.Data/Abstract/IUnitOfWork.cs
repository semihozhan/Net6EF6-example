using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }
        IRoleRepository Role { get; }
        IStudentCourseRepository StudentCourse { get; }

        Task<int> SaveAscyn();
    }
}
