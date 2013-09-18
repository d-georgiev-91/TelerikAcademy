namespace InsertRowsIntoExcel
{
    using System;
    using System.Data.OleDb;
    using System.Linq;

    class InsertRowsIntoExcel
    {
        static OleDbConnection excelConnection;

        static void Main()
        {
            ConnectToExcel();
            InsertNameAndScoreIntoExcel("Pesho", 12);
            InsertNameAndScoreIntoExcel("Stamat", 42);
            InsertNameAndScoreIntoExcel("Gencho", 65);
            InsertNameAndScoreIntoExcel("Minka", 92);
            DisconnectFromExcel();
        }

        private static void InsertNameAndScoreIntoExcel(string name, int score)
        {
            OleDbCommand oleCmdInsertTo = new OleDbCommand(
                    @"INSERT INTO [Sheet1$](Name, Score)
                    VALUES (@name, @score)", excelConnection);
            oleCmdInsertTo.Parameters.AddWithValue("@name", name);
            oleCmdInsertTo.Parameters.AddWithValue("@score", score);
            oleCmdInsertTo.ExecuteNonQuery();

            Console.WriteLine("Data added");
        }
  
        private static void ConnectToExcel()
        {
            excelConnection = new OleDbConnection(Connection.Default.ExcelConnectionString);
            excelConnection.Open();
        }

        private static void DisconnectFromExcel()
        {
            if (excelConnection != null)
            {
                excelConnection.Close();
            }
        }
    }
}