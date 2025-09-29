using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FileWork.Managers
{
    internal class FileManager
    {
        private string path;
        private FileInfo fileInfo;
        private bool isFileCreated;

        public FileManager(string path)
        {
            this.path = path;
            CreateFile(path);
        }

        private FileInfo CreateFile(string path)
        {
            try
            {
                fileInfo = new FileInfo(path);
                isFileCreated = true;
                Console.WriteLine("Метод CreateFile(), файл создан");
            }
            catch (Exception ex)
            {
                isFileCreated = false;
                Console.WriteLine("Файл не был создан");
                Console.WriteLine(ex.Message);
                //Console.WriteLine($"Указанный путь для {fileInfo.Name} является неверным");
                return null;
                throw;
            }
            return fileInfo;
        }

        public void FillInFile(List<string> strokes)
        {
            if (!isFileCreated) Console.WriteLine("Файл не был создан");
            else 
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    //В файле задания в примере строки имеют большой междустрочный интервал,
                    //а не пустую строку между студентами, поэтому не добавил строку между студентами.
                    //Написал пояснение по той причине, что изначально мне показалось, что между студентами
                    //есть пустая строка 
                    foreach (string item in strokes) writer.WriteLine(item);

                    // Пример, если я оказался не прав:
                    //foreach (string s in strokes) writer.WriteLine(s + "\n");
                    // В таком случае надо должны быть чуток поправлены методы ниже
                }
            }
        }

        public void AddInFile(string line)
        {
            if (!isFileCreated) Console.WriteLine("Файл не был создан");
            else
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(line);
                }
            }
        }

        public void PrintFileContent()
        {
            List<string> strokes = GetFileContent();
            foreach (string item in strokes) Console.WriteLine(item);
        }

        public List<string> GetFileContent()
        {
            List<string> strokes = new List<string>();

            if (!isFileCreated) Console.WriteLine("Файл не был создан");
            else
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        strokes.Add(line);
                        Console.WriteLine(line);
                    }
                }
            }

            return strokes;
        }

        public int CountOlderThanYear(int year)
        {
            List<string> strokes = GetFileContent();
            int amount = 0;

            foreach (string item in strokes)
            {
                string[] student = item.Split(' ');

                if (int.TryParse(student[2], out int yearsOld))
                {
                    if (yearsOld > year) ++amount;
                }
                else Console.WriteLine($"Возраст студента {student[0]} {student[1]} не был учитан");
            }

            return amount;
        }
    }
}
