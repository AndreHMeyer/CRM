using Application.NewFolder;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private GetUserHandler getUserHandler;
        private CreateUserHandler createUserHandler;
        private UpdateUserHandler updateUserHandler;
        private DeleteUserHandler deleteUserHandler;

        public UserController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
            getUserHandler = new GetUserHandler(connection);
            createUserHandler = new CreateUserHandler(connection);
            updateUserHandler = new UpdateUserHandler(connection);
            deleteUserHandler = new DeleteUserHandler(connection);
        }

        [HttpGet]
        public ActionResult<List<User>> GetUser()
        {
            try
            {
                var t = getUserHandler.Handle();

                return Ok(t);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<long> CreateUser([FromBody] User user)
        {
            try
            {
                var t = createUserHandler.Handle(user);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<long> UpdateUser([FromBody] User user)
        {
            try
            {
                var t = updateUserHandler.Handle(user);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<long> DeleteUser([FromBody] User user)
        {
            try
            {
                var t = deleteUserHandler.Handle(user);

                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
