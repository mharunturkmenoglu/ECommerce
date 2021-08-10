using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.Abstract;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Data.Concrete
{
    public class AdoNetDataReader : IAdoNetDataReader
    {
        private readonly IConfiguration _config;

        public AdoNetDataReader(IConfiguration config)
        {
            _config = config;
        }

        public SqlDataReader GetDataReader(string queryScript)
        {
            var connectionString = _config.GetConnectionString("LocalDB");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(queryScript, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
    }
}
