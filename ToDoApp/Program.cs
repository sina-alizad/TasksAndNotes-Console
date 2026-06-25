using System;
using ToDoApp;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            Methods.Header();

            while (true)
            {
                try
                {

                    if (list.Count == 0)
                        Methods.NoTasks();
                    else
                        Methods.Tasks(list);

                    Methods.Menu();
                    string input = Console.ReadLine().ToLower();

                    switch (input)
                    {
                        case "a":
                            Methods.Add(list);
                            break;

                        case "e":
                            Methods.Edit(list);
                            break;

                        case "d":
                            Methods.Delete(list);
                            break;

                        default:
                            Methods.WrongInput();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Methods.FormatException();
                }
            }
        }
    }
}