using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{

		static void Main(string[] args)
		{
			string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data.mdf;Integrated Security=True;User Instance=True";
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string sql = "SELECT DISTINCT FORMAT(date,'yyyy-MM-dd') as date FROM time_reports";
			SqlCommand cmd = new SqlCommand(sql,sqlConnection);
			SqlDataReader reader = cmd.ExecuteReader();
			List<string> dates = new List<string>();
			while (reader.Read())
			{
				dates.Add(reader["date"].ToString());
			}
			reader.Close();
			sqlConnection.Close();

			
			foreach (string date in dates)
			{
				sqlConnection.Open();
				sql = "SELECT DATENAME(dw,date) as dayname,employess.*, time_reports.* FROM employess INNER JOIN time_reports ON time_reports.employee_id=employess.id where date='" + date+"'";
				cmd = new SqlCommand(sql, sqlConnection);
				reader = cmd.ExecuteReader();
				string dayCheck = null;
				while (reader.Read())
				{
					if (reader["dayname"].ToString() != dayCheck)
					{
						dayCheck = reader["dayname"].ToString();
						Console.Write("|" + Convert.ToString(reader["dayname"]) + "| " + Convert.ToString(reader["name"]) + " {" + Convert.ToString(reader["hours"]) + "}");
					}
					else
						Console.WriteLine(", "+ Convert.ToString(reader["name"]) + " {" + Convert.ToString(reader["hours"]) + "}");
				}
				sqlConnection.Close();
			}
			Console.ReadKey();
		}
	}
}
