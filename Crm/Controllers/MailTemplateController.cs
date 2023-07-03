using Application.Handlers.ClientHandlers;
using Application.Handlers.MailTemplateHandlers;
using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MailTemplateController : ControllerBase
    {
        private GetMailTemplateHandler getMailTemplateHandler;
        private CreateMailTemplateHandler createMailTemplateHandler;
        private UpdateMailTemplateHandler updateMailTemplateHandler;
        private DeleteMailTemplateHandler deleteMailTemplateHandler;

        public MailTemplateController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getMailTemplateHandler = new GetMailTemplateHandler(connection);
            createMailTemplateHandler = new CreateMailTemplateHandler(connection);
            updateMailTemplateHandler = new UpdateMailTemplateHandler(connection);
            deleteMailTemplateHandler = new DeleteMailTemplateHandler(connection);
        }

        [HttpGet]
        public ActionResult<ResultModel<PaginationResult<MailTemplate>>> GetMailTemplates([FromQuery] MailTemplateFilter filter)
        {
            try
            {
                var t = getMailTemplateHandler.Handle(filter);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<ResultModel<long>> CreateMailTemplate([FromBody] MailTemplate mailTemplate)
        {
            try
            {
                var t = createMailTemplateHandler.Handle(mailTemplate);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<ResultModel<MailTemplate>> UpdateMailTemplate([FromBody] MailTemplate mailTemplate)
        {
            try
            {
                var t = updateMailTemplateHandler.Handle(mailTemplate);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<ResultModel<MailTemplate>> DeleteMailTemplate([FromBody] MailTemplate mailTemplate)
        {
            try
            {
                var t = deleteMailTemplateHandler.Handle(mailTemplate);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
