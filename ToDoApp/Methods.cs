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

        public static void Tasks(List<string> list)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {list[i]}\n");
            }

            Console.ResetColor();
        }

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nEnter:\nA for Adding\nE for Editting\nD for Deleting\n");
            Console.ResetColor();
        }

        public static void Add(List<string> list)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAdd your task...\n");
            list.Add(Console.ReadLine());
            Console.ResetColor();
        }

        public static void Edit(List<string> list)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nChoose task to edit: \n");
                Tasks(list);
                int i = Convert.ToInt32(Console.ReadLine());
                if (i > list.Count || i < 1)
                {
                    OutOfRange();
                    return;
                }

                Console.WriteLine("\nEditing...\n");
                list[i - 1] = Console.ReadLine();

                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: Input out of range!\n");
                Console.ResetColor();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: Overflow!\n");
                Console.ResetColor();
            }
        }

        public static void Delete(List<string> list)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nChoose task to delete:\n");
                Tasks(list);
                int i = Convert.ToInt32(Console.ReadLine());
                list.RemoveAt(i - 1);
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: Input out of range!\n");
                Console.ResetColor();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nERROR: Overflow!\n");
                Console.ResetColor();
            }
        }
        public static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Enter A, E or D!\n");
            Console.ResetColor();
        }

        public static void FormatException()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Wrong Format!\n");
            Console.ResetColor();
        }
        public static void OutOfRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Input out of range!\n");
            Console.ResetColor();
        }
        public static void UnknownError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: Unknown Error!\n");
            Console.ResetColor();
        }
    }
}
