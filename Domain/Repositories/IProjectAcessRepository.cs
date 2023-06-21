using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProjectAcessRepository
    {
        Task<List<ProjectAcess>> GetProjectsAcess();
        Task<long> CreateProjectAcess(ProjectAcess projectAcess);
        Task<ProjectAcess> UpdateProjectAcess(ProjectAcess projectAcess);
        Task<ProjectAcess> DeleteProjectAcess(ProjectAcess projectAcess);
    }
}
