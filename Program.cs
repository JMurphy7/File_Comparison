using System;
using System.IO;

namespace File_Comparison
{
    class Program
    {
        public static string f1 = "";
        public static string f2 = "";
        static void Main(string[] args)
        {
            string input_ = Console.ReadLine();
            UI(input_);
            //string inpt = Console.ReadLine();
            //string inpt2 = Console.ReadLine();
            //readFile(inpt, inpt2);
        }
        static void readFile(string inpt, string inpt2)
        {
            try
            {
                using(StreamReader a = new StreamReader(inpt))
                {
                    string line;
                    while((line = a.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        f1 = f1 + line;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read.");
            }
            try
            {
                using (StreamReader a = new StreamReader(inpt2))
                {
                    string line;
                    while ((line = a.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        f2 = f2 + line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read.");
            }
            Console.WriteLine(f1);
            Console.WriteLine(f2);
        }
        static void UI(string conInput)
        {
            string[] command = conInput.Split(" ");
            switch(command[0]){
                case "diff":
                    if (command.Length != 3)
                    {
                        Console.WriteLine("Too many/few arguments.");
                        break;
                    }
                    readFile(command[1], command[2]);
                    sizeComp(); // to be continued
                    break;
                default:
                    Console.WriteLine("Default exit");
                    break;
            }
        }
        static void sizeComp()
        {

        }
    }
}
