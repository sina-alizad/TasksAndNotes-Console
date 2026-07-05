using System;
using ToDoApp;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Files.Initialize();
            List<TaskItem> list = Files.Load();

            while (true)
            {
                Methods.ClearAll();
                Methods.Header();
                try
                {

                    if (list.Count == 0)
                        Methods.NoTasks();
                    else
                        Methods.Tasks(list);

                    Methods.Menu();
                    Methods.ExitMenu();
                    string option = Console.ReadLine().ToLower();

                    switch (option)
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

                        case "t":
                            Methods.Toggle(list);
                            break;

                        case "x":
                            return;

                        default:
                            Methods.WrongInput();
                            break;
                    }
                }
                catch (FormatException)
                { Methods.FormatException(); }
            }
        }
    }
}