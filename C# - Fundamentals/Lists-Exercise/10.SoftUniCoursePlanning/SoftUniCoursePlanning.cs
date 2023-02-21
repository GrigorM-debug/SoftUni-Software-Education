using System;
using System.Runtime.CompilerServices;

internal class SoftUniCoursePlanningClass
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split(", ").ToList();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "course start")
        {
            string[] command = input.Split(":");

            list = SoftUniCoursePlanning(list, command);
        }

        for (int i = 0; i < list.Count; i++)
        {
           Console.WriteLine($"{i + 1}.{list[i]}");
        }

    }

    static List<string> SoftUniCoursePlanning(List<string> list, string[] command)
    {
        if (command[0] == "Add")
        {
            list = Add(list, command);
        }
        else if (command[0] == "Insert")
        {
            list = Insert(list, command);
        }
        else if (command[0] == "Remove")
        {
            list = Remove(list, command);
        }
        else if (command[0] == "Swap")
        {
            list = Swap(list, command);
        }
        else if (command[0] == "Exercise")
        {
            list = Exercise(list, command);
        }

        return list;
    }

    static List<string> Swap(List<string> list, string[] command)
    {
        string lessonOne = command[1];
        string lessonTwo = command[2];

        int indexOne = list.IndexOf(lessonOne);
        int indexTwo = list.IndexOf(lessonTwo);

        if (list.Contains(lessonOne) && list.Contains(lessonTwo))
        {
            string firstLesson = lessonOne;
            list[indexOne] = list[indexTwo];
            list[indexTwo] = firstLesson;
        }
        if (list.Contains(lessonOne + "-Exercise") && list.Contains(list[indexOne]))
        {
            indexOne = list.IndexOf(lessonOne);
            list.Remove(lessonOne + "-Exercise");
            list.Insert(indexOne + 1, lessonOne + "-Exercise");
        }

        else if (list.Contains(lessonTwo + "-Exercise") && list.Contains(list[indexTwo]))
        {
            indexTwo = list.IndexOf(lessonTwo);
            list.Remove(lessonTwo + "-Exercise");
            list.Insert(indexTwo + 1, lessonTwo + "-Exercise");
        }

        return list;
    }

    static List<string> Remove(List<string> list, string[] command)
    {
        string lesson = command[1];

        if (list.Contains(lesson))
        {
            list.Remove(lesson);
        }
        else if (list.Contains(lesson + "-Exercise"))
        {
            list.Remove(lesson + "-Exercise");
        }

        return list;
    }

    static List<string> Exercise(List<string> list, string[] command)
    {
        string lesson = command[1];

        if (list.Contains(lesson) && !list.Contains(lesson + "-Exercise"))
        {
            int index = list.IndexOf(lesson);
            list.Insert(index + 1, lesson + "-Exercise");
        }
        else if (!list.Contains(lesson))
        {
            list.Add(lesson);
            list.Add(lesson + "-Exercise");
        }

        return list;
    }

    static List<string> Insert(List<string> list, string[] command)
    {
        string lesson = command[1];
        int index = int.Parse(command[2]);

        if (!list.Contains(lesson))
        {
            list.Insert(index, lesson);
        }
        else
        {
            command.Skip(0);
        }

        return list;
    }

    static List<string> Add(List<string> list, string[] command)
    {
        string lesson = command[1];

        if (!list.Contains(lesson))
        {
            list.Add(lesson);
        }
        else
        {
            command.Skip(0);
        }

        return list;
    }
}