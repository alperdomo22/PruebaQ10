using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaQ10API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        readonly IStudentService StudentService;

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        /// <summary>
        /// Servicio encargado de consultar todos los estudiantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentService.GetAll().Result);
        }

        /// <summary>
        /// Servicio encardado de registrar un nuevo estudiante
        /// </summary>
        /// <param name="newDtoStudent">Objeto con los valores a registrar para el estudiante</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] DTOStudentRequest newDtoStudent)
        {
            return Ok(StudentService.Add(newDtoStudent).Result);
        }

        /// <summary>
        /// Servicio encargado de actualizar un estudiante
        /// </summary>
        /// <param name="updateStudentId">Id del estudiante</param>
        /// <param name="newDtoStudent">Objeto con valores a actualizar del estudiante</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int updateStudentId, [FromBody] DTOStudentRequest dtoStudentRequest)
        {
            return Ok(StudentService.Update(updateStudentId, dtoStudentRequest).Result);
        }

        /// <summary>
        /// Servicio encargado de eiliminar un estudiante
        /// </summary>
        /// <param name="removeStudentId">Id del estudiante</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(int removeStudentId)
        {
            return Ok(StudentService.Remove(removeStudentId).Result);
        }
    }
}
