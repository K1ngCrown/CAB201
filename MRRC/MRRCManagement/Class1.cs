using System;
using System.IO;

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
            Console.WriteLine("\nYou May press the ESC key at any time to exit. Press the BACKSPACE key to return to the previous menu.");
            Console.WriteLine("\nPlease enter a letter from the options below:");

            Console.WriteLine("a) Customer Management");
            Console.WriteLine("b) Fleet Management");
            Console.WriteLine("c) Rental Management");

            inputLine();
            string key = Console.ReadLine();
            //controls which management system to go to

            if (key == "a" | key == "A")
            {
                customerManagement();
            }
            else if (key == "b" | key == "B")
            {
                fleetMangement();
            }
            else if (key == "c" | key == "C")
            {
                rentalMangement();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape")
            {
                Environment.Exit(0);
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

        /// <summary>
        /// Controls how the customer data is used and displayed
        /// </summary>
        public static void customerManagement()
        {
            Console.Clear();
            Console.WriteLine("Please enter a character from the options below:");
            Console.WriteLine("\n");

            Console.WriteLine("a) Display Customers");
            Console.WriteLine("b) New Customers");
            Console.WriteLine("c) Modify Customers");
            Console.WriteLine("d) Delete Customers");

            inputLine();
            string key = Console.ReadLine();

            if (key == "a" | key == "A")
            {
                displayCustomers();

            }
            else if (key == "b" | key == "B")
            {
                newCustomer();
            }
            else if (key == "h" | key == "H")
            {
                Console.Clear();
                userInterface();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape")
            {
                Environment.Exit(0);
            }
            else if (key == "back" | key == "Back")
            {
                Console.Clear();
                userInterface();
            }



        }

        /// <summary>
        /// Controls how the customer data is used and displayed
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

            inputLine();

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
            else if (key == "escape" | key == "Escape")
            {
                Environment.Exit(0);
            }
            else if (key == "back" | key == "Back")
            {
                Console.Clear();
                userInterface();
            }

        }

        /// <summary>
        /// Controls how the rental data is manipulated
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

            inputLine();

            string[] correct_keys = { "a", "b" };
            string key = Console.ReadLine();

            if (key == "a" | key == "A")
            {
                displayRentals();
            }
            else if (key == "b" | key == "B")
            {
                searchCar();
            }
            //escape from program, type escape
            else if (key == "escape" | key == "Escape")
            {
                Environment.Exit(0);
            }
            else if (key == "back" | key == "Back")
            {
                Console.Clear();
                userInterface();
            }

        }

        /// <summary>
        /// Reads the data from the customer file and displays it onto the console
        /// </summary>
        public static void displayCustomers()
        {
            customerPath = (path + "customers.csv");

            using (var reader = new StreamReader(customerPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {

                    string[] words = currentLine.Split(',');

                    string id = words[0];
                    string title = words[1];
                    string fname = words[2];
                    string lname = words[3];
                    string gender = words[4];
                    string dob = words[5];


                    Console.WriteLine(String.Join(" ", words));

                }
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    customerManagement();

                }
            }
        }

        /// <summary>
        /// Reads the data from the f file and displays it onto the console
        /// </summary>
        public static void displayFleet()
        {
            //the location of the fleet data file
            fleetPath = (path + "fleet.csv");

            using (var reader = new StreamReader(fleetPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    //needs to be able to split at newline as well FIX THIS
                    string[] words = currentLine.Split(',');




                    Console.WriteLine(String.Join(" ", words));

                }
                inputLine();
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    fleetMangement();

                }
            }

        }

        public static void displayRentals()
        {
            //the location of the rentals data file
            rentalPath = (path + "rentals.csv");

            Console.WriteLine("\n");
            using (var reader = new StreamReader(rentalPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {

                    string[] words = currentLine.Split(',');

                    Console.WriteLine(String.Join(" | ", words));
                }

                inputLine();
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    rentalMangement();

                }
            }

        }


        /// <summary>
        /// Opens the file and asks the user for information so that it can be added to the data file in order to create a new customer
        /// </summary>
        public static void newCustomer()
        {
            Console.Clear();
            Console.WriteLine("Please fill the following fields (fields marked with * are required)\n");

            string title;
            string fname;
            string lname;
            string gender;
            string dob;

            Console.Write("*Title: ");
            title = Console.ReadLine();
            Console.Write("*FirstName: ");
            fname = Console.ReadLine();
            Console.Write("*LastName: ");
            lname = Console.ReadLine();
            Console.Write("*Gender: ");
            gender = Console.ReadLine();
            Console.Write("*DOB: ");
            dob = Console.ReadLine();

            //the location of the fleet customers file
            customerPath = (path + "customers.csv");

            using (StreamWriter outputFile = File.AppendText(customerPath))
            {

                outputFile.Write("\n" + title);
                outputFile.Write(" " + fname);
                outputFile.Write(" " + lname);
                outputFile.Write(" " + gender);
                outputFile.Write(" " + dob);
            }

            Console.WriteLine("Successfully created a new customer '{0} {1} {2}' and added to customer list.", title, fname, lname);

            Console.ReadLine();


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

            //fleet path
            fleetPath = (path + "fleet.csv");

            using (StreamWriter outputFile = File.AppendText(fleetPath))
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

        }

        public static void searchCar()
        {
            fleetPath = (path + "fleet.csv");

            /*
            try
            {
                Console.WriteLine(docPath);
            }
            catch
            {
                Console.WriteLine("no");
            }
            */
            Console.Write("Enter your query: ");
            string query = Console.ReadLine();
            /*
            if (query.Contains("OR"))
            {
                string[] see = query.Split(new string[] { "OR" }, StringSplitOptions.None);
                foreach (string ee in see){
                    Console.WriteLine(ee);
                }
            }
            */
            try
            {
                using (var reader = new StreamReader(fleetPath))
                {

                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (currentLine.Contains(query))
                        {
                            Console.WriteLine(currentLine);
                            //Console.WriteLine(reader.ReadLine());
                        }

                    }
                    Console.WriteLine("done");

                }
                Console.ReadLine();
                Console.WriteLine("done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {


        }
    }
}
