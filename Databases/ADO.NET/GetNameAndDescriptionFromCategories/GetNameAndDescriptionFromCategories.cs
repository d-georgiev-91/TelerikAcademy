namespace GetNameAndDescriptionFromCategories
{
    using System;
    using System.Data.SqlClient;

    class GetNameAndDescriptionFromCategories
    {
        static void Main()
        {
            SqlConnection databaseConection = new SqlConnection(ConnectionSettings.Default.DBConnectionString);
            databaseConection.Open();
            using (databaseConection)
            {
                SqlCommand commandGetCategoryNameAndDescription = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", databaseConection);
                SqlDataReader reader = commandGetCategoryNameAndDescription.ExecuteReader();
                ReadData(reader);
            }
        }
  
        private static void ReadData(SqlDataReader reader)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", categoryName, description);
                }
            }
        }
    }
}
