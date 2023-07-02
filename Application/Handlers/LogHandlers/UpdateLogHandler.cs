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
    public class UpdateLogHandler
    {
        private ILogRepository logRepository;

        public UpdateLogHandler(MySqlConnection mySqlConnection)
        {
            logRepository = new LogRepository(mySqlConnection);
        }
        public ResultModel<Log> Handle(Log log)
        {
            try
            {
                var result = logRepository.UpdateLog(log).Result;
                return new Result<Log>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<Log>().CreateErro(ex.Message);
            }
        }
    }
}
