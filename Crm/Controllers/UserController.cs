﻿using Application.Handlers.UserHandlers;
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
        public ActionResult<ResultModel<PaginationResult<User>>> GetUser([FromQuery]UserFilter filter)
        {
            try
            {
                var t = getUserHandler.Handle(filter);

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
        public ActionResult<ResultModel<User>> UpdateUser([FromBody] User user)
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
