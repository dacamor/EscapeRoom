using System;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface()
        {
            // Replace {you} with the correct value
            _connectionString = $"Data Source=./escaperoom.db";
            _connection = new SqliteConnection(_connectionString);
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler(dataReader);
                }

                dbcmd.Dispose();
            }
        }

        public void Update(string command)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery();
                dbcmd.Dispose();
            }
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose();
            }

            return insertedItemId;
        }

        public void CreateBackEnd()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `Id` FROM `Backend`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Backend` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();

            }
        }
        // creating the Instructor Table:
        public void CreateInstructor()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `Id` FROM `Instructor`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Instructor` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table Instructor already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        // Create Cohort Table
        public void CreateCohort()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Query the account table to see if table is created
                dbcmd.CommandText = $"SELECT `Id` FROM `Cohort`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Cohort` (
                            `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table Cohort already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }

        // 
    }
}
