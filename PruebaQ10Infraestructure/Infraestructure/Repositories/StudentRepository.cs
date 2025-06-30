using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        readonly ApplicationDBContext applicationDBContext;
        public StudentRepository (
            ApplicationDBContext _applicationDBContext
        )
        {
            applicationDBContext = _applicationDBContext;
        }

        public async Task<Student[]> GetAll()
        {
            return await applicationDBContext.Student.ToArrayAsync();
        }

        public async Task<Student?> GetById(int studentId)
        {
            return await applicationDBContext.Student.FirstOrDefaultAsync(student => student.Id == studentId);
        }

        public async Task<Student> Add(Student newStudent) {
            await applicationDBContext.Student.AddAsync(newStudent);

            await applicationDBContext.SaveChangesAsync();

            return newStudent;
        }

        public async Task<Student> Update(int updateStudentId, Student updateStudent)
        {
            Student selectStudent = applicationDBContext.Student.FirstAsync(student => student.Id == updateStudentId).Result;

            selectStudent.FirstName = updateStudent.FirstName;
            selectStudent.LastName = updateStudent.LastName;
            selectStudent.Document = updateStudent.Document;
            selectStudent.Email = updateStudent.Email;

            await applicationDBContext.SaveChangesAsync();

            return selectStudent;
        }

        public async Task<int> Remove(int removeStudentId)
        {
            Student selectStudent = applicationDBContext.Student.FirstAsync(student => student.Id == removeStudentId).Result;

            applicationDBContext.Student.Remove(selectStudent);

            await applicationDBContext.SaveChangesAsync();

            return removeStudentId;
        }
    }
}
