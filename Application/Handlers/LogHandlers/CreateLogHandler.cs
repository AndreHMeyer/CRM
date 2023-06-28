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

        public long Handle(Log log)
        {
            try
            {
                return logRepository.CreateLog(log).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
