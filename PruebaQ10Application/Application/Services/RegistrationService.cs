using Application.Dto.Request;
using Application.Dto.Response;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repositories;

namespace Application.Services
{
    public class RegistrationService: IRegistrationService
    {
        readonly IRegistrationRepository RegistrationRepository;
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            RegistrationRepository = registrationRepository;
        }

        public async Task<DTOGeneralResponse<DTORegistrationResponse[]>> GetAll()
        {
            DTORegistrationResponse[] students = (await RegistrationRepository.GetAll()).Select(EntitieToDto).ToArray();

            return new DTOGeneralResponse<DTORegistrationResponse[]>
            {
                Success = true,
                Description = "Consulta realizada con exito",
                Data = students
            };
        }

        public async Task<DTOGeneralResponse<DTORegistrationResponse>> Add(DTORegistrationRequest newDtoRegistration)
        {
            Registration newRegistration = DtoToEntity(newDtoRegistration);

            DTORegistrationResponse dtoNewRegistration = EntitieToDto(await RegistrationRepository.Add(newRegistration));

            return new DTOGeneralResponse<DTORegistrationResponse>
            {
                Success = true,
                Description = "Inscripcion registrada con exito",
                Data = dtoNewRegistration
            };
        }

        public async Task<DTOGeneralResponse<DTORegistrationResponse>> Update(int updateRegistrationId, DTORegistrationRequest dtoUpdateRegistration)
        {
            Registration updateRegistration = DtoToEntity(dtoUpdateRegistration);

            DTORegistrationResponse dtoUpdateRegistrationReturn = EntitieToDto(await RegistrationRepository.Update(updateRegistrationId, updateRegistration));

            return new DTOGeneralResponse<DTORegistrationResponse>
            {
                Success = true,
                Description = "Inscripcion actualizada con exito",
                Data = dtoUpdateRegistrationReturn
            };
        }

        public async Task<DTOGeneralResponse<int>> Remove(int removeRegistrationId)
        {
            await RegistrationRepository.Remove(removeRegistrationId);

            return new DTOGeneralResponse<int>
            {
                Success = true,
                Description = "Inscripcion eliminado con exito",
                Data = removeRegistrationId
            };
        }

        private DTORegistrationResponse EntitieToDto(Registration registration)
        {
            return new DTORegistrationResponse
            {
                Id = registration.Id,
                Description = registration.Description,
                StudentId = registration.StudentId,
                StudentName = $"{registration.Student.FirstName} {registration.Student.LastName}",
                SubjectId = registration.StudentId,
                SubjectName = registration.Subject.Name
            };
        }

        private Registration DtoToEntity(DTORegistrationRequest dtoRegistration)
        {
            return new Registration(dtoRegistration.Description, dtoRegistration.StudentId, dtoRegistration.StudentId);
        }
    }
}
