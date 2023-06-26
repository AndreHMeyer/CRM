using Dapper;
using Domain.Entities;
using Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private MySqlConnection connection;

        public ClientRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<Client>> GetClients(int IdProject)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" select id as Id, name as Name, email as Email, phone as Phone, document as Document, idProject as IdProject ");
                query.Append(" from client ");
                query.Append(" where idProject =  @IdProject ");

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("IdProject", IdProject, DbType.Int64);

                var obj = await connection.QueryAsync<Client>(query.ToString(),parameters);
                return obj.ToList();
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


        public async Task<Client> GetClientById(int Id, int IdProject)
        {
            try
            {
                StringBuilder query = new();

                query.Append(" select id as Id, name as Name, email as Email, phone as Phone, document as Document, idProject as IdProject ");
                query.Append(" from client ");
                query.Append(" where id = @Id AND idProject = @IdProject; ");

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Id", Id, DbType.Int64);
                parameters.Add("IdProject", IdProject, DbType.Int64);

                var obj = await connection.QueryAsync<Client>(query.ToString(), parameters);
                return obj.First();
            }
            catch(Exception ex)
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
