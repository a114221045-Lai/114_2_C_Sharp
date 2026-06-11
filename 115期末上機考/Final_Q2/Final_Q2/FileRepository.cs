using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Q2
{
    public class FileRepository
    {
        public static List<Employee> LoadData(string filePath)
        {
            List<Employee> list = new List<Employee>();

            if (!File.Exists(filePath))
            {
                return list;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');

                    if (parts.Length == 4 && int.TryParse(parts[0], out int id))
                    {
                        Employee emp = new Employee(id, parts[1], parts[2], parts[3]);
                        list.Add(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"讀取檔案時發生錯誤: {ex.Message}");
            }

            return list;
        }

        public static void SaveData(string filePath, List<Employee> list)
        {
            try
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                List<string> lines = new List<string>();
                foreach (Employee emp in list)
                {
                    lines.Add(emp.ToTxtLine());
                }

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"儲存檔案時發生錯誤: {ex.Message}");
            }
        }
    }
}
