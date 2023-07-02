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

namespace Application.Handlers.LogHandlers
{
    public class CreateLogHandler
    {
        private ILogRepository logRepository;

        public CreateLogHandler(MySqlConnection mySqlConnection)
        {
            logRepository = new LogRepository(mySqlConnection);
        }

        public ResultModel<long> Handle(Log log)
        {
            try
            {
                var result = logRepository.CreateLog(log).Result;
                return new Result<long>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
