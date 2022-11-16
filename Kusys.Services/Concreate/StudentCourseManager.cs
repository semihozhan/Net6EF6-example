using Kusys.Data.Abstract;
using Kusys.Entities;
using Kusys.Services.Abstract;
using Kusys.Shared.Utilities.Result.Abstract;
using Kusys.Shared.Utilities.Result.ComplexType;
using Kusys.Shared.Utilities.Result.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Concreate
{
    public class StudentCourseManager : IStudentCourseService
    {
        private readonly IUnitOfWork _unitofwork;

        public StudentCourseManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IResult> Add(StudentCourse student)
        {
            await _unitofwork.StudentCourse.AddAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<StudentCourse>(ResultStatus.Success, "Başarılı", student);
        }

        public async Task<IResult> Delete(StudentCourse student)
        {
            await _unitofwork.StudentCourse.DeleteAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<StudentCourse>(ResultStatus.Success, "Başarılı", student);
        }

        public  async Task<IDataResult<StudentCourse>> Get(int studentId)
        {
            var student = await _unitofwork.StudentCourse.GetAsync(s => s.StudentId == studentId, s => s.Student);
            if (student != null)
            {
                return new DataResult<StudentCourse>(ResultStatus.Success, student);
            }
            return new DataResult<StudentCourse>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IDataResult<IList<StudentCourse>>> GetAll(int? studentId)
        {
            IList<StudentCourse> student;
            if (studentId == null)
            {
                student = await _unitofwork.StudentCourse.GetAllAsync(null, s => s.Student);
            }
            else
            {
                student = await _unitofwork.StudentCourse.GetAllAsync(s => s.StudentId == studentId, s => s.Student);
            }
            
            if (student.Count > -1)
            {
                return new DataResult<IList<StudentCourse>>(ResultStatus.Success, student);
            }
            return new DataResult<IList<StudentCourse>>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IResult> Update(StudentCourse student)
        {
            await _unitofwork.StudentCourse.UpdateAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<StudentCourse>(ResultStatus.Success, "Başarılı", student);
        }
    }
}
