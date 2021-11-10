namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Microsoft.Extensions.Configuration;
    using System.Data.SqlClient;

    public abstract class DaoBase
    {
        public IConfiguration _configuration;

        public DaoBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection NewSqlConnection
        {
            get
            {
                var connectionString = string.Format(_configuration.GetConnectionString("DefaultConnection"), _configuration["DB_PASSWORD"]);
                return new SqlConnection(connectionString);
            }
        }
    }
}