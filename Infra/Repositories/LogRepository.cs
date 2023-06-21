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
    public class LogRepository : ILogRepository
    {
        private MySqlConnection connection;

        public LogRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<Log>> GetLogs()
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT l.id as Id, ");
                query.Append(" l.tableLog as TableLog, ");
                query.Append(" l.type as Type, ");
                query.Append(" l.data as Data, ");
                query.Append(" l.idUser as IdUser, ");
                query.Append(" FROM log l, ");
                query.Append(" JOIN user u on u.id = l.idUser; ");

                var obj = await connection.QueryAsync<Log>(query.ToString());

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

        public async Task<long> CreateLog(Log log)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO log (tableLog, type, data) ");
                query.Append(" VALUES (@tableLog, @type, @data); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("tableLog", log.TableLog);
                parameters.Add("type", log.Type);
                parameters.Add("data", log.Data);

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

        public async Task<Log> UpdateLog(Log log)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE log SET tableLog = @tableLog, type = @type, data = @data ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", log.Id, DbType.Int64);
                parameters.Add("tableLog", log.TableLog);
                parameters.Add("type", log.Type);
                parameters.Add("data", log.Data);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return log;
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

        public async Task<Log> DeleteLog(Log log)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" DELETE FROM log WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", log.Id, DbType.Int64);


                await connection.ExecuteAsync(query.ToString(), parameters);

                return log;
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