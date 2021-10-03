using AdminPanelService.Core.Reception;
using AdminPanelService.Rest.InputModels.Reception;
using AdminPanelService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [ProducesResponseType(typeof(IReadOnlyList<ReceptionModel>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {

            var result = await _receptionService.GetReceptions();

            return Ok(result);
        }

        /// <summary>
        /// Добавление новой интегрируемой приемной
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ReceptionModel),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromForm] AddInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _receptionService.Add(model.Name);

            return Ok(result);
        }

        /// <summary>
        /// Метод обновления названия приемной
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReceptionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm] UpdateInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _receptionService.Update(model.Id, model.Name);

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReceptionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] DeleteInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _receptionService.Delete(model.Id);

                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
