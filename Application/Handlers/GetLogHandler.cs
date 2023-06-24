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
    public class GetLogHandler
    {
        private ILogRepository logRepository;

        public GetLogHandler(MySqlConnection mySqlConnection)
        {
            logRepository = new LogRepository(mySqlConnection);
        }

        public List<Log> Handle()
        {
            try
            {
                return logRepository.GetLogs().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
