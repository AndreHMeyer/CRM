using Application.Handlers.ClientHandlers;
using Domain.Entities;
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
        public ActionResult<List<User>> GetClientCrm()
        {
            try
            {
                var t = getClientCrmHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateClientCrm([FromBody] ClientCrm client)
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

        [HttpPut]
        public ActionResult<long> UpdateClientCrm([FromBody] ClientCrm client)
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
        public ActionResult<long> DeleteClientCrm([FromBody] ClientCrm client)
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
