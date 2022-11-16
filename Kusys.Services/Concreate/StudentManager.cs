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
    public class StudentManager : IStudentService
    {
        private readonly IUnitOfWork _unitofwork;

        public StudentManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IDataResult<Student>> Add(Student student)
        {
            await _unitofwork.Student.AddAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<Student>(ResultStatus.Success, "Başarılı", student);
        }

        public async Task<IResult> Delete(Student student)
        {
            await _unitofwork.Student.DeleteAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<Student>(ResultStatus.Success, "Başarılı", student);
        }

        public async Task<IDataResult<Student>> Get(int studentId)
        {
            var student = await _unitofwork.Student.GetAsync(s => s.StudentId == studentId, s => s.StudentCourse, s => s.Role);
            if (student!=null)
            {
                return new DataResult<Student>(ResultStatus.Success, student);
            }
            return new DataResult<Student>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı",null);
        }

        public async Task<IDataResult<Student>> LoginControl(string username,string password)
        {
            var student = await _unitofwork.Student.GetAsync(s => s.username == username && s.password== password, s => s.StudentCourse, s => s.Role);
            if (student != null)
            {
                return new DataResult<Student>(ResultStatus.Success, student);
            }
            return new DataResult<Student>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IDataResult<IList<Student>>> GetAll()
        {
            var student = await _unitofwork.Student.GetAllAsync(null, s => s.StudentCourse, s => s.Role);
            if (student.Count > -1)
            {
                return new DataResult<IList<Student>>(ResultStatus.Success, student);
            }
            return new DataResult<IList<Student>>(ResultStatus.Error, "Böyle bir öğrenci bulunamadı", null);
        }

        public async Task<IResult> Update(Student student)
        {
            await _unitofwork.Student.UpdateAsync(student);
            await _unitofwork.SaveAscyn();
            return new DataResult<Student>(ResultStatus.Success, "Başarılı", student);
        }
    }
}
