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
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            }
        }
    }
}