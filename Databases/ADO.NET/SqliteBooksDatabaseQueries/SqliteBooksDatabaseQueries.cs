﻿namespace SqliteBooksDatabaseQueries
{
    using System;
    using System.Data.SQLite;

    class SqliteBooksDatabaseQueries
    {
        static SQLiteConnection dbCon;

        static void Main()
        {
            ConnectToDB();
            ListAllBooks();
            Console.WriteLine("Book id is {0}", FindBookByTitle("Pod Igoto"));
            Console.WriteLine("Book id is {0}", FindBookByTitle("None"));
            InsertBook("I, Robot", GetAuthorId("Isaac Asimov"), DateTime.Now, "5687978974640");
            ListAllBooks();
            DisconnectFromDB();
        }

        private static long GetAuthorId(string authorFullName)
        {
            var authorNames = authorFullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = authorNames[0];
            string lastName = authorNames[1];

            SQLiteCommand cmdSelectBooks = new SQLiteCommand(
               @"SELECT AuthorId
                    FROM Authors
                WHERE FirstName = @firstName AND LastName = @lastName", dbCon);
            cmdSelectBooks.Parameters.AddWithValue("@firstName", firstName);
            cmdSelectBooks.Parameters.AddWithValue("@lastName", lastName);

            SQLiteDataReader reader = cmdSelectBooks.ExecuteReader();

            long authorId = 0;

            if (!reader.HasRows)
            {
                throw new ArgumentException("No such author exsists in database");
            }
            else
            {
                reader.Read();
                authorId = (long)(reader["AuthorId"]);
            }

            reader.Close();

            return authorId;
        }

        private static void InsertBook(string title, long authorId, DateTime publishDate, string isbn)
        {
            SQLiteCommand commandInsertBook = new SQLiteCommand(
               "INSERT INTO Books(Title, AuthorId, PublishDate, ISBN) " +
               "VALUES (@title, @authorId, @publishDate, @isbn)", dbCon);
            commandInsertBook.Parameters.AddWithValue("@title", title);
            commandInsertBook.Parameters.AddWithValue("@authorId", authorId);
            commandInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
            commandInsertBook.Parameters.AddWithValue("@isbn", isbn);
            commandInsertBook.ExecuteNonQuery();
        }

        /// <summary>
        /// Prints The book author, publish data, ISBN and gets the bookid when it such book exsists
        /// </summary>
        /// <param name="searchTitle">The title you will search for</param>
        /// <returns>The Book ID if such books excsists else returns -1</returns>
        private static long FindBookByTitle(string searchTitle)
        {
            long bookId = -1;
            SQLiteCommand cmdSelectBooks = new SQLiteCommand(
                @"SELECT BookId, Title, FirstName || LastName as AuthorName, PublishDate, ISBN 
                    FROM Books b
                        JOIN Authors a
                            ON b.AuthorId = a.AuthorId
                WHERE Title = @title", dbCon);
            cmdSelectBooks.Parameters.AddWithValue("@title", searchTitle);
            SQLiteDataReader reader = cmdSelectBooks.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("No such book excsist in Database");
            }
            else
            {
                reader.Read();
                bookId = (long)(reader["BookId"]);
                string author = reader["AuthorName"].ToString();
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string isbn = reader["ISBN"].ToString();
                Console.WriteLine("The book has ISBN {0} published on {1:d/M/yyyy} \nWritten by {2}",
                    isbn, publishDate, author);
            }

            reader.Close();

            return bookId;
        }

        private static void ListAllBooks()
        {
            SQLiteCommand cmdSelectBooks = new SQLiteCommand(
                @"SELECT Title, FirstName || LastName as AuthorName, PublishDate, ISBN 
                    FROM Books b
                        JOIN Authors a
                            ON b.AuthorId = a.AuthorId", dbCon);
            SQLiteDataReader reader = cmdSelectBooks.ExecuteReader();

            while (reader.Read())
            {
                string title = reader["Title"].ToString();
                string author = reader["AuthorName"].ToString();
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string isbn = reader["ISBN"].ToString();
                Console.WriteLine("Book: {0} with ISBN {1} published on {2:d/M/yyyy} \nWritten by {3}", title, isbn, publishDate, author);
            }

            reader.Close();
        }

        private static void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        private static void ConnectToDB()
        {
            dbCon = new SQLiteConnection(Connection.Default.DBConnectionString);
            dbCon.Open();
        }
    }
}