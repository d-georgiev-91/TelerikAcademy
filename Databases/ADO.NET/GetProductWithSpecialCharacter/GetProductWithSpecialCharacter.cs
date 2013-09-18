namespace GetProductWithSpecialCharacter
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class GetProductWithSpecialCharacter
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            ConnectToDB();
            //InsertProduct("Salam 100% za vas");
            //InsertProduct("Nqkav product_");
            //InsertProduct("'Pesho e basi picha'");
            //InsertProduct("Neznam \\Koi she si");
            GetProductWhereNameLike("%");
            GetProductWhereNameLike("_");
            GetProductWhereNameLike("'");
            GetProductWhereNameLike("\\");
            DisconnectFromDB();
        }

        private static void ConnectToDB()
        {
            dbCon = new SqlConnection(Connection.Default.DBConnectionString);
            dbCon.Open();
        }

        private static void InsertProduct(string name)
        {
            try
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                                                             "INSERT INTO Products(ProductName) " +
                                                             "VALUES (@name)", dbCon);
                cmdInsertProduct.Parameters.AddWithValue("@name", name);
                cmdInsertProduct.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetProductWhereNameLike(string searchString)
        {
            SqlCommand cmdSelectProduct = new SqlCommand(
                @"SELECT ProductName FROM Products
                WHERE ProductName LIKE @searchString ESCAPE '!'", dbCon);
            cmdSelectProduct.Parameters.AddWithValue("@searchString", "%" + EscapeString(searchString) + "%");
            SqlDataReader reader = cmdSelectProduct.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string productName = reader["ProductName"].ToString();
                    Console.WriteLine(productName);
                }
            }
        }

        private static string EscapeString(string stringToEscape)
        {
            string escapedString = stringToEscape.Replace("%", "!%");
            return escapedString.Replace("_", "!_");
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