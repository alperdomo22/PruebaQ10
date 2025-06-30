using Application.Dto.Request;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace PruebaQ10API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        readonly IRegistrationService RegistrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            RegistrationService = registrationService;
        }

        /// <summary>
        /// Servicio encargado de consultar todas las inscripciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(RegistrationService.GetAll().Result);
        }

        /// <summary>
        /// Servicio encardado de registrar una nueva inscripcion
        /// </summary>
        /// <param name="newDtoRegistration">Objeto con los valores a registrar para la inscripcion</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] DTORegistrationRequest newDtoRegistration)
        {
            return Ok(RegistrationService.Add(newDtoRegistration).Result);
        }

        /// <summary>
        /// Servicio encargado de actualizar una inscripcion
        /// </summary>
        /// <param name="updateRegistrationId">Id de la inscripcion</param>
        /// <param name="newDtoRegistration">Objeto con valores a actualizar de la inscripcion</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int updateRegistrationId, [FromBody] DTORegistrationRequest newDtoRegistration)
        {
            return Ok(RegistrationService.Update(updateRegistrationId, newDtoRegistration).Result);
        }

        /// <summary>
        /// Servicio encargado de eiliminar una inscripcion
        /// </summary>
        /// <param name="removeRegistrationId">Id de la inscripcion</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(int removeRegistrationId)
        {
            return Ok(RegistrationService.Remove(removeRegistrationId).Result);
        }
    }
}
