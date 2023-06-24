using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProjectDataRepository
    {
        Task<List<ProjectData>> GetProjectsData();
        Task<long> CreateProjectData(ProjectData projectData);
        Task<ProjectData> UpdateProjectData(ProjectData projectData);
        Task<ProjectData> DeleteProjectData(ProjectData projectData);
    }
}
