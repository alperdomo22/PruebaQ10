using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class SubjectRepository: ISubjectRepository
    {
        readonly ApplicationDBContext applicationDBContext;

        public SubjectRepository(ApplicationDBContext _applicationDBContext)
        {
            applicationDBContext = _applicationDBContext;
        }

        public async Task<Subject[]> GetAll()
        {
            return await applicationDBContext.Subject.ToArrayAsync();
        }

        public async Task<Subject?> GetById(int subjectId)
        {
            return await applicationDBContext.Subject.FirstOrDefaultAsync(subject => subject.Id == subjectId);
        }

        public async Task<Subject> Add(Subject newSubject)
        {
            await applicationDBContext.Subject.AddAsync(newSubject);

            await applicationDBContext.SaveChangesAsync();

            return newSubject;
        }

        public async Task<Subject> Update(int updateSubjectId, Subject updateSubject)
        {
            Subject selectSubject = applicationDBContext.Subject.FirstAsync(student => student.Id == updateSubjectId).Result;

            selectSubject.Name = updateSubject.Name;
            selectSubject.Code = updateSubject.Code;
            selectSubject.Credits = updateSubject.Credits;

            await applicationDBContext.SaveChangesAsync();

            return selectSubject;
        }

        public async Task<int> Remove(int removeSubjectId)
        {
            Subject selectSubject = applicationDBContext.Subject.FirstAsync(subject => subject.Id == removeSubjectId).Result;

            applicationDBContext.Subject.Remove(selectSubject);

            await applicationDBContext.SaveChangesAsync();

            return removeSubjectId;
        }
    }
}
