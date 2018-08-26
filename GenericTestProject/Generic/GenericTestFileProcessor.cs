using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenericTestProject.Generic
{
    public static class GenericTestFileProcessor
    {
        public static List<T> LoadFromTextFile<T>(string filePath) where T : class, new()
        {
            var lines = File.ReadAllLines(filePath).ToList();
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException();
            }

            var headers = lines[0].Split(',');

            lines.RemoveAt(0);


            foreach (var itemLines in lines)
            {

                var vals = itemLines.Split(',');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if (col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }

                output.Add(entry);
            }

            return output;
        }

        public static void SaveToTextFile<T>(List<T> data, string filePath) where T : class //, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if (data == null || data.Count == 0)
            {
                throw new ArgumentNullException();
            }

            var cols = data[0].GetType().GetProperties();

            foreach (var itemCols in cols)
            {
                line.Append(itemCols.Name);
                line.Append(",");
            }

            lines.Add(line.ToString().Substring(0, line.Length - 1));

            foreach (var itemData in data)
            {
                line = new StringBuilder();

                foreach (var itemCols in cols)
                {
                    line.Append(itemCols.GetValue(itemData));
                    line.Append(",");
                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
