using System;

namespace MRRCManagement
{
    /// <summary>
    /// This class creates the user interface and controls which funcations the user can access within the applcation
    /// </summary>
    public class Management
    {
        //              C:\Users\laser\Documents\CAB201\Assignment\CAB201_Assign_Current\MRRC\Data\

        public static string path;
        public static string customerPath;
        public static string fleetPath;
        public static string rentalPath;


        public static void inputLine()
        {
            Console.WriteLine("\n");
            Console.Write(">");
        }

        public static void userPath()
        {
            Console.WriteLine("Type file path");
            path = Console.ReadLine();

            Console.Clear();
            userInterface();


        }

        public static void userInterface()
        {

            //User Interface Initial Choices
            Console.WriteLine("### Mates-Rates Rent-a-Car Operation Menu ###");
            Console.WriteLine("\nYou May type escape or exit at any time to quit the program. Type back to return to the previous menu.");
            Console.WriteLine("\nPlease enter a letter from the options below:");

            Console.WriteLine("a) Customer Management");
            Console.WriteLine("b) Fleet Management");
            Console.WriteLine("c) Rental Management");

            //controls which management system to go to
            inputLine();

            string key = Console.ReadLine();

            if (key == "a" | key == "A")
            {
                customer.customerManagement();
            }
            else if (key == "b" | key == "B")
            {
                fleet.fleetMangement();
            }
            else if (key == "c" | key == "C")
            {
                rental.rentalMangement();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape" | key == "exit")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please try again");
                Console.WriteLine("\n");
                userInterface();
            }

        }

        /// <summary>
        /// Returns the user back to the interface after their option has been processed
        /// </summary>
        public static void interfaceReturn()
        {
            Console.Clear();
            userInterface();

        }

        static void Main(string[] args)
        {


        }
    }
}
