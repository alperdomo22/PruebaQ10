using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class RegistrationRepository: IRegistrationRepository
    {
        readonly ApplicationDBContext applicationDBContext;
        public RegistrationRepository(
            ApplicationDBContext _applicationDBContext
        )
        {
            applicationDBContext = _applicationDBContext;
        }

        public async Task<Registration[]> GetAll()
        {
            return await applicationDBContext.Registration.Include(registration => registration.Student).Include(registration => registration.Subject).ToArrayAsync();
        }

        public async Task<Registration?> GetById(int registrationId)
        {
            return await applicationDBContext.Registration.FirstOrDefaultAsync(registration => registration.Id == registrationId);
        }

        public async Task<Registration> Add(Registration newRegistration)
        {
            await applicationDBContext.Registration.AddAsync(newRegistration);

            await applicationDBContext.SaveChangesAsync();

            return newRegistration;
        }

        public async Task<Registration> Update(int updateRegistrationId, Registration updateRegistration)
        {
            Registration selectRegistration = applicationDBContext.Registration.FirstAsync(registration => registration.Id == updateRegistrationId).Result;

            selectRegistration.Description = updateRegistration.Description;
            selectRegistration.StudentId = updateRegistration.StudentId;
            selectRegistration.SubjectId = updateRegistration.SubjectId;

            await applicationDBContext.SaveChangesAsync();

            return selectRegistration;
        }

        public async Task<int> Remove(int removeRegistrationId)
        {
            Registration selectRegistration = applicationDBContext.Registration.FirstAsync(student => student.Id == removeRegistrationId).Result;

            applicationDBContext.Registration.Remove(selectRegistration);

            await applicationDBContext.SaveChangesAsync();

            return removeRegistrationId;
        }
    }
}
