using Application.Dto.Request;
using Application.Dto.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        public Task<DTOGeneralResponse<DTOStudentResponse[]>> GetAll();
        public Task<DTOGeneralResponse<DTOStudentResponse>> Add(DTOStudentRequest newStudent);
        public Task<DTOGeneralResponse<DTOStudentResponse>> Update(int updateStudentId, DTOStudentRequest updateStudent);
        public Task<DTOGeneralResponse<int>> Remove(int removeStudentId);
    }
}
