using Application.Dto.Request;
using Application.Dto.Response;

namespace Application.Interfaces
{
    public interface IRegistrationService
    {
        public Task<DTOGeneralResponse<DTORegistrationResponse[]>> GetAll();
        public Task<DTOGeneralResponse<DTORegistrationResponse>> Add(DTORegistrationRequest newRegistration);
        public Task<DTOGeneralResponse<DTORegistrationResponse>> Update(int updateRegistrationId, DTORegistrationRequest updateRegistration);
        public Task<DTOGeneralResponse<int>> Remove(int removeRegistrationId);
    }
}
