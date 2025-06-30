using Application.Dto.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaQ10API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        readonly ISubjectService SubjectService;

        public SubjectController(ISubjectService subjectService)
        {
            SubjectService = subjectService;
        }

        /// <summary>
        /// Servicio encargado de consultar todas las materias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(SubjectService.GetAll().Result);
        }

        /// <summary>
        /// Servicio encardado de registrar una nueva materia
        /// </summary>
        /// <param name="newDtoSubject">Objeto con valores para registrar la nueva materia</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] DTOSubjectRequest newDtoSubject)
        {
            return Ok(SubjectService.Add(newDtoSubject).Result);
        }

        /// <summary>
        /// Servicio encargado de actualizar una nueva materia
        /// </summary>
        /// <param name="updateSubjectId">Id de la materia</param>
        /// <param name="newDtoSubject">Objeto con valores a actualizar de la materia</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int updateSubjectId, [FromBody] DTOSubjectRequest newDtoSubject)
        {
            return Ok(SubjectService.Update(updateSubjectId, newDtoSubject).Result);
        }

        /// <summary>
        /// Servicio encargado de eiliminar una materia
        /// </summary>
        /// <param name="removeSubjectId">Id de la materia</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(int removeSubjectId)
        {
            return Ok(SubjectService.Remove(removeSubjectId).Result);
        }
    }
}
