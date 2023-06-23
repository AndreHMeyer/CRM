using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewFolder
{
    public class UpdateLogHandler
    {
        private ILogRepository logRepository;

        public UpdateLogHandler(MySqlConnection mySqlConnection)
        {
            logRepository = new LogRepository(mySqlConnection);
        }
        public Log Handle(Log log)
        {
            try
            {
                return logRepository.UpdateLog(log).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
