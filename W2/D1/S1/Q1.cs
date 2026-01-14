using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList studentNames = new ArrayList();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("stop", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (!IsValidName(input))
            {
                continue;
            }
            if (IsNameInCollection(studentNames, input))
            {
                Console.WriteLine($"{input} is already in the collection.");
            }
            else
            {
                studentNames.Add(input);
                Console.WriteLine($"{input} added to the collection.");
            }

        }
        DisplayStudentNames(studentNames);
    }

    public static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    public static bool IsNameInCollection(ArrayList studentNames, string name)
    {
        foreach (string existing in studentNames)
        {
            if (existing.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return true;

            }
            
        }
        return false;
    }
        public static void DisplayStudentNames(ArrayList studentNames)
        {
            Console.WriteLine("Unique student names entered:");
            foreach (string name in studentNames)
            {
                Console.WriteLine(name);
            }
        }
    }
