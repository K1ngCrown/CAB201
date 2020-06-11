using System;
using System.IO;

namespace MRRCManagement
{
    class rental
    {

        /// <summary>
        /// Controls how to access rental functions
        /// </summary>
        public static void rentalMangement()
        {
            Console.Clear();
            Console.WriteLine("Please enter a character from the options below:");
            Console.WriteLine("\n");

            Console.WriteLine("a) Display Rentals");
            Console.WriteLine("b) Search Vehicles");
            Console.WriteLine("c) Rent Vehicle");
            Console.WriteLine("d) Return Vehicle");

            Management.inputLine();


            string key = Console.ReadLine();

            if (key == "a" | key == "A")
            {
                displayRentals();
            }
            else if (key == "b" | key == "B")
            {
                searchCar();
            }
            else if (key == "c" | key == "C")
            {
                rentVehicle();
            }
            else if (key == "d" | key == "D")
            {
                returnVehicle();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape")
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
                rentalMangement();
            }

        }


        public static void displayRentals()
        {
            //the location of the rentals data file
            Management.rentalPath = (Management.path + "rentals.csv");

            Console.WriteLine("\n");
            using (var reader = new StreamReader(Management.rentalPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    string[] words = currentLine.Split(',');
                    Console.WriteLine(String.Join(" | ", words));
                }
                Management.inputLine();
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    rentalMangement();
                }
                else if (key == "escape" | key == "Escape" | key == "exit")
                {
                    Environment.Exit(0);
                }
                rentalMangement();
            }

        }
        public static void searchCar()
        {
            Management.fleetPath = (Management.path + "fleet.csv");

            //List<string> query = new List<string>();
            string s = "I want to walk";
            //string[] words = s.Split(" ");

            Console.Write("Enter your query: ");
            string query = Console.ReadLine();

            string AND = ("&&");
            string OR = ("||");

            bool isMultiple = false;
            bool isAnd = false;


            if (query.ToLower().Contains(" or ") || query.ToLower().Contains(" and "))
            {
                if (query.ToLower().Contains(" and ")) isAnd = true;
                isMultiple = true;
            }

            // big massive dick

            try
            {
                using (var reader = new StreamReader(Management.fleetPath))
                {

                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (isMultiple)
                        {
                            if (isAnd)
                            {
                                // "Petrol AND Red"
                                // ["Petrol", "Red"]
                                string[] andArray = query.ToLower().Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries);

                                if (
                                    (currentLine.ToLower().Contains(query.ToLower().Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries)[0])) &
                                    (currentLine.ToLower().Contains(query.ToLower().Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries)[1]))
                                )
                                {
                                    Console.WriteLine(currentLine);
                                }
                            }

                            if (
                                (currentLine.ToLower().Contains(query.ToLower().Split(new string[] { " or " }, StringSplitOptions.RemoveEmptyEntries)[0])) ||
                                (currentLine.ToLower().Contains(query.ToLower().Split(new string[] { " or " }, StringSplitOptions.RemoveEmptyEntries)[1]))
                            )
                            {
                                Console.WriteLine(currentLine);
                            }
                        }

                        // (currentLine.Contains(query) || currentLine.Contains(query))
                        else
                        {
                            if (currentLine.ToLower().Contains(query.ToLower()))
                            {
                                Console.WriteLine(currentLine);
                            }
                        }

                    }
                    Console.WriteLine("done1");

                }
                Console.ReadLine();
                Console.WriteLine("done2");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            rentalMangement();
        }


        public static void rentVehicle()
        {
            Console.WriteLine();


        }

        public static void returnVehicle()
        {



        }
    }
}
