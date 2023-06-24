using Application.NewFolder;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private GetProjectHandler getProjectHandler;
        private CreateProjectHandler createProjectHandler;
        private UpdateProjectHandler updateProjectHandler;
        private DeleteProjectHandler deleteProjectHandler;

        public ProjectController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getProjectHandler = new GetProjectHandler(connection);
            createProjectHandler = new CreateProjectHandler(connection);
            updateProjectHandler = new UpdateProjectHandler(connection);
            deleteProjectHandler = new DeleteProjectHandler(connection);

        }

        [HttpGet]
        public ActionResult<List<User>> GetProject()
        {
            try
            {
                var t = getProjectHandler.Handle();

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateProject([FromBody] Project project)
        {
            try
            {
                var t = createProjectHandler.Handle(project);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateProject([FromBody] Project project)
        {
            try
            {
                var t = updateProjectHandler.Handle(project);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteProject([FromBody] Project project)
        {
            try
            {
                var t = deleteProjectHandler.Handle(project);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
