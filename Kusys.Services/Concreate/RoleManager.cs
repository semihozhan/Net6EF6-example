using Kusys.Data.Abstract;
using Kusys.Entities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Kusys.Shared.Utilities.Result.Concreate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Concreate
{
    public class RoleManager : IRoleService
    {
        private readonly IUnitOfWork _unitofwork;

        public RoleManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<IResult> Add(Role role)
        {
            await _unitofwork.Role.AddAsync(role);
            return new DataResult<Role>(ResultStatus.Success, "Başarılı", role);
        }

        public async Task<IResult> Delete(Role role)
        {
            await _unitofwork.Role.DeleteAsync(role);
            return new DataResult<Role>(ResultStatus.Success, "Başarılı", role);
        }

    
        public async Task<IDataResult<Role>> Get(int roleId)
        {
            var roles = await _unitofwork.Role.GetAsync(s => s.Id == roleId, s=>s.Students);
            if (roles != null)
            {
                return new DataResult<Role>(ResultStatus.Success, roles);
            }
            return new DataResult<Role>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IDataResult<IList<Role>>> GetAll()
        {
            var roles = await _unitofwork.Role.GetAllAsync(null, s => s.Students);
            if (roles != null)
            {
                return new DataResult<IList<Role>>(ResultStatus.Success, roles);
            }
            return new DataResult<IList<Role>>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IResult> Update(Role role)
        {
            await _unitofwork.Role.UpdateAsync(role);
            return new DataResult<Role>(ResultStatus.Success, "Başarılı", role);
        }
    }
}
