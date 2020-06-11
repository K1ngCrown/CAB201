using System;
using System.IO;

namespace MRRCManagement
{
    class customer
    {

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

            Management.inputLine();
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
                Management.userInterface();
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
                customerManagement();
            }


        }


        /// <summary>
        /// Reads the data from the customer file and displays it onto the console
        /// </summary>
        public static void displayCustomers()
        {
            Management.customerPath = (Management.path + "customers.csv");

            using (var reader = new StreamReader(Management.customerPath))
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
                Management.inputLine();
                string key = Console.ReadLine();
                if (key == "back" | key == "Back")
                {
                    Console.Clear();
                    customerManagement();

                }
                else if (key == "escape" | key == "Escape" | key == "exit")
                {
                    Environment.Exit(0);
                }
                customerManagement();
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
            Management.customerPath = (Management.path + "customers.csv");

            using (StreamWriter outputFile = File.AppendText(Management.customerPath))
            {

                outputFile.Write(title + ",");
                outputFile.Write(fname + ",");
                outputFile.Write(lname + ",");
                outputFile.Write(gender + ",");
                outputFile.Write(dob);
            }

            Console.WriteLine("Successfully created a new customer '{0} {1} {2}' and added to customer list.", title, fname, lname);

            Console.ReadLine();
            customerManagement();

        }
    }
}
