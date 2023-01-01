using System;
using System.Collections.Generic;
using System.Linq;
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
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Largest value in List: " + task1_func(element) });
    }

    public static int task1_func(List<int> element)
    {
        return element.Max();
    }

    public static void task2()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("linear", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element) });

        task2_func(ref element);

        writeToConsole(new string[] { "Reversed List: " + string.Join(", ", element) });
    }

    public static void task2_func(ref List<int> element)
    {
        element.Reverse();
    }

    public static void task3()
    {
        var element = new List<int>();
        Random rnd = new Random();
        int randomNumber = (int)(rnd.Next(0, 15 + 1));
        element = (List<int>)generateNumberList("linear", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Random Number: " + randomNumber, task3_func(element, randomNumber) ? "Number occurred in List" : "Number did not occur in List" });
    }

    public static bool task3_func(List<int> element, int randomNumber)
    {
        bool numberOccurred = false;
        numberOccurred = element.Contains(randomNumber);

        return numberOccurred;
    }

    public static void task4()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Element in Odd Positions: " + string.Join(", ", task4_func(element)) });
    }

    public static List<int> task4_func(List<int> element)
    {
        var oddElement = new List<int>();

        for (int i = 0, loopTo = element.Count - 1; i <= loopTo; i++)
        {
            if (!(i % 2 == 0))
            {
                oddElement.Add(element[i]);
            }
        }

        return oddElement;
    }

    public static void task5()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Sum: " + string.Join(", ", task5_func(element)) });
    }
    public static int task5_func(List<int> element)
    {
        int sum = new int();
        sum = element.Sum();

        return sum;
    }

    public static void task6()
    {
        var stringList = new List<string>(new[] { "Visual Basic", "Racecar", "Task", "Civic", "People", "Noon", "Algorithm", "Pop", "List", "Rotator", "Level" });
        Random rnd = new Random();
        int randomNumber = (int)(rnd.Next(0, stringList.Count - 1));

        writeToConsole(new string[] { "String: " + stringList[randomNumber], task6_func(stringList, randomNumber) ? "String is Palindrome": "String is not Palindrome" });
    }

    public static bool task6_func(List<string> stringList, int randomNumber)
    {
        bool isPalindrome = false;

        char[] charArray = stringList[randomNumber].ToLower().ToCharArray();
        Array.Reverse(charArray);
        string reversedStr = string.Join("", charArray);

        if (stringList[randomNumber].ToLower() == reversedStr)
        {
            isPalindrome = true;
        }

        return isPalindrome;
    }

    public static object task7()
    {
        var element = new List<int>();
        element = (List<int>)generateNumberList("random", 10);

        writeToConsole(new string[] { "List: " + string.Join(", ", element), "Sum using for-loop: " + task7_ForLoop(element), "Sum using while-loop: " + task7_WhileLoop(element), "Sum using recursion: " + task7_Recursion(element, 0) });

        return element.Sum();
    }

    public static int task7_ForLoop(List<int> element)
    {
        int sumFor = new int();

        foreach (int num in element)
            sumFor += num;

        return sumFor;
    }

    public static int task7_WhileLoop(List<int> element)
    {
        int sumWhile = new int();

        bool hasNext = true;
        int i = 0;

        while (hasNext)
        {
            sumWhile += element[i];
            i += 1;

            if (element.Count == i)
            {
                hasNext = false;
            }
        }

        return sumWhile;
    }

    public static int task7_Recursion(List<int> element, int index)
    {
        if (index == element.Count - 1)
        {
            return element[index];
        }
        else
        {
            return element[index] + task7_Recursion(element, index + 1);
        }
    }

    public static void task8()
    {
        var perfectSquares = new List<int>();

        Func<int, int> square = x => x * x;
        perfectSquares = on_all(square);

        writeToConsole(new string[] { "Perfect Squares: " + string.Join(", ", perfectSquares) });
    }

    public static List<int> on_all(Func<int, int> func)
    {
        var resultList = new List<int>();

        for (int i = 1; i <= 20; i++)
            resultList.Add(func(i));

        return resultList;
    }

    public static object task9()
    {
        var element = new List<int>();
        var element2 = new List<string>();
        var resultList = new List<string>();

        element = (List<int>)generateNumberList("linear", 5);
        element2 = new List<string>(new[] { "A", "B", "C", "D", "E" });
        resultList = (List<string>)task9_func(element.ToArray(), element2.ToArray());

        writeToConsole(new string[] { "List1: " + string.Join(", ", element), "List2: " + string.Join(", ", element2), "Combined List: " + string.Join(", ", resultList) });

        return resultList;
    }

    public static object task9_func(Array list1, Array list2)
    {
        var resultList = new List<string>();

        foreach (var item in list1)
            resultList.Add(item.ToString());

        foreach (var item in list2)
            resultList.Add(item.ToString());

        return resultList;
    }

    public static object task10()
    {
        var element = new List<int>();
        var element2 = new List<string>();
        var resultList = new List<string>();

        element = (List<int>)generateNumberList("linear", 5);
        element2 = new List<string>(new[] { "A", "B", "C", "D", "E" });
        resultList = (List<string>)task10_func(element.ToArray(), element2.ToArray());

        writeToConsole(new string[] { "List1: " + string.Join(", ", element), "List2: " + string.Join(", ", element2), "Combined List: " + string.Join(", ", resultList) });

        return resultList;
    }

    public static object task10_func(Array list1, Array list2)
    {
        var resultList = new List<string>();

        int i = list1.Length - 1;
        int j = list2.Length - 1;
        var loopLimit = i >= j ? i : j;
        int loopIterator = 0;

        while (loopIterator <= loopLimit)
        {
            if (loopIterator <= i)
            {
                resultList.Add(list1.GetValue(loopIterator).ToString());
            }

            if (loopIterator <= j)
            {
                resultList.Add(list2.GetValue(loopIterator).ToString());
            }

            loopIterator += 1;
        }

        return resultList;
    }

}