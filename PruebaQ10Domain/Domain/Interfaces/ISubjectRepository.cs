using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISubjectRepository
    {
        public Task<Subject[]> GetAll();
        public Task<Subject?> GetById(int subjectId);
        public Task<Subject> Add(Subject newSubject);
        public Task<Subject> Update(int updateSubjectId, Subject updateSubject);
        public Task<int> Remove(int removeSubjectId);
    }
}
