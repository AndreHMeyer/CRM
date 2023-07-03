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

namespace Infra.Repositories
{
    public class MailTemplateRepository : IMailTemplateRepository
    {
        private MySqlConnection connection;

        public MailTemplateRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<ResultModel<PaginationResult<MailTemplate>>> GetMailTemplates(MailTemplateFilter filter)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT id as Id, ");
                query.Append(" title as Title, ");
                query.Append(" data as Data, ");
                query.Append(" status as Status ");
                query.Append(" FROM mailTemplate ");
                query.Append(" WHERE 1 = 1 ");

                DynamicParameters parameters = new();
                if (filter.Id.HasValue)
                {
                    query.Append(" AND id = @Id ");
                    parameters.Add("Id", filter.Id.Value, DbType.Int64);
                }
                if (!String.IsNullOrWhiteSpace(filter.Title))
                {
                    query.Append($" AND title LIKE \'%{filter.Title}%\' ");
                }
                if (filter.Status.HasValue)
                {
                    query.Append(" AND status = @Status ");
                    parameters.Add("Status", filter.Status.Value, DbType.Int64);
                }

                var obj = await connection.QueryAsync<MailTemplate>(query.ToString(), parameters);

                return new PaginationService<MailTemplate>().ExecutePagination(obj.ToList(), filter);
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
                query.Append(" INSERT INTO mailTemplate (title, data, status) ");
                query.Append(" VALUES (@title, @data, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("title", mailTemplate.Title);
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
                query.Append("  UPDATE mailTemplate SET title = @title, data = @data, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", mailTemplate.Id, DbType.Int64);
                parameters.Add("title", mailTemplate.Title);
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
