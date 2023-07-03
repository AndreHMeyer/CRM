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
                query.Append(" WHERE 2=2 ");

                DynamicParameters parameters = new();
                if(filter.Id.HasValue)
                {
                    query.Append(" AND c.id = @Id ");
                    parameters.Add("Id",filter.Id.Value,DbType.Int64);
                }
                if(!String.IsNullOrWhiteSpace(filter.Name))
                {
                    query.Append($" AND c.name LIKE \'%{filter.Name}%\' ");
                }
                if (filter.IdProject.HasValue)
                {
                    query.Append(" AND c.idProject = @IdProject ");
                    parameters.Add("IdProject", filter.IdProject.Value, DbType.Int64);
                }
                if (!String.IsNullOrWhiteSpace(filter.Email))
                {
                    query.Append($" AND c.email LIKE \'%{filter.Email}%\' ");
                }
                if (filter.Status.HasValue)
                {
                    query.Append(" AND c.status = @Status ");
                    parameters.Add("Status", filter.Status.Value, DbType.Int64);
                }

                var teste = connection.Query<ClientCrm>(query.ToString(),parameters);
                var obj = await connection.QueryAsync<ClientCrm>(query.ToString(), parameters);

                return new PaginationService<ClientCrm>().ExecutePagination(obj.ToList(), filter);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                throw new Exception("Erro no banco: " + ex);
            }
            finally
            {
                await connection.CloseAsync();
            }

        }

        public async Task<long> CreateClientCrm(ClientCrm clientCrm)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO client (name, email, phone, document, status, idProject) ");
                query.Append(" VALUES (@name, @email, @phone, @document, @status, @idProject); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("name", clientCrm.Name);
                parameters.Add("email", clientCrm.Email);
                parameters.Add("phone", clientCrm.Phone);
                parameters.Add("document", clientCrm.Document);
                parameters.Add("status", clientCrm.Status, DbType.Boolean);
                parameters.Add("idProject", clientCrm.IdProject, DbType.Int64);

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


        public async Task<ClientCrm> UpdateClientCrm(ClientCrm clientCrm)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE client SET name = @name, phone = @phone, photo = @photo, status = @status, idProject = @idProject ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("name", clientCrm.Name);
                parameters.Add("email", clientCrm.Email);
                parameters.Add("phone", clientCrm.Phone);
                parameters.Add("document", clientCrm.Document);
                parameters.Add("status", clientCrm.Status, DbType.Boolean);
                parameters.Add("idProject", clientCrm.IdProject, DbType.Int64);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return clientCrm;
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

        public async Task<ClientCrm> DeleteClientCrm(ClientCrm clientCrm)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" DELETE FROM client WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", clientCrm.Id, DbType.Int64);


                await connection.ExecuteAsync(query.ToString(), parameters);

                return clientCrm;
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