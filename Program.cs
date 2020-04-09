using System;
using System.IO;
using System.Collections.Generic;

namespace File_Comparison
{
    public class Program
    {
        public static string f1 = "";
        public static string f2 = "";
        public static bool same = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Commands are: diff <first file name> <second file name>\nPlace file in the executables folder.");
            UI(Console.ReadLine());
        }
       
        static void UI(string conInput)
        {
            string[] command = conInput.Split(" ");
            switch (command[0]) {                                         // Switch statement is used to make it harder to break with bogus input, whilst also making it easier to read when adding new features.
                case "diff":
                    if (command.Length != 3)
                    {
                        Console.WriteLine("Too many/few arguments.");
                        break;
                    }
                    readFile a = new readFile(command[1]);
                    readFile b = new readFile(command[2]);
                    dataCheck F = new dataCheck(a, b);
                    if (F.same != true)
                    {
                        Console.WriteLine("\nThey are different files.");
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
        

    }
    public class readFile {
        string fileData = ""; // Store as  string, convert to char array later.
        public List<line> linesInFile = new List<line>(); // A list of lines is created, thus each one can be checked one by one. 
        public char[] fileDataAnalysis = { }; // This is public as it will be checked later.
        public readFile(string fileName)
        {
            try
            {
                using (StreamReader a = new StreamReader(fileName))  
                {
                    string line_;
                    while ((line_ = a.ReadLine()) != null) // Reads line by line
                    {
                        
                        fileData = fileData + line_; // Adds to a string.
                        line t = new line(); // Adds line to list, lists only have one attribute, which is a string so its not too hard.
                        t.line_ = line_;
                        linesInFile.Add(t);
                    }
                }
                fileDataAnalysis = fileData.ToCharArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read."); // If the file isn't there, tell the user.
            }
        }
    }
    public class line
    {
         public string line_ = "";  // Lines are used to anylize each part of the code line by line, faster than the original character by character comparison.
    }
    public class dataCheck
    {
        public bool same = true;
        public dataCheck(readFile f1, readFile f2) // Same as the one above, but in this case uses a char array.
        {
            if (f1.fileDataAnalysis.Length != f2.fileDataAnalysis.Length) // Checks the size of the file by the data in the file. *File* size is irrelevant in this check. 
            {
                same = false;
            }
            else
            {
                Console.WriteLine("They're the same size.");
            }

            readFile FileLargest = f1;
            readFile FileSmallest = f2;
            if (f1.fileDataAnalysis.Length <= f2.fileDataAnalysis.Length)
            {
                FileLargest = f2;
                FileSmallest = f1;
            }

            int count = 0;  
            while (count < FileLargest.linesInFile.Count) { // trying to get it to show every line, not just the first
                 
            try
            {
                lineByLine(FileLargest, FileSmallest, count);
            }
            catch
            {
                    // Nothing. Very poor practice, but it causes no harm here.
            } 
            count++;
            }


                if (same == true)
                {
                    Console.WriteLine("Line by line, they're the same.");
                }
        }

        public void lineByLine(readFile FileLargest, readFile FileSmallest, int count)
        {
                int innerCount = 0;
                foreach (char i in FileLargest.linesInFile[count].line_)
                {
                    if (FileLargest.linesInFile[count].line_[innerCount] != FileSmallest.linesInFile[count].line_[innerCount])
                    {
                        same = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{FileLargest.linesInFile[count].line_[innerCount]}"); // Check line by line, then do a more thorough char by char check (less instructions are executed this way)
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write($"{FileLargest.linesInFile[count].line_[innerCount]}");
                    }
                    innerCount++;
                }
        }

    }
}
