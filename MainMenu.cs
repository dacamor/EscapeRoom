using System;

namespace EscapeRoom
{
    public class MainMenu
    {
        public static int Show()
        {
            Console.Clear();
            Console.WriteLine ("WELCOME TO NSS Escape Room");
            Console.WriteLine ("**************************************");
            Console.WriteLine ("1. Create Backend");
            Console.WriteLine ("2. Create Instructor");
            Console.WriteLine ("3. Add Cohort");
            Console.WriteLine ("4. Add Alumni");
            Console.WriteLine ("5. Exit");
            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            return int.Parse(enteredKey.KeyChar.ToString());
        }
    }
}