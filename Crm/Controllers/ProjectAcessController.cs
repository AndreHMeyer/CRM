using Application.NewFolder;
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
    public class ProjectAcessController : ControllerBase
    {
        private GetProjectAcessHandler getProjectAcessHandler;
        private CreateProjectAcessHandler createProjectAcessHandler;
        private UpdateProjectAcessHandler updateProjectAcessHandler;
        private DeleteProjectAcessHandler deleteProjectAcessHandler;

        public ProjectAcessController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getProjectAcessHandler = new GetProjectAcessHandler(connection);
            createProjectAcessHandler = new CreateProjectAcessHandler(connection);
            updateProjectAcessHandler = new UpdateProjectAcessHandler(connection);
            deleteProjectAcessHandler = new DeleteProjectAcessHandler(connection);
        }

        [HttpGet]
        public ActionResult<List<Log>> GetProjectsAcessHandler()
        {
            try
            {
                var t = getProjectAcessHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateProjectAcessHandler([FromBody] ProjectAcess projectAcess)
        {
            try
            {
                var t = createProjectAcessHandler.Handle(projectAcess);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateProjectAcessHandler([FromBody] ProjectAcess projectAcess)
        {
            try
            {
                var t = updateProjectAcessHandler.Handle(projectAcess);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteProjectAcessHandler([FromBody] ProjectAcess projectAcess)
        {
            try
            {
                var t = deleteProjectAcessHandler.Handle(projectAcess);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
