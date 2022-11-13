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
    public class RoleRepository : EFEntityRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
