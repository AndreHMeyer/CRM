using CrmAuth.Domain.Model;
using Dapper;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Domain.Pagination;
using Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FormTemplateRepository : IFormTemplateRepository
    {
        private MySqlConnection connection;

        public FormTemplateRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<ResultModel<PaginationResult<FormTemplate>>> Get(FormFilter filter)
        {
            try
            {
                StringBuilder query = new();

                query.Append(" SELECT ");
                query.Append(" f.id as Id, ");
                query.Append(" f.data as Data, ");
                query.Append(" f.status as Status, ");
                query.Append(" f.idMailMarketingList as IdMailMarketingList ");
                query.Append(" FROM formtemplate AS f ");
                query.Append(" JOIN mailmarketinglist AS m ON m.id = f.idMailMarketingList ");
                query.Append(" WHERE m.idProject = @IdProject ");

                DynamicParameters parameters = new();

                parameters.Add("IdProject", filter.IdProject, System.Data.DbType.Int64);

                var obj = await connection.QueryAsync<FormTemplate>(query.ToString(), parameters);
                return new PaginationService<FormTemplate>().ExecutePagination(obj.ToList(), filter);

            }
            catch(Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        private async Task<long> GetLast()
        {
            try
            {
                StringBuilder query = new();

                query.Append(" SELECT max(id) ");
                query.Append(" from formtemplate ");


                var obj = await connection.QueryAsync<long>(query.ToString());
                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<long> Create(FormTemplate template)
        {
            try
            {
                StringBuilder query = new();

                long lastId = await GetLast();

                query.Append(" insert into formtemplate (data,status,idMailMarketingList) ");
                query.Append(" values (@Data,1,@IdMailMarketing); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("Data", $"https://localhost:7182/api/ClientCrm/CrmProvider/{lastId}");
                parameters.Add("IdMailMarketing", template.IdMailMarketingList, System.Data.DbType.Int64);

                var obj = await connection.QueryAsync<long>(query.ToString(), parameters);
                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }


        public async Task<long> Delete(long Id)
        {
            try
            {
                StringBuilder query = new();

                long lastId = await GetLast();

                query.Append(" DELETE FROM formtemplate ");
                query.Append(" WHERE id = @Id ");

                DynamicParameters parameters = new();

                parameters.Add("Id", Id, System.Data.DbType.Int64);

                var obj = await connection.QueryAsync<long>(query.ToString(), parameters);
                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco: " + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}
