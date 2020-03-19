using System;
using System.IO;

namespace File_Comparison
{
    class Program
    {
        public static string f1 = "";
        public static string f2 = "";
        public static bool same = true;
        static void Main(string[] args)
        {
            UI(Console.ReadLine());
            //string inpt = Console.ReadLine();
            //string inpt2 = Console.ReadLine();
            //readFile(inpt, inpt2);
        }
        static void readFile(string inpt, string inpt2) // Reads the contents of the file in to be inspected by the dataCheck() function.
        {
            try
            {
                using(StreamReader a = new StreamReader(inpt)) // This could be its own function, and it could just be iterated. 
                {
                    string line;
                    while((line = a.ReadLine()) != null) // Reads line by line
                    {
                        f1 = f1 + line; // Adds to a string.
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read."); // If the file isnt there, tell the user.
            }
            try
            {
                using (StreamReader a = new StreamReader(inpt2))
                {
                    string line;
                    while ((line = a.ReadLine()) != null)
                    {
                        f2 = f2 + line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read.");
            }

        }
        static void UI(string conInput)
        {
            string[] command = conInput.Split(" ");
            switch(command[0]){                                         // Switch statement is used to make it harder to break with bogus input, whilst also making it easier to read when adding new features.
                case "diff":
                    if (command.Length != 3)
                    {
                        Console.WriteLine("Too many/few arguments.");
                        break;
                    }
                    readFile(command[1], command[2]);
                    dataCheck(); 
                    if(same != true)
                    {
                        Console.WriteLine("They are different files.");
                    }
                    else
                    {
                        Console.WriteLine("They're the same file.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        static void dataCheck()
        {
            if(f1.Length != f2.Length) // Checks the size of the file by the data in the file. *File* size is irrelevant in this check. 
            {
                same = false;
            }
            else
            {
                Console.WriteLine("Theyre the same size.");
            }

            char[] f1_ = f1.ToCharArray();
            char[] f2_ = f2.ToCharArray();
            int count = 0;
            try
            {
                foreach (char m in f1)
                {
                    if (m != f2[count])
                    {
                        same = false;
                    }
                    count++;
                }
            }
            catch
            {
                // This is just to stop it complaining if a list is bigger than another.
            }
        }

    }
}
