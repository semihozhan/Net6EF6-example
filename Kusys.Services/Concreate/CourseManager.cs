using Kusys.Data.Abstract;
using Kusys.Entities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Kusys.Shared.Utilities.Result.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Concreate
{
    public class CourseManager : ICourseService
    {
        private readonly IUnitOfWork _unitofwork;

        public CourseManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<IResult> Add(Course course)
        {
            await _unitofwork.Course.AddAsync(course);
            return new DataResult<Course>(ResultStatus.Success, "Başarılı", course);
        }

        public async Task<IResult> Delete(Course course)
        {
            await _unitofwork.Course.DeleteAsync(course);
            return new DataResult<Course>(ResultStatus.Success, "Başarılı", course);
        }

    

        public async Task<IDataResult<Course>> Get(int courseId)
        {
            var roles = await _unitofwork.Course.GetAsync(s => s.CourseId== courseId, s => s.StudentCourse);
            if (roles != null)
            {
                return new DataResult<Course>(ResultStatus.Success, roles);
            }
            return new DataResult<Course>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IDataResult<IList<Course>>> GetAll()
        {
            var roles = await _unitofwork.Course.GetAllAsync(null, s => s.StudentCourse);
            if (roles != null)
            {
                return new DataResult<IList<Course>>(ResultStatus.Success, roles);
            }
            return new DataResult<IList<Course>>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IResult> Update(Course course)
        {
            await _unitofwork.Course.UpdateAsync(course);
            return new DataResult<Course>(ResultStatus.Success, "Başarılı", course);
        }
    }
}
