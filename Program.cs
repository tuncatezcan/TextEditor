using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    class Program
    {
        static List<string> lines = new List<string>();

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                LoadFile(args[0]);
            }

            while (true)
            {
                Console.WriteLine("1. Load a file");
                Console.WriteLine("2. Save the file");
                Console.WriteLine("3. Display the file");
                Console.WriteLine("4. Add a line");
                Console.WriteLine("5. Insert a line");
                Console.WriteLine("6. Delete a line");
                Console.WriteLine("7. Quit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the file name: ");
                        LoadFile(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Enter the file name: ");
                        SaveFile(Console.ReadLine());
                        break;
                    case "3":
                        DisplayFile();
                        break;
                    case "4":
                        AddLine();
                        break;
                    case "5":
                        InsertLine();
                        break;
                    case "6":
                        DeleteLine();
                        break;
                    case "7":
                        return;
                }
            }
        }

        static void LoadFile(string fileName)
        {
            try
            {
                lines = new List<string>(File.ReadAllLines(fileName));
                Console.WriteLine("File loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();
        }

        static void SaveFile(string fileName)
        {
            try
            {
                File.WriteAllLines(fileName, lines);
                Console.WriteLine("File saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();
        }

        static void DisplayFile()
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        static void AddLine()
        {
            Console.Write("Enter a line: ");
            lines.Add(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Line added successfully.");
            Console.WriteLine();
        }

        static void InsertLine()
        {
            Console.Write("Enter a line: ");
            string line = Console.ReadLine();

            Console.Write("Enter the line number: ");
            int lineNumber = int.Parse(Console.ReadLine());

            lines.Insert(lineNumber - 1, line);
            Console.WriteLine();
            Console.WriteLine("Line inserted successfully.");
            Console.WriteLine();
        }

        static void DeleteLine()
        {
            Console.Write("Enter the line number: ");
            int lineNumber = int.Parse(Console.ReadLine());

            lines.RemoveAt(lineNumber - 1);
            Console.WriteLine();
            Console.WriteLine("Line deleted successfully.");
            Console.WriteLine();
        }
    }
}
