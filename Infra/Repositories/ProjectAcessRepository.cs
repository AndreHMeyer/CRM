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
    public class ProjectAcessRepository : IProjectAcessRepository
    {
        private MySqlConnection connection;

        public ProjectAcessRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<ProjectAcess>> GetProjectsAcess()
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT pa.id as Id, ");
                query.Append(" pa.userType as userType, ");
                query.Append(" pa.idProject as IdProject, ");
                query.Append(" pa.idUser as IdUser ");
                query.Append(" FROM projectAcess pa ");
                query.Append(" JOIN project p u ON p.id = pa.idProject AND user u ON u.id = pa.idUser; ");

                var obj = await connection.QueryAsync<ProjectAcess>(query.ToString());

                return obj.ToList();
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

        public async Task<long> CreateProjectAcess(ProjectAcess projectAcess)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO projectAcess (userType) ");
                query.Append(" VALUES (@userType); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("userType", projectAcess.UserType);

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

        public async Task<ProjectAcess> UpdateProjectAcess(ProjectAcess projectAcess)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE projectAcess SET userType = @userType ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", projectAcess.Id, DbType.Int64);
                parameters.Add("name", projectAcess.UserType);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return projectAcess;
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

        public async Task<ProjectAcess> DeleteProjectAcess(ProjectAcess projectAcess)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  DELETE FROM projectAcess WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", projectAcess.Id, DbType.Int64);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return projectAcess;
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
