using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
        Task<long> CreateProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task<Project> DeleteProject(Project project);
    }
}
