namespace ReadExcelFile
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    class ReadExcelFile
    {
        static void Main()
        {
            OleDbConnection excelConnection = new OleDbConnection(Connection.Default.ExcelConnectionString);
            Console.WriteLine(Connection.Default.ExcelConnectionString);
            excelConnection.Open();

            using (excelConnection)
            {
                OleDbCommand oleCmdSelect = new OleDbCommand("SELECT Supermarket “Bourgas – Plaza” FROM [Sheet1$]", excelConnection);
                OleDbDataReader reader = oleCmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int score = int.Parse(reader["Score"].ToString());
                    Console.WriteLine("{0} with scores {1}", name, score);
                }

                reader.Close();
            }
        }
    }
}