namespace GetNumberOfRowsInCategories
{
    using System;
    using System.Data.SqlClient;

    public class GetNumberOfRowsInCategories
    {
        static void Main()
        {
            SqlConnection databaseConection = new SqlConnection(ConnectionSettings.Default.DBConnectionString);
            databaseConection.Open();
            using (databaseConection)
            {
                SqlCommand getRowsCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", databaseConection);
                int rowsCount = (int)getRowsCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", rowsCount);
                Console.WriteLine();
            }
        }
    }
}
