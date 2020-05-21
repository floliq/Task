using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class databaseHandler
	{
		static string connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|Data.mdf;User Instance=True";
		static SqlConnection sqlConnection = new SqlConnection(connectionString);

		static void Test()
		{
			
			
		}
	}
}
