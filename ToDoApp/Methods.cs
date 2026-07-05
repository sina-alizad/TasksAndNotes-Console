using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class Methods
    {
        public static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Tasks:\n\n");
            Console.ResetColor();
        }
        public static void NoTasks()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You have no tasks.\n");
            Console.ResetColor();
        }

        public static void Tasks(List<TaskItem> list)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Count; i++)
            {
                string checkbox = list[i].isComplete ? "[x]" : "[ ]";
                Console.WriteLine($"\n{i + 1}. {checkbox}  {list[i].Text}\n"); 
            }

            Console.ResetColor();
        }  // syntax of boolean notepad
        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEnter:\nA for Adding\nE for Editing\nD for Deleting\nT for Toggling\n");
            Console.ResetColor();
        }
        public static void ExitMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n...or X to exit.\n");
            Console.ResetColor();
        }
        public static void ClearAll()
        { Console.Clear(); Console.Write("\x1b[3J"); }

        public static void Add(List<TaskItem> list)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = TaskInput("\nAdd your task...\n");
            if (input == null)
                return;
            TaskItem task = new TaskItem();
            task.Text = input;
            task.isComplete = false;
            list.Add(task);
            Console.ResetColor();
            Files.Save(list);
        } // syntax notes
        public static void Edit(List<TaskItem> list)
        {
            try
            {
                if (list.Count == 0)
                { NoTasksError(); return; }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nChoose task to edit: \n");
                Tasks(list);
                int i = Convert.ToInt32(Console.ReadLine());
                if (i > list.Count || i < 1)
                { OutOfRange(); return; }

                string task = TaskInput("\nEditing...\n");
                if (task == null)
                    return;
                list[i - 1].Text = task;
                Console.ResetColor();
                Files.Save(list);
            }
            catch (ArgumentOutOfRangeException)
            { OutOfRange(); }
            catch (OverflowException)
            { Overflow(); }
        } // why instance every time
        public static void Delete(List<TaskItem> list)
        {
            try
            {
                if (list.Count == 0)
                { NoTasksError(); return; }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nChoose task to delete:\n");
                Tasks(list);
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\nAre you sure to delete \"{list[i - 1].Text}\"? (Enter(Y)/N)\n");
                string yesno = Console.ReadLine().ToLower();
                if (yesno == "y" || yesno == "")
                {
                    list.RemoveAt(i - 1);
                    Console.ResetColor();
                    Files.Save(list);
                }
                else if (yesno == "n")
                    OperationCancel();
                else
                    YesOrNo();
            }
            catch (ArgumentOutOfRangeException)
            { OutOfRange(); }
            catch (OverflowException)
            { Overflow(); }
        } // working
        public static void Toggle(List<TaskItem> list)
        {
            try
            {
                if (list.Count == 0)
                { NoTasksError(); return; }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nChoose task to toggle:\n");
                Tasks(list);
                int i = Convert.ToInt32(Console.ReadLine());
                list[i - 1].isComplete = !list[i - 1].isComplete;
                Console.ResetColor();
                Files.Save(list);

            }
            catch (ArgumentOutOfRangeException)
            { OutOfRange(); }
            catch (OverflowException)
            { Overflow(); }
        } // add notes to notepad invertion

        public static string TaskInput(string prompt) // no need for bool
        {
            Console.WriteLine(prompt);
            string taskInput = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(taskInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: Task cannot be empty!\n");
                Console.ResetColor();
                Console.ReadKey();
                return null;
            }
            return taskInput;
        }

        public static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Enter A, E or D!\n");
            Console.ResetColor();
            ExitMenu();
            Console.ReadKey();
        }
        public static void FormatException()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Wrong Format!\n");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void FileFormatException()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Wrong file format!\n");
            Console.ResetColor();
            Console.ReadKey();
            ClearAll();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nCreating a new file...\n");
            Console.ResetColor();
            Console.ReadKey();

        }
        public static void Recreate()
        {
            FileFormatException();
            File.Delete(Files.filePath);
        }
        public static void OutOfRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Input out of range!\n");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void Overflow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: Overflow!\n");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void NoTasksError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR: There are no tasks!\n");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void UnknownError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Unknown Error!\n");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void OperationCancel()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nOperation cancelled.\n");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void YesOrNo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Enter Y or N!\n");
            Console.ResetColor();
            Console.ReadKey();
        }

    }
}
