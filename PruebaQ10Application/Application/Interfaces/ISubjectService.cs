using Application.Dto.Request;
using Application.Dto.Response;

namespace Application.Interfaces
{
    public interface ISubjectService
    {
        public Task<DTOGeneralResponse<DTOSubjectResponse[]>> GetAll();
        public Task<DTOGeneralResponse<DTOSubjectResponse>> Add(DTOSubjectRequest newSubject);
        public Task<DTOGeneralResponse<DTOSubjectResponse>> Update(int updateSubjectId, DTOSubjectRequest updateSubject);
        public Task<DTOGeneralResponse<int>> Remove(int removeSubjectId);
    }
}
