using Application.Handlers.LogHandlers;
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
    public class LogController : ControllerBase
    {
        private GetLogHandler getLogHandler;
        private CreateLogHandler createLogHandler;
        private UpdateLogHandler updateLogHandler;
        private DeleteLogHandler deleteLogHandler;

        public LogController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getLogHandler = new GetLogHandler(connection);
            createLogHandler = new CreateLogHandler(connection);
            updateLogHandler = new UpdateLogHandler(connection);
            deleteLogHandler = new DeleteLogHandler(connection);
        }

        [HttpGet]
        public ActionResult<List<Log>> GetLogs()
        {
            try
            {
                var t = getLogHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateLog([FromBody] Log log)
        {
            try
            {
                var t = createLogHandler.Handle(log);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateLog([FromBody] Log log)
        {
            try
            {
                var t = updateLogHandler.Handle(log);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteLog([FromBody] Log log)
        {
            try
            {
                var t = deleteLogHandler.Handle(log);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
