using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using webApi_Net8.Helper;
using webApi_Net8.request;
using webApi_Net8.response;

namespace webApi_Net8.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = nameof(ApiVersions.v2))]
    public class WeatherForecastController: ControllerBase
    {
        private readonly string _connectionString;
        #region ÔÝÊ±²»ÄÜÉ¾

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        #endregion









    }
}
