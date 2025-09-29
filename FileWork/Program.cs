using System;
using FileWork.Managers;

namespace FileWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:\\Users\\prive\\source\\repos\\FileWork\\FileWork\\Data\\students.txt";
            string fileName = "\\students.txt";
            string path = DirectoryManager.GetDataDirectory() + fileName;
            int age = 20;
            int amount = 0;

            StudentCreator studentCreator = new StudentCreator();
            FileManager fileManager = new FileManager(path);

            fileManager.FillInFile(studentCreator.Students);
            fileManager.PrintFileContent();

            amount = fileManager.CountOlderThanYear(age);
            Console.WriteLine($"Количество студентов старше {age}: {amount}");

            fileManager.AddInFile(studentCreator.GetStudent());
        }
    }
}
