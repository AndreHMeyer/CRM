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
    public class MailTemplateRepository : IMailTemplateRepository
    {
        private MySqlConnection connection;

        public MailTemplateRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<MailTemplate>> GetMailTemplates()
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT id as Id, ");
                query.Append(" data as Data, ");
                query.Append(" status as Status ");
                query.Append(" FROM mailTemplate; ");

                var obj = await connection.QueryAsync<MailTemplate>(query.ToString());

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

        public async Task<long> CreateMailTemplates(MailTemplate mailTemplate)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO mailTemplate (data, status) ");
                query.Append(" VALUES (@data, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("data", mailTemplate.Data);
                parameters.Add("status", mailTemplate.Status, DbType.Boolean);

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

        public async Task<MailTemplate> UpdateMailTemplates(MailTemplate mailTemplate)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE mailTemplate SET data = @data, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", mailTemplate.Id, DbType.Int64);
                parameters.Add("data", mailTemplate.Data);
                parameters.Add("status", mailTemplate.Status, DbType.Boolean);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return mailTemplate;
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

        public async Task<MailTemplate> DeleteMailTemplates(MailTemplate mailTemplate)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" DELETE FROM mailTemplate WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", mailTemplate.Id, DbType.Int64);


                await connection.ExecuteAsync(query.ToString(), parameters);

                return mailTemplate;
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
