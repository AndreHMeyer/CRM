using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Crm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        public ClientController(IConfiguration config)
        {
            MySqlConnection connection = new(config.GetConnectionString("crm"));
        }

        [HttpPost]
        public IActionResult Index()
        {
            return null;
        }
    }
}
