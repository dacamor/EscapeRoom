using System;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the database interface
            DatabaseInterface db = new DatabaseInterface();

            // Check/create the Account table
            // db.CreateBackEnd();

            int choice;

            do
            {
                // Show the main menu by invoking the static method
                choice = MainMenu.Show();

                switch (choice)
                {
                    // BackendInput:
                    // Menu option 1: Create a backend
                    case 1:
                        db.CreateBackEnd();
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


                    // Instructor input:
                    // Menu option #2
                    case 2:
                        db.CreateInstructor();
                        // Ask user to input customer name
                        string InstructorName = Console.ReadLine();

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Instructor
                            (Id, Name)
                            VALUES
                            (null, '{InstructorName}')
                        ");
                        break;


                    // Cohort input:
                    // Menu option #3
                    case 3:
                        db.CreateCohort();
                        // Ask user to input customer name
                        string CohortName = Console.ReadLine();


                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Cohort
                            (Id, Name)
                            VALUES
                            (null, '{CohortName}')
                        ");
                        break;

                    case 4:
                        db.CreateAlumni();
                        // Ask user to input customer name
                        Console.WriteLine("Please enter name");
                        string AlumniName = Console.ReadLine();
                        int CohortId = 0;
                        Console.WriteLine("What Cohort was the student a part of?");
                        string NameOfCohort = Console.ReadLine();

                        db.Query($@"SELECT `CohortId` FROM `Cohort` WHERE Cohort.Name = '{NameOfCohort}'", (SqliteDataReader reader) => {
                            while(reader.Read ())
                            {
                                CohortId = reader.GetInt32(0);
                                Console.WriteLine("CohortId:", CohortId);
                                Console.WriteLine("CohortName:", NameOfCohort);
                            }
                        }
                        );

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Alumni
                            (Id, Name, CohortId)
                            VALUES
                            (null, '{AlumniName}', '{CohortId}')
                        ");
                        break;

                }
            } while (choice != 5);

        }
    }
}
