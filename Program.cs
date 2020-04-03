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

            int count = 0;
            try
            {
                foreach (line m in f1.linesInFile)
                {
                    if (m.line_ != f2.linesInFile[count].line_)
                    {
                        same = false; 
                        //Console.WriteLine($"{m.line_} is different as line {count}.\n'{m.line_}'\n'{f2.linesInFile[count].line_}'"); // Can be broken into lines to show individual lines, the the positions in those lines.
                        int innerCount = 0;
                        foreach(char i in m.line_)
                        {
                            if (m.line_[innerCount] != f2.linesInFile[count].line_[innerCount]) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{m.line_[innerCount]}"); // Check line by line, then do a more thorough char by char check (less instructions are executed this way)
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write($"{m.line_[innerCount]}");
                            }
                            innerCount++;
                        }
                    }
                    count++;
                }
                if (same == true)
                {
                    Console.WriteLine("Line by line, they're the same.");
                }
            }
            catch
            {
                return; // throws us out so we dont waste CPU cycles.
            }
        }


    }
}
