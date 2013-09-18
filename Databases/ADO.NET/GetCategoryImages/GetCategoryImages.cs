namespace GetCategoryImages
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    class GetCategoryImages
    {
        private static SqlConnection databaseConnection;
        private const int OleMetafilepictStartPosition = 78;
        private const string ImageStorePath = "..\\..\\Images\\";

        static void Main()
        {
            ConnectToDB();
            Directory.CreateDirectory(ImageStorePath);
            RenderImagesFromDB();
            DisconnectFromDB();
        }

        private static void ConnectToDB()
        {
            databaseConnection = new SqlConnection(ConnectionSettings.Default.DBConnectionString);
            databaseConnection.Open();
        }

        private static void RenderImagesFromDB()
        {
            SqlCommand command = new SqlCommand(
                                                "SELECT CategoryName, Picture " +
                                                "FROM Categories", databaseConnection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = ((string)reader["CategoryName"]);
                    if (categoryName.Contains('/') == true)
                    {
                        categoryName = categoryName.Replace('/', ' ');
                    }
                    byte[] pictureBytes = reader["Picture"] as byte[];
                    SaveImageAsJpeg(pictureBytes, categoryName, ImageStorePath);
                }
            }
        }

        private static void SaveImageAsJpeg(byte[] pictureBytes, string fileName, string directory)
        {
            MemoryStream stream = new MemoryStream(
                pictureBytes, OleMetafilepictStartPosition,
                pictureBytes.Length - OleMetafilepictStartPosition);
            Image image = Image.FromStream(stream);
            using (image)
            {
                image.Save(directory + fileName + ".jpg", ImageFormat.Jpeg);
            }
        }

        private static void DisconnectFromDB()
        {
            if (databaseConnection != null)
            {
                databaseConnection.Close();
            }
        }
    }
}