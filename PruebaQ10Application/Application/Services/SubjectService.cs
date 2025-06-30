using Application.Dto.Request;
using Application.Dto.Response;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        readonly ISubjectRepository SubjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }
        public async Task<DTOGeneralResponse<DTOSubjectResponse[]>> GetAll()
        {
            DTOSubjectResponse[] students = (await SubjectRepository.GetAll()).Select(EntitieToDto).ToArray();

            return new DTOGeneralResponse<DTOSubjectResponse[]>
            {
                Success = true,
                Description = "Consulta realizada con exito",
                Data = students
            };
        }

        public async Task<DTOGeneralResponse<DTOSubjectResponse>> Add(DTOSubjectRequest newDtoSubject)
        {
            Subject newSubject = DtoToEntity(newDtoSubject);

            DTOSubjectResponse dtoNewSubject = EntitieToDto(await SubjectRepository.Add(newSubject));

            return new DTOGeneralResponse<DTOSubjectResponse>
            {
                Success = true,
                Description = "Materia registrada con exito",
                Data = dtoNewSubject
            };
        }

        public async Task<DTOGeneralResponse<DTOSubjectResponse>> Update(int updateSubjectId, DTOSubjectRequest dtoUpdateSubject)
        {
            Subject updateSubject = DtoToEntity(dtoUpdateSubject);

            DTOSubjectResponse dtoUpdateSubjectReturn = EntitieToDto(await SubjectRepository.Update(updateSubjectId, updateSubject));

            return new DTOGeneralResponse<DTOSubjectResponse>
            {
                Success = true,
                Description = "Materia actualizada con exito",
                Data = dtoUpdateSubjectReturn
            };
        }

        public async Task<DTOGeneralResponse<int>> Remove(int removeSubjectId)
        {
            await SubjectRepository.Remove(removeSubjectId);

            return new DTOGeneralResponse<int>
            {
                Success = true,
                Description = "Materia eliminada con exito",
                Data = removeSubjectId
            };
        }

        private DTOSubjectResponse EntitieToDto(Subject subject)
        {
            return new DTOSubjectResponse
            {
                Id = subject.Id,
                Name = subject.Name,
                Code = subject.Code,
                Credits = subject.Credits
            };
        }

        private Subject DtoToEntity(DTOSubjectRequest dtoSubject)
        {
            return new Subject(dtoSubject.Name, dtoSubject.Code, dtoSubject.Credits);
        }
    }
}
