using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~~~ Document Merger ~~~~~ ");
            Console.WriteLine();

            string FirstFile;
            string SecondFile;

            do
            { //ask user for file names & verifies if they exist

                Console.WriteLine("Name of first file: ");
                  FirstFile = GetInput();
                Console.WriteLine("Name second file: ");
                  SecondFile = GetInput();

                string NewFileName = FirstFile.Substring(0, 4) + SecondFile.Substring(0, 4) + ".txt"; //combines file names, removes .txt from first/second files and adds it to end of combined name
                string NewFileText = Reader(FirstFile) + Reader(SecondFile); // combines file text

                NewFile(NewFileText, NewFileName);

                //display that file was saved if no exception

           Console.WriteLine("{0} was successfully saved. The document contains {1} characters", NewFileName, NewFileText.Length);

                //ask if user wants to merge two more

              Console.WriteLine("Would you like to merge any more? (y/n): ");

            } while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string GetInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (Check(input)) return input;
                Console.WriteLine("This file does not exist. Please try again.");

            } while (true);
        }

        static bool Check(string input)
        {
            if (File.Exists(input)) return true;

            return false;

        }

        static string Reader(string name) //reads file content
        {
            string content;
            string line = "";

            try
            {
                StreamReader sr = new StreamReader(name);

                content = sr.ReadLine();

                while(content != null)
                {
                    content += line;

                    content = sr.ReadLine();
                }
            }
            finally
            {

            }
            return line;
        }

        static void NewFile(string content, string name)
        {
            try
            {
                StreamWriter sw = new StreamWriter(name);

                sw.WriteLine(content);

                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Process failed: " + e.Message); //gives exceptions
                Environment.Exit(1);
            }
        }
    }
}
