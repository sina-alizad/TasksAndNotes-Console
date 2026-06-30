using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class Files
    {
        private static string filePath;

        public static void Initialize()
        {
            string path = Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                path = Directory.GetParent(path).ToString();
            }
            filePath = Path.Combine(path, "File.txt");
        }
        public static List<string> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<string>();
            }
            else
            {
                return File.ReadAllLines(filePath).ToList();
            }
        }
        public static void Save(List<string> list)
        {
            File.WriteAllLines(filePath, list);
        }
    }
}
