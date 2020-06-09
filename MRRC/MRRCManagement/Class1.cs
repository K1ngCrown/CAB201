using System;
using System.IO;

namespace MRRCManagement
{
    /// <summary>
    /// This class creates the user interface and controls which funcations the user can access within the applcation
    /// </summary>
    public class Management
    {

        public const string customerPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\customers.csv";
        public const string fleetPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\fleet.csv";
        public const string rentalPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\rentals.csv";

        public static void inputLine()
        {
            Console.WriteLine("\n");
            Console.Write(">");
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
                return;
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
            //string home = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\customers.csv";


            using (var reader = new StreamReader(customerPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {

                    string[] words = currentLine.Split(',');

                    string[] id = words[0].Split();
                    string[] title = words[1].Split();
                    string[] fname = words[2].Split();
                    string[] lname = words[3].Split();
                    string[] gender = words[4].Split();
                    string[] dob = words[5].Split();

                    foreach (var i in id)
                        foreach (var ti in title)
                            foreach (var fn in fname)
                                foreach (var ln in lname)
                                    foreach (var gen in gender)
                                        foreach (var d in dob)
                                        {
                                            Console.WriteLine("{0,0} {1,10} {2,10} {3,10} {4,10} {5,10}", i, ti, fn, ln, gen, d);
                                        }

                }
                Console.ReadLine();
                interfaceReturn();
            }
        }

        /// <summary>
        /// Reads the data from the f file and displays it onto the console
        /// </summary>
        public static void displayFleet()
        {
            //the location of the fleet data file
            //string home = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\fleet.csv";

            using (var reader = new StreamReader(fleetPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    //needs to be able to split at newline as well FIX THIS
                    string[] words = currentLine.Split(',');

                    string[] registration = words[0].Split();
                    string[] grade = words[1].Split();
                    string[] make = words[2].Split();
                    string[] model = words[3].Split();
                    string[] year = words[4].Split();
                    string[] seats = words[5].Split();
                    string[] transmission = words[6].Split();
                    string[] fuel = words[7].Split();
                    string[] gps = words[8].Split();
                    string[] sunRoof = words[9].Split();
                    string[] dailyRate = words[10].Split();
                    string[] colour = words[11].Split();


                    foreach (var register in registration)
                        foreach (var gra in grade)
                            foreach (var mak in make)
                                foreach (var mode in model)
                                    foreach (var yea in year)
                                        foreach (var seat in seats)
                                            foreach (var transm in transmission)
                                                foreach (var fue in fuel)
                                                    foreach (var gp in gps)
                                                        foreach (var sun in sunRoof)
                                                            foreach (var daily in dailyRate)
                                                                foreach (var col in colour)
                                                                {
                                                                    //System.Console.WriteLine($"{register} |\t {gra} |\t {mak} |\t {mode} |\t {yea} |\t {seat} |\t {transm} |\t {fue} |\t {gp}|\t {sun} |\t {daily} |\t {col} ");
                                                                    Console.WriteLine("{0,-20} {1,5} {2,20} {3,22} {4,24} {5,26} {6,28} {7,30} {8,32} {9,34} {10,36} {11,38}", register, gra, mak, mode, yea, seat, transm, fue, gp, sun, daily, col);
                                                                }


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
            //string home = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\rentals.csv";

            //reads the file line by line and splits the string up by , and places it into an array where it is then displayed from

            Console.WriteLine("\n");
            using (var reader = new StreamReader(rentalPath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {

                    string[] words = currentLine.Split(',');

                    string[] registration = words[0].Split();
                    string[] customerID = words[1].Split();

                    foreach (var cot in registration)
                        foreach (var dong in customerID)
                        {
                            System.Console.WriteLine($"{cot} | {dong} ");
                        }

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
            //string docPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\customers.csv";

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

            //string docPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\fleet.csv";

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


        static void Main(string[] args)
        {


        }
    }
}
