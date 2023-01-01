using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal static partial class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "C# Algorithm Task 1";
        var taskList = new List<string>();

        for (int i = 1; i <= 10; i++)
            taskList.Add(i + " - Task " + i);

        taskList.Add("0 - Exit");

        bool continueTaskLoop;

        do
        {
            Console.Clear();
            writeToConsole(new string[] { "C# Algorithm Task 1" });
            writeToConsole(taskList.ToArray());

            int taskNumber;
            string tmpInput;
            bool valid;

            do
            {
                writeToConsole(new string[] { "Please enter Task Number:" });
                tmpInput = Console.ReadLine();

                if (int.TryParse(tmpInput, out taskNumber) == true)
                {
                    if (taskNumber >= 0 & taskNumber <= taskList.Count)
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                else
                {
                    valid = false;
                }
            }
            while (!valid);

            switch (taskNumber)
            {
                case 0:
                    {
                        exitModule();
                        break;
                    }

                case 1:
                    {
                        task1();
                        break;
                    }

                case 2:
                    {
                        task2();
                        break;
                    }

                case 3:
                    {
                        task3();
                        break;
                    }

                case 4:
                    {
                        task4();
                        break;
                    }

                case 5:
                    {
                        task5();
                        break;
                    }

                case 6:
                    {
                        task6();
                        break;
                    }

                case 7:
                    {
                        task7();
                        break;
                    }

                case 8:
                    {
                        task8();
                        break;
                    }

                case 9:
                    {
                        task9();
                        break;
                    }

                case 10:
                    {
                        task10();
                        break;
                    }

            }

            writeToConsole(new string[] { "Do you want to continue?", "Type 'yes' to continue" });
            if (Console.ReadLine() == "yes")
            {
                continueTaskLoop = true;
            }
            else
            {
                continueTaskLoop = false;
            }
        }

        while (continueTaskLoop);
    }

    public static void writeToConsole(string[] texts)
    {
        Console.Write(System.Environment.NewLine);

        foreach (var textItem in texts)
            Console.WriteLine(textItem);
    }

    public static void exitModule()
    {
        writeToConsole(new string[] { "Are you sure you want to exit?", "Type 'exit' to continue" });
        if (Console.ReadLine() == "exit")
        {
            Environment.Exit(0);
        }
    }

    public static object generateNumberList(string listType, int listCount, int randomLimit = 50, bool startWithZero = false)
    {
        var element = new List<int>();

        if (startWithZero)
        {
            element.Add(0);
        }
        else
        {
            listCount += 1;
        }

        int i = 1;

        switch (listType.ToLower() ?? "")
        {
            case "linear":
                {
                    while (i < listCount)
                    {
                        element.Add(i);
                        i += 1;
                    }

                    break;
                }

            case "random":
                {
                    while (i < listCount)
                    {
                        Random rnd = new Random();
                        int randomNumber = (int)(rnd.Next(0, randomLimit + 1));
                        element.Add(randomNumber);

                        i += 1;
                    }

                    break;
                }
        }

        return element;
    }

    public static void task1()
    {
        string str = "Code";

        writeToConsole(new string[] { "String: " + str, "First non-repeated character: " + task1_func(str) });
    }

    private static char task1_func(string input)
    {
        input = input.ToLower();

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (input.IndexOf(c) == input.LastIndexOf(c))
            {
                return c;
            }
        }

        return ' ';
    }

    public static void task2()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("linear", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Second highest number: " + task2_func(element.ToArray()) });
    }

    public static int task2_func(int[] input)
    {
        int max = int.MinValue;
        int secondMax = int.MinValue;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] > max)
            {
                secondMax = max;
                max = input[i];
            }
            else if (input[i] > secondMax)
            {
                secondMax = input[i];
            }
        }

        return secondMax;
    }

    public static void task3()
    {
        var stringList = new List<string>(new[] { "Visual Basic", "Racecar", "Task", "Civic", "People", "Noon", "Algorithm", "Pop", "List", "Rotator", "Level" });
        Random rnd = new Random();
        int randomNumber = (int)(rnd.Next(0, stringList.Count - 1));

        writeToConsole(new string[] { "String: " + stringList[randomNumber], task3_func(stringList[randomNumber]) ? "String is palindrome" : "String is not palindrome" });
    }

    public static bool task3_func(string input)
    {
        input = input.ToLower();
        for (int i = 0; i < input.Length / 2; i++)
        {
            if (input[i] != input[input.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    public static void task4()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Sum of all even numbers: " + task4_func(element.ToArray()) });
    }

    public static int task4_func(int[] input)
    {
        int sum = 0;
        foreach (int num in input)
        {
            if (num % 2 == 0)
            {
                sum += num;
            }
        }
        return sum;
    }

    public static void task5()
    {
        int[][] element = new int[][] {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9},
        };

        StringBuilder printStr = new StringBuilder();
        printStr.Append("[");

        for (int i = 0; i < element.GetLength(0); i++)
        {
            printStr.Append("[");

            for (int j = 0; j < element[i].GetLength(0); j++)
            {
                printStr.Append(element[i][j].ToString());

                if (j != element[i].GetLength(0) -1)
                {
                    printStr.Append(", ");
                }
            }

            printStr.Append("]");

            if (i != element.GetLength(0) - 1)
            {
                printStr.Append(", ");
            }
        }

        printStr.Append("]");

        writeToConsole(new string[] { "2D Array: " + printStr.ToString(), "Sum: " + task5_func(element) });
    }
    public static int task5_func(int[][] input)
    {
        int sum = 0;
        foreach (int[] row in input)
        {
            foreach (int n in row)
            {
                sum += n;
            }
        }
        return sum;
    }

    public static void task6()
    {
        var stringList = new List<string>(new[] { "Visual Basic", "Racecar", "Task", "Civic", "People", "Noon", "Algorithm", "Pop", "List", "Rotator", "Level" });
        Random rnd = new Random();
        int randomNumber = (int)(rnd.Next(0, stringList.Count - 1));

        writeToConsole(new string[] { "String: " + stringList[randomNumber], "String with vowels removed: " + task6_func(stringList[randomNumber]) });
    }

    public static string task6_func(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (!"aeiouAEIOU".Contains(c))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public static void task7()
    {
        var stringList = new List<string>(new[] { "Apple", "Banana", "Cat", "Dog", "Fish", "Cherry", "Butterfly" });
        Random rnd = new Random();
        int randomNumber = (int)(rnd.Next(0, stringList.Count - 1));

        writeToConsole(new string[] { "List: " + string.Join(", ", stringList), "String with at least 5 characters: " + string.Join(", ", task7_func(stringList)) });
    }

    public static List<string> task7_func(List<string> input)
    {
        return input.Where(s => s.Length >= 5).ToList();
    }

    public static void task8()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        Random rng = new Random();
        bool randomBool = rng.Next(2) == 1;

        if (randomBool)
        {
            element.Sort();
        }

        writeToConsole(new string[] { "List: " + string.Join(", ", element), task8_func(element) ? "List is sorted in ascending order" : "List is not sorted in ascending order" });
    }

    public static bool task8_func(List<int> input)
    {
        for (int i = 0; i < input.Count - 1; i++)
        {
            if (input[i] > input[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static void task9()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);
        element.Sort();

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Second smallest number: " + task9_func(element) });
    }

    public static int task9_func(List<int> input)
    {
        return input.OrderBy(n => n).Skip(1).First();
    }

    public static void task10()
    {
        var stringList = new List<string>(new[] { "Apple", "Banana", "Level", "Cherry", "Date", "Pop", "Noon" });

        writeToConsole(new string[] { "List: " + string.Join(", ", stringList), "Strings that start and end with same letter: " + string.Join(", ", task10_func(stringList)) });
    }

    public static List<string> task10_func(List<string> input)
    {
        return input.Where(s => s[0].ToString().ToLower() == s[s.Length - 1].ToString().ToLower()).ToList();
    }

}