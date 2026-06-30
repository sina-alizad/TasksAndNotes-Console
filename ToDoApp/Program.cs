using System;
using ToDoApp;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            Files.Initialize();
            List<string> list = Files.Load();
            
            while (true)
            {
                Console.Clear();
                Methods.Header();
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