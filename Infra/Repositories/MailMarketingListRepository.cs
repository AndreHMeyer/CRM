using Dapper;
using Domain.Entities;
using Domain.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class MailMarketingListRepository : IMailMarketingListRepository
    {
        private MySqlConnection connection;

        public MailMarketingListRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<MailMarketingList> GetMailMarketingListByIdForm(long IdForm)
        {
            try
            {
                StringBuilder query = new();

                query.Append(" SELECT ");
                query.Append(" m.id as Id, ");
                query.Append(" m.listName as ListName, ");
                query.Append(" m.status as Status, ");
                query.Append(" m.idProject as IdProject, ");
                query.Append(" m.idMail as IdMail ");
                query.Append(" FROM mailmarketinglist m ");
                query.Append(" JOIN formtemplate f ON f.idMailMarketingList = m.id ");
                query.Append(" WHERE f.id = @Id ");

                DynamicParameters parameters = new();

                parameters.Add("Id", IdForm, System.Data.DbType.Int64);

                var obj = await connection.QueryAsync<MailMarketingList>(query.ToString(), parameters);
                return obj.First();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco" + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<MailMarketingList> GetMailMarketingListByIdProject(long IdProject)
        {
            try
            {
                StringBuilder query = new();

                query.Append(" SELECT ");
                query.Append(" id as Id, ");
                query.Append(" listName as ListName, ");
                query.Append(" status as Status, ");
                query.Append(" idProject as IdProject, ");
                query.Append(" idMail as IdMail ");
                query.Append(" FROM mailmarketinglist ");
                query.Append(" WHERE idProject = @IdProject ");

                DynamicParameters parameters = new();

                parameters.Add("IdProject",IdProject,System.Data.DbType.Int32);

                var obj = await connection.QueryAsync<MailMarketingList>(query.ToString(), parameters);
                return obj.First();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro no banco"+ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<long> CreateMailMarketingList(MailMarketingList mail)
        {
            try
            {
                StringBuilder query = new();

                query.Append(" insert into mailmarketinglist (listname,status,idProject,idMail) ");
                query.Append(" values (@listname,@status,@idProject,@idMail); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("listname",mail.ListName);
                parameters.Add("status", mail.Status,System.Data.DbType.Boolean);
                parameters.Add("idProject", mail.IdProject,System.Data.DbType.Int64);
                parameters.Add("idMail", mail.IdMail,System.Data.DbType.Int64);

                var obj = await connection.QueryAsync<long>(query.ToString(), parameters);
                return obj.First();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro no banco" + ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}
