using System;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the database interface
            DatabaseInterface db = new DatabaseInterface();

            // Check/create the Account table
            db.CreateDatabase();

            int choice;

            do
            {
                // Show the main menu by invoking the static method
                choice = MainMenu.Show();

                switch (choice)
                {
                    // Menu option 1: Create a backend
                    case 1:
                        // Ask user to input customer name
                        string BackendName = Console.ReadLine();

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Backend
                            (Id, Name)
                            VALUES
                            (null, '{BackendName}')
                        ");
                        break;

                    // Menu option 5: Exit
                    case 5:
                        // need logic
                    break;
                }
            } while (choice != 5);



        }
    }
}
