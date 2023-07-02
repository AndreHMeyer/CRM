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
    public class ClientCrmRepository : IClientCrmRepository
    {
        private MySqlConnection connection;

        public ClientCrmRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<ResultModel<PaginationResult<ClientCrm>>> GetClientsCrm(ClientCrmFilter filter)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT c.id as Id, ");
                query.Append(" c.name as Name, ");
                query.Append(" c.email as Email, ");
                query.Append(" c.phone as Phone, ");
                query.Append(" c.document as Document, ");
                query.Append(" c.status as Status, ");
                query.Append(" c.idProject as IdProject ");
                query.Append(" FROM client c ");
                query.Append(" JOIN project p On p.id = c.idProject ");
                query.Append(" WHERE 1 = 1 ");

                DynamicParameters parameters = new();
                if(filter.Id.HasValue)
                {
                    query.Append(" AND c.id = @Id ");
                    parameters.Add("Id",filter.Id.Value,DbType.Int64);
                }
                if(!String.IsNullOrWhiteSpace(filter.Name))
                {
                    query.Append(" AND c.name LIKE %@Name% ");
                    parameters.Add("Name", filter.Name);
                }
                
                var obj = await connection.QueryAsync<ClientCrm>(query.ToString());

                return new PaginationService<ClientCrm>().ExecutePagination(obj.ToList(), filter);
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

        public async Task<long> CreateClientCrm(ClientCrm client)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO client (name, email, phone, document, status) ");
                query.Append(" VALUES (@name, @email, @phone, @document, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("name", client.Name);
                parameters.Add("email", client.Email);
                parameters.Add("phone", client.Phone);
                parameters.Add("document", client.Document);
                parameters.Add("status", client.Status, DbType.Boolean);

                var obj = await connection.QueryAsync<long>(query.ToString(), parameters);

                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                connection.Dispose();
            }
        }


        public async Task<ClientCrm> UpdateClientCrm(ClientCrm client)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE client SET name = @name, phone = @phone, photo = @photo, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("name", client.Name);
                parameters.Add("email", client.Email);
                parameters.Add("phone", client.Phone);
                parameters.Add("document", client.Document);
                parameters.Add("status", client.Status, DbType.Boolean);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return client;
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

        public async Task<ClientCrm> DeleteClientCrm(ClientCrm client)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" DELETE FROM client WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", client.Id, DbType.Int64);


                await connection.ExecuteAsync(query.ToString(), parameters);

                return client;
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