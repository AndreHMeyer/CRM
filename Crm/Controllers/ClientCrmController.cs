using Application.Handlers.ClientHandlers;
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
    public class ClientCrmController : ControllerBase
    {
        private GetClientCrmHandler getClientCrmHandler;
        private CreateClientCrmHandler createClientCrmHandler;
        private UpdateClientCrmHandler updateClientCrmHandler;
        private DeleteClientCrmHandler deleteClientCrmHandler;

        public ClientCrmController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getClientCrmHandler = new GetClientCrmHandler(connection);
            createClientCrmHandler = new CreateClientCrmHandler(connection);
            updateClientCrmHandler = new UpdateClientCrmHandler(connection);
            deleteClientCrmHandler = new DeleteClientCrmHandler(connection);
        }

        [HttpGet]
        public ActionResult<ResultModel<PaginationResult<User>>> GetClientCrm([FromQuery] ClientCrmFilter filter)
        {
            try
            {
                var t = getClientCrmHandler.Handle(filter);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<ResultModel<long>> CreateClientCrm([FromBody] ClientCrm client)
        {
            try
            {
                var t = createClientCrmHandler.Handle(client);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("CrmProvider/{IdForm}")]
        [AllowAnonymous]
        public ActionResult<Result<long>> CreateClientCrmFromProvider([FromBody] ClientCrm client)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<ResultModel<ClientCrm>> UpdateClientCrm([FromBody] ClientCrm client)
        {
            try
            {
                var t = updateClientCrmHandler.Handle(client);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<ResultModel<ClientCrm>> DeleteClientCrm([FromBody] ClientCrm client)
        {
            try
            {
                var t = deleteClientCrmHandler.Handle(client);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
