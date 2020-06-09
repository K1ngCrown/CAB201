using System;
using System.Data;
using System.IO;

namespace ConsoleApp
{
    public class test
    {

        /// <summary>
        /// Class to test reading capabilities
        /// </summary>
        public static void reading()
        {
            //the location of the fleet data file
            string home = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\fleet.csv";

            using (var reader = new StreamReader(home))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    Console.WriteLine(currentLine);
                    Console.WriteLine(reader.ReadLine());


                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("Registration");
                    dt.Columns.Add("Grade");
                    DataRow register = dt.NewRow();
                    register["Registration"] = "851ASD";
                    register["Grade"] = "Economy";
                    dt.Rows.Add(register);

                    //Table.Columns();

                }
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Class to test writing capabilities
        /// </summary>
        public static void writing()
        {
            // Create a string array with the lines of text
            //Console.WriteLine("Write Something");
            //string lines = Console.ReadLine();

            string title;
            string fname;
            string lname;
            string gender;
            string dob;

            Console.Write("*Title: ");
            title = Console.ReadLine();
            Console.Write("\n*FirstName: ");
            fname = Console.ReadLine();
            Console.Write("\n*LastName: ");
            lname = Console.ReadLine();
            Console.Write("\n*Gender: ");
            gender = Console.ReadLine();
            Console.Write("\n*DOB: ");
            dob = Console.ReadLine();

            // Set a variable to the Documents path.
            string docPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\WriteLines.txt";

            // Write the string array to a new file named "WriteLines.txt".
            // using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            using (StreamWriter outputFile = File.AppendText(docPath))
            {
                //foreach (string line in lines)
                //outputFile.WriteLine(lines);
                outputFile.Write("\n" + title);
                outputFile.Write(" " + fname);
                outputFile.Write(" " + lname);
                outputFile.Write(" " + gender);
                outputFile.Write(" " + dob);
            }
        }


        /// <summary>
        /// Class to test file editing capabilities
        /// </summary>
        public static void editing()
        {
            string docPath = @"C:\Users\laser\Documents\CAB201\Assignment\MRRC\Data\WriteLines.txt";
            string test = File.ReadAllText(docPath);
            Console.WriteLine("Write What you want to change");
            string change = Console.ReadLine();
            Console.WriteLine("What do you want to replace it with?");
            string newText = Console.ReadLine();

            test = test.Replace(change, newText);


            StreamReader reading = File.OpenText("docPath");
            string str;
            while ((str = reading.ReadLine()) != null)
            {
                if (str.Contains("some text"))
                {
                    StreamWriter write = new StreamWriter("docPath");
                }
            }
        }
    }
}
