﻿using Dapper;
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
    public class ProjectRepository : IProjectRepository
    {
        private MySqlConnection connection;

        public ProjectRepository(MySqlConnection con)
        {
            connection = con;
        }

        public async Task<List<Project>> GetProjects()
        {
            try
            {
                StringBuilder query = new();
                query.Append(" SELECT p.id as Id, ");
                query.Append(" p.name as Name, ");
                query.Append(" p.description as Description, ");
                query.Append(" p.photo as Photo, ");
                query.Append(" p.status as Status, ");
                query.Append(" p.idUserOwner as IdUserOwner, ");
                query.Append(" FROM project p, ");
                query.Append(" JOIN user u ON u.id = p.idUserOwner; ");

                var obj = await connection.QueryAsync<Project>(query.ToString());

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

        public async Task<long> CreateProject(Project project)
        {
            try
            {
                StringBuilder query = new();
                query.Append(" INSERT INTO project (name, description, photo, status) ");
                query.Append(" VALUES (@name, @description, @photo, @status); ");
                query.Append(" SELECT LAST_INSERT_ID(); ");

                DynamicParameters parameters = new();

                parameters.Add("name", project.Name);
                parameters.Add("description", project.Description);
                parameters.Add("photo", project.Photo);
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
                query.Append("  UPDATE project SET name = @name, description = @description, photo = @photo, status = @status ");
                query.Append(" WHERE id = @id; ");

                DynamicParameters parameters = new();

                parameters.Add("id", project.Id, DbType.Int64);
                parameters.Add("name", project.Name);
                parameters.Add("description", project.Description);
                parameters.Add("photo", project.Photo);
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
