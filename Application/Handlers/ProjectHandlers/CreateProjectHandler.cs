using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ProjectHandlers
{
    public class CreateProjectHandler
    {
        private IProjectRepository projectRepository;
        private IMailMarketingListRepository mailMarketingListRepository;

        public CreateProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
            mailMarketingListRepository = new MailMarketingListRepository(mySqlConnection);
        }

        public ResultModel<long> Handle(Project project)
        {
            try
            {
                var result = projectRepository.CreateProject(project).Result;

                if(result != 0)
                {
                    var mr = mailMarketingListRepository.CreateMailMarketingList(new()
                    {
                        ListName = $"Default List {result}",
                        Status = true,
                        IdProject = (int)result,
                        IdMail = 1
                    }).Result;
                }

                return new Result<long>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
