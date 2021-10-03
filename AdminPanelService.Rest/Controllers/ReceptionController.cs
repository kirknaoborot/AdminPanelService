using AdminPanelService.Core.Reception;
using AdminPanelService.Rest.InputModels.Reception;
using AdminPanelService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPanelService.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceptionController : ControllerBase
    {
        private readonly IReceptionService _receptionService;

        public ReceptionController(IReceptionService receptionService)
        {
            _receptionService = receptionService;
        }

        /// <summary>
        /// Получение списка интегрированных приемных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReceptionModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {

            var result = _receptionService.GetReceptions();

            return Ok(result);
        }

        /// <summary>
        /// Добавление новой интегрируемой приемной
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReceptionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _receptionService.Add(model.Name);

            return Ok(result);
        }
    }
}
