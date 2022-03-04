namespace Otal.lmaoo.Data.DataAccessObjects.Base
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
                var connectionString = string.Format("Data Source={0},{1};Database={2};User Id=sa;Password={3}",
                                                      _configuration["DB_SOURCE"],
                                                      "1433",
                                                      _configuration["DB_DATABASE"],
                                                      _configuration["DB_PASSWORD"]);

                return new SqlConnection(connectionString);
            }
        }
    }
}