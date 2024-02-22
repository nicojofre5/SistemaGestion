using SistemaGestionEntities.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private static string connectionString;
        static ProductoData()
        {
            ProductoData.connectionString = "Server= localhost\\sqlexpress ; Database = coderhouse; Trusted_Connection = True ; Integrated Security= True";
        }
        
        public static string ConnectionString
        {
            get { return connectionString; }
        }

    }
}
