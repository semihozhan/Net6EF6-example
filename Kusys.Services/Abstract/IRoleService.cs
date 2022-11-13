using Kusys.Entities;
using Kusys.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Abstract
{
    public interface IRoleService
    {
        Task<IDataResult<Role>> Get(int roleId);
        Task<IDataResult<IList<Role>>> GetAll();
        Task<IResult> Add(Role role);
        Task<IResult> Update(Role role);
        Task<IResult> Delete(Role role);
    }
}
