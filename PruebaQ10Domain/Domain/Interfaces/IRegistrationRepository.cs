using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        public Task<Registration[]> GetAll();
        public Task<Registration?> GetById(int registrationId);
        public Task<Registration> Add(Registration newRegistration);
        public Task<Registration> Update(int updateRegistrationId, Registration updateRegistration);
        public Task<int> Remove(int removeRegistrationId);
    }
}
