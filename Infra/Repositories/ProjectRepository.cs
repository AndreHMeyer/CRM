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
    public class ProjectRepository : IProjectRepository
    {
        private MySqlConnection connection;

        public ProjectRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<ResultModel<PaginationResult<Project>>> GetProjects(ProjectFilter filter)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT p.id as Id, ");
                query.Append(" p.name as Name, ");
                query.Append(" p.description as Description, ");
                query.Append(" p.photo as Photo, ");
                query.Append(" p.createdAt as CreatedAt, ");
                query.Append(" p.status as Status, ");
                query.Append(" p.idUserOwner as IdUserOwner ");
                query.Append(" FROM project p ");
                query.Append(" JOIN user u ON u.id = p.idUserOwner ");
                query.Append(" WHERE 1=1 ");

                DynamicParameters parameters = new();

                if (filter.Id.HasValue)
                {
                    query.Append(" AND p.id = @Id ");
                    parameters.Add("Id", filter.Id.Value, DbType.Int64);
                }
                if (filter.idUserOwner.HasValue)
                {
                    query.Append(" AND p.idUserOwner = @IdUserOwner ");
                    parameters.Add("IdUserOwner", filter.idUserOwner.Value, DbType.Int64);
                }
                if (!String.IsNullOrEmpty(filter.Name))
                {
                    query.Append(" AND p.name LIKE %@Name% ");
                    parameters.Add("Name", filter.Name);
                }

                var obj = await connection.QueryAsync<Project>(query.ToString(),parameters);

                return new PaginationService<Project>().ExecutePagination(obj.ToList(), filter);
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

        public async Task<long> CreateProject(Project project)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO project (name, description, photo, createdAt, status) ");
                query.Append(" VALUES (@name, @description, @photo, @createdAt, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("name", project.Name);
                parameters.Add("description", project.Description);
                parameters.Add("photo", project.Photo);
                parameters.Add("createdAt", project.CreatedAt, DbType.Int64);
                parameters.Add("status", project.Status, DbType.Boolean);

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

        public async Task<Project> UpdateProject(Project project)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  UPDATE project SET name = @name, description = @description, photo = @photo, createdAt = @createdAt, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", project.Id, DbType.Int64);
                parameters.Add("name", project.Name);
                parameters.Add("description", project.Description);
                parameters.Add("photo", project.Photo);
                parameters.Add("createdAt", project.CreatedAt, DbType.Int64);
                parameters.Add("status", project.Status, DbType.Boolean);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return project;
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

        public async Task<Project> DeleteProject(Project project)
        {
            try
            {
                StringBuilder query = new();
                query.Append("  DELETE FROM project WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", project.Id, DbType.Int64);

                await connection.ExecuteAsync(query.ToString(), parameters);

                return project;
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
