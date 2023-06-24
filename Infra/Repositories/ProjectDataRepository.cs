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
    public class ProjectDataRepository : IProjectDataRepository
    {
        private MySqlConnection connection;

        public ProjectDataRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<ProjectData>> GetProjectsData()
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT pd.id as Id, ");
                query.Append(" pd.revenue as Revenue, ");
                query.Append(" pd.numberOfClients as NumberOfClients, ");
                query.Append(" pd.projectName as ProjectName, ");
                query.Append(" pd.idProject as IdProject ");
                query.Append(" FROM projectData pd ");
                query.Append(" JOIN project p ON p.id = pa.idProject; ");

                var obj = await connection.QueryAsync<ProjectData>(query.ToString());

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

        public async Task<long> CreateProjectData(ProjectData projectData)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO projectData (revenue, numberOfClients, projectName) ");
                query.Append(" VALUES (@revenue @numberOfClients, @projectName); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("revenue", projectData.Revenue, DbType.Double);
                parameters.Add("numberOfClients", projectData.NumberOfClients, DbType.Int64);
                parameters.Add("projectName", projectData.ProjectName);

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

        public async Task<ProjectData> UpdateProjectData(ProjectData projectData)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE projectData SET revenue = @revenue, numberOfClients = @numberOfClients, projectName = @projectName ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", projectData.Id, DbType.Int64);
                parameters.Add("revenue", projectData.Revenue, DbType.Double);
                parameters.Add("numberOfClients", projectData.NumberOfClients, DbType.Int64);
                parameters.Add("projectName", projectData.ProjectName);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return projectData;
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

        public async Task<ProjectData> DeleteProjectData(ProjectData projectData)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  DELETE FROM projectData WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", projectData.Id, DbType.Int64);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return projectData;
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
