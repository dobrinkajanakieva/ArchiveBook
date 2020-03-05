using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL_SQLServer
{
	public abstract class DBClass
	{
		public DBClass()  
		{

		}

		public string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Archive;Trusted_Connection=True;MultipleActiveResultSets=true";

		public SqlConnection connection { get; set; }
		public SqlCommand command { get; set; }
		public SqlDataReader reader { get; set; }
		public SqlDataAdapter adapter { get; set; }
	}
}
