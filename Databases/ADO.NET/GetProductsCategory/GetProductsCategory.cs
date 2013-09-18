namespace GetProductsCategory
{
    using System;
    using System.Data.SqlClient;

    class GetProductsCategory
    {
        static void Main()
        {
            SqlConnection databaseConection = new SqlConnection(ConnectionSettings.Default.DBConnectionString);
            databaseConection.Open();
            using (databaseConection)
            {
                SqlCommand commandGetCategoryNameAndDescription = new SqlCommand(
                    @"SELECT c.CategoryName, p.ProductName 
                        FROM Products p
	                        JOIN Categories c
		                        ON p.CategoryID = c.CategoryID
                    ORDER BY c.CategoryName", databaseConection);
                SqlDataReader reader = commandGetCategoryNameAndDescription.ExecuteReader();
                ReadData(reader);
            }
        }

        private static void ReadData(SqlDataReader reader)
        {
            using (reader)
            {
                int cnt = 0;
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    cnt++;
                    Console.Write(cnt);
                    Console.WriteLine(". {0} - {1}", categoryName, productName);
                }
            }
        }
    }
}