using Application.Dto.Request;
using Application.Dto.Response;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class StudentService: IStudentService
    {
        readonly IStudentRepository StudentRepository;
        public StudentService (IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }

        public async Task<DTOGeneralResponse<DTOStudentResponse[]>> GetAll()
        {
            DTOStudentResponse[] students = (await StudentRepository.GetAll()).Select(EntitieToDto).ToArray();

            return new DTOGeneralResponse<DTOStudentResponse[]> {
                Success = true,
                Description = "Consulta realizada con exito",
                Data = students
            };
        }

        public async Task<DTOGeneralResponse<DTOStudentResponse>> Add(DTOStudentRequest newDtoStudent)
        {
            Student newStudent = DtoToEntity(newDtoStudent);

            DTOStudentResponse dtoNewStudent = EntitieToDto(await StudentRepository.Add(newStudent));

            return new DTOGeneralResponse<DTOStudentResponse>
            {
                Success = true,
                Description = "Estudiante registrado con exito",
                Data = dtoNewStudent
            };
        }

        public async Task<DTOGeneralResponse<DTOStudentResponse>> Update(int updateStudentId, DTOStudentRequest dtoUpdateStudent)
        {
            Student updateStudent = DtoToEntity(dtoUpdateStudent);

            DTOStudentResponse dtoUpdateStudentReturn = EntitieToDto(await StudentRepository.Update(updateStudentId, updateStudent));

            return new DTOGeneralResponse<DTOStudentResponse>
            {
                Success = true,
                Description = "Estudiante actualizado con exito",
                Data = dtoUpdateStudentReturn
            };
        }

        public async Task<DTOGeneralResponse<int>> Remove(int removeStudentId)
        {
            await StudentRepository.Remove(removeStudentId);

            return new DTOGeneralResponse<int>
            {
                Success = true,
                Description = "Estudiante eliminado con exito",
                Data = removeStudentId
            };
        }

        private DTOStudentResponse EntitieToDto(Student student)
        {
            return new DTOStudentResponse {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Document = student.Document,
                Email = student.Email
            };
        }

        private Student DtoToEntity(DTOStudentRequest dtoStudent)
        {
            return new Student(dtoStudent.FirstName, dtoStudent.LastName, dtoStudent.Document, dtoStudent.Email);
        }
    }
}
