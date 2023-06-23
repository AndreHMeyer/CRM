using Dapper;
using Domain.Entities;
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
    public class MailRepository : IMailRepository
    {
        private MySqlConnection connection;

        public MailRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<Mail>> GetMails()
        {
            try
            {
                await connection.OpenAsync();

                StringBuilder query = new StringBuilder();
                query.Append("SELECT m.id as Id, ");
                query.Append("m.body as Body, ");
                query.Append("m.idMailTemplate as IdMailTemplate ");
                query.Append("FROM mail m ");
                query.Append("JOIN mailTemplate mt ON mt.id = m.idMailTemplate;");

                var obj = await connection.QueryAsync<Mail>(query.ToString());

                return obj.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
        }

        public async Task<long> CreateMail(Mail mail)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO mail (body) ");
                query.Append(" VALUES (@body); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("body", mail.Body);

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

        public async Task<Mail> UpdateMail(Mail mail)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE mail SET body = @body ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", mail.Id, DbType.Int64);
                parameters.Add("body", mail.Body);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return mail;
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

        public async Task<Mail> DeleteMail(Mail mail)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  DELETE FROM mail WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", mail.Id, DbType.Int64);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return mail;
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
