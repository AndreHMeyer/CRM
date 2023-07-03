using Application.Handlers.ClientHandlers;
using Application.Handlers.FormHandlers;
using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormController : ControllerBase
    {
        private CreateFormHandler createFormHandler;
        private ExcluirFormHandler excluirFormHandler;
        private GetFormHandler getFormHandler;

        public FormController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            createFormHandler = new CreateFormHandler(connection);
            excluirFormHandler = new ExcluirFormHandler(connection);
            getFormHandler = new GetFormHandler(connection);
        }

        [HttpGet]
        public ActionResult<ResultModel<PaginationResult<FormTemplate>>> GetForms([FromQuery] FormFilter filter)
        {
            try
            {
                var t = getFormHandler.Handle(filter);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<ResultModel<long>> CreateForms([FromBody] long IdProject)
        {
            try
            {
                var t = createFormHandler.Handle(IdProject);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<ResultModel<long>> DeleteForm([FromBody] long Id)
        {
            try
            {
                var t = excluirFormHandler.Handle(Id);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
