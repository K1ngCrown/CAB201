using System;
using System.IO;


namespace MRRCManagement
{
    class fleet
    {
        /// <summary>
        /// Gives the user the choose a fleet function
        /// </summary>
        public static void fleetMangement()
        {
            Console.Clear();
            Console.WriteLine("Please enter a character from the options below:");
            Console.WriteLine("\n");

            Console.WriteLine("a) Display Fleet");
            Console.WriteLine("b) New Vehicle");
            Console.WriteLine("c) Modify Vehicle");
            Console.WriteLine("d) Delete Vehicle");

            Management.inputLine();

            string key = Console.ReadLine();
            if (key == "a" | key == "A")
            {
                displayFleet();
            }
            else if (key == "b" | key == "B")
            {
                newVehicle();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape" | key == "exit")
            {
                Environment.Exit(0);
            }
            else if (key == "back" | key == "Back")
            {
                Console.Clear();
                Management.userInterface();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please try again");
                Console.WriteLine("\n");
                fleetMangement();
            }

        }

        /// <summary>
        /// Reads the data from the f file and displays it onto the console
        /// </summary>
        public static void displayFleet()
        {
            //the location of the fleet data file
            Management.fleetPath = (Management.path + "fleet.csv");

            using (var reader = new StreamReader(Management.fleetPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    //needs to be able to split at newline as well FIX THIS
                    string[] words = currentLine.Split(',');

                    Console.WriteLine(String.Join(" ", words));

                }
                Management.inputLine();
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    fleetMangement();

                }
                else if (key == "escape" | key == "Escape" | key == "exit")
                {
                    Environment.Exit(0);
                }
                fleetMangement();
            }

        }

        /// <summary>
        /// Opens the file and asks the user for information so that it can be added to the data file in order to create a new vehicle
        /// </summary>
        public static void newVehicle()
        {
            Console.WriteLine("Please fill the following fields (fields marked with * are required)\n");

            string registration;
            string grade;
            string make;
            string model;
            string year;
            string numSeats;
            string transmission;
            string fuel;
            string gps;
            string sunRoof;
            string dailyRate;
            string colour;

            Console.Write("*Registration: ");
            registration = Console.ReadLine();
            Console.Write("*Grade: ");
            grade = Console.ReadLine();
            Console.Write("*Make: ");
            make = Console.ReadLine();
            Console.Write("*Model: ");
            model = Console.ReadLine();
            Console.Write("*Year of production: ");
            year = Console.ReadLine();
            Console.Write("*Number of Seats: ");
            numSeats = Console.ReadLine();
            Console.Write("*Transmission type: ");
            transmission = Console.ReadLine();
            Console.Write("*Fuel type: ");
            fuel = Console.ReadLine();
            Console.Write("*GPS: ");
            gps = Console.ReadLine();
            Console.Write("*Sunroof: ");
            sunRoof = Console.ReadLine();
            Console.Write("*Daily Rate of cost: ");
            dailyRate = Console.ReadLine();
            Console.Write("*Car colour: ");
            colour = Console.ReadLine();

            //fleet file path
            Management.fleetPath = (Management.path + "fleet.csv");

            using (StreamWriter outputFile = File.AppendText(Management.fleetPath))
            {

                outputFile.Write("\n" + registration);
                outputFile.Write(" " + grade);
                outputFile.Write(" " + make);
                outputFile.Write(" " + model);
                outputFile.Write(" " + year);
                outputFile.Write(" " + numSeats);
                outputFile.Write(" " + transmission);
                outputFile.Write(" " + fuel);
                outputFile.Write(" " + gps);
                outputFile.Write(" " + sunRoof);
                outputFile.Write(" " + dailyRate);
                outputFile.Write(" " + colour);
            }

            Console.WriteLine("Successfully created a new vehicle '{0} {1} {2} {3}' and added to vehicle list.", registration, make, model, year);

            Console.ReadLine();
            fleetMangement();

        }

    }
}
