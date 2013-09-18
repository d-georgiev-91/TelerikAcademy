namespace InsertProductsIntoDatabase
{
    using System;
    using System.Data.SqlClient;

    class InsertProductsIntoDatabase
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            ConnectToDB();
            InsertProduct("Srybska nadenica pich");
            DisconnectFromDB();
        }

        private static void ConnectToDB()
        {
            dbCon = new SqlConnection(ConnectionSettings.Default.DBConnectionString);
            dbCon.Open();
        }

        private static void InsertProduct(string name)
        {
            SqlCommand cmdInsertProduct = new SqlCommand(
                "INSERT INTO Products(ProductName) " +
                "VALUES (@name)", dbCon);
            cmdInsertProduct.Parameters.AddWithValue("@name", name);
            cmdInsertProduct.ExecuteNonQuery();
        }

        private static void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }
    }
}