using CrmAuth.Domain.Model;
using Dapper;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Domain.Pagination;
using Domain.Repositories;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MySqlConnection connection;

        public UserRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<ResultModel<PaginationResult<User>>> GetUsers(UserFilter filter)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT id as Id, ");
                query.Append(" name as Name, ");
                query.Append(" phone as Phone, ");
                query.Append(" photo as Photo, ");
                query.Append(" status as Status ");
                query.Append(" FROM user ");
                query.Append(" WHERE 1=1 ");

                DynamicParameters parameters = new();

                if (filter.Id.HasValue)
                {
                    query.Append(" AND id = @Id ");
                    parameters.Add("Id", filter.Id);
                }
                if (!String.IsNullOrEmpty(filter.Name))
                {
                    query.Append(" AND name LIKE %@Name% ");
                    parameters.Add("Name", filter.Name);
                }

                var obj = await connection.QueryAsync<User>(query.ToString(),parameters);

                return new PaginationService<User>().ExecutePagination(obj.ToList(), filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                await connection.CloseAsync();
            }

        }

        public async Task<long> CreateUser(User user)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO user (name, phone, photo, status) ");
                query.Append(" VALUES (@name, @phone, @photo, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("name", user.Name);
                parameters.Add("phone", user.Phone);
                parameters.Add("photo", user.Photo);
                parameters.Add("status", user.Status, DbType.Boolean);

                var obj = await connection.QueryAsync<long>(query.ToString(), parameters);

                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE user SET name = @name, phone = @phone, photo = @photo, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", user.Id, DbType.Int64);
                parameters.Add("name", user.Name);
                parameters.Add("phone", user.Phone);
                parameters.Add("photo", user.Photo);
                parameters.Add("status", user.Status, DbType.Boolean);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                await connection.CloseAsync();
            }

        }

        public async Task<User> DeleteUser(User user)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" DELETE FROM user WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", user.Id, DbType.Int64);


                await connection.ExecuteAsync(query.ToString(), parameters);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                await connection.CloseAsync();
            }

        }
    }
}