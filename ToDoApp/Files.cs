using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class Files
    {
        public static string filePath;

        public static void Initialize()
        {
            string path = AppContext.BaseDirectory;
            filePath = Path.Combine(path, "File.txt");
        }
        public static List<TaskItem> Load()
        {
            try
            {

                if (!File.Exists(filePath))
                    return new List<TaskItem>();

                string[] lines = File.ReadAllLines(filePath);
                List<TaskItem> list = new List<TaskItem>();

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split('|');
                    TaskItem task = new TaskItem();
                    task.Text = parts[0];
                    task.isComplete = Convert.ToBoolean(parts[1]);
                    list.Add(task);
                }
                return list;
            }
            catch (FormatException)
            {
                Methods.Recreate();
                return new List<TaskItem>();
            }
            catch (IndexOutOfRangeException)
            {
                Methods.Recreate();
                return new List<TaskItem>();
            }
        }
        public static void Save(List<TaskItem> list)
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                lines.Add(list[i].Text + "|" + list[i].isComplete);
            }
            File.WriteAllLines(filePath, lines);
        }

    }
}
