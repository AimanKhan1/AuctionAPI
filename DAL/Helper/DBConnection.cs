using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helper
{
    public static class DBConnection
    {
        public static string connectionString { get; set; }

        public static void GetConnectionString(IConfiguration configuration)
        {
            connectionString = ConfigurationExtensions.GetConnectionString(configuration, "DevConnection");
        }
    }
}
