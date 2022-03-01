using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLConnxTester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlConxController : ControllerBase
    {
        private readonly ILogger<SqlConxController> _logger;
        private IDbConnection _conx;

        public SqlConxController(IDbConnection conx,
            ILogger<SqlConxController> logger)
        {
            _logger = logger;
            _conx = conx;
        }

        [HttpGet]
        public string Get()
        {
            string ret = "";
            try
            { 
                using (_conx = new SqlConnection(_conx.ConnectionString))
                {
                    _conx.Open();
                    ret = "Connection Successful";
                    _conx.Close();
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message + ex.StackTrace;
            }
            return ret;
        }
    }
}
