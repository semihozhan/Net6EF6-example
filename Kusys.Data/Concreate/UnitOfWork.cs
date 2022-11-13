using Kusys.Data.Abstract;
using Kusys.Data.Concreate.Context;
using Kusys.Data.Concreate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Data.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KusysContext _kusysContext;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly RoleRepository _roleRepository;

        public UnitOfWork(KusysContext kusysContext)
        {
            _kusysContext = kusysContext;
        }

        public ICourseRepository Course => _courseRepository ?? new CourseRepository(_kusysContext);

        public IStudentRepository Student => _studentRepository ?? new StudentRepository(_kusysContext);

        public IRoleRepository Role => _roleRepository ?? new RoleRepository(_kusysContext);

        public async ValueTask DisposeAsync()
        {
            await _kusysContext.DisposeAsync();
        }

        public async Task<int> SaveAscyn()
        {
            return await _kusysContext.SaveChangesAsync();
        }
    }
}
