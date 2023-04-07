using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCondo_Finance_Data.Context
{
    public class UCondo_Finance_Context
    {
        public SqlConnection GetConnection()
        {
            string _connectionString = $@"Server=.\SQLExpress;Database=UcondoFinance;Trusted_Connection=True;";
            return new SqlConnection(_connectionString);
        }
    }
}
