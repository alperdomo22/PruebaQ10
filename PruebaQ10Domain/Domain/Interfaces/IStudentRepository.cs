using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        public Task<Student[]> GetAll();
        public Task<Student?> GetById(int studentId);
        public Task<Student> Add(Student newStudent);
        public Task<Student> Update(int updateStudentId, Student updateStudent);
        public Task<int> Remove(int removeStudentId);
    }
}
