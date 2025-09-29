using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileWork.DataCreators;

namespace FileWork.Managers
{
    internal class StudentCreator
    {
        private static string manDefiner = "m";
        private static string womanDefiner = "f";
        private static string pathToNames = DirectoryManager.GetFilePath("Names.csv");
        private static string pathToSurnames = DirectoryManager.GetFilePath("Surnames.csv");
        private Dictionary<string, List<string>> names = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> surnames = new Dictionary<string, List<string>>();
        private List<string> students = new List<string>();
        Random random = new Random();

        public List<string> Students { get => students; }

        public StudentCreator() 
        {
            names = new CsvConvertToDict().GetDictFromCsv(DirectoryManager.GetFilePath(pathToNames));
            surnames = new CsvConvertToDict().GetDictFromCsv(DirectoryManager.GetFilePath(pathToSurnames));

            RandomizeStudentDistribution();
        }

        private void RandomizeStudentDistribution()
        {
            int studentAmount = GetRandomAmountOfStudents();

            for (int i = 0; i < studentAmount; i++) students.Add(GetRandomStudent());
        }

        private int GetRandomAmountOfStudents()
        {
            int amount = 0;
            if (names.Count > 5)
            {
                if (names.Count == surnames.Count && names.Count > 0)
                {
                    amount = random.Next(names.Count / 2, names.Count - 1);
                }
                else if (names.Count < surnames.Count)
                {
                    amount = random.Next(names.Count, surnames.Count - 1);
                }
                else
                {
                    amount = random.Next(surnames.Count, names.Count - 1);
                }
            }
            else amount = random.Next(3, 7); //скучный вариант
            return amount;
        }

        private string GetRandomAge()
        {
            int youngestAge = 18;
            int oldestAge = 25;
            int age = random.Next(youngestAge, oldestAge);
            return age.ToString();
        }

        private string GetRandomStudent() 
        {
            string studentFullName = "";

            int genderLawyer = random.Next(1, 100);
            int randName;
            int randSurname;
            string genDefiner = "";

            // Если четное, то студент мужского пола, иначе - женского
            if (genderLawyer % 2 == 0) genDefiner = "m";
            else genDefiner = "f"; 

            randName = random.Next(0, names[genDefiner].Count - 2);
            randSurname = random.Next(0, surnames[genDefiner].Count - 2);

            //Создание студента вида "фамилия имя возраст"
            studentFullName =
                surnames[genDefiner].ElementAt(randSurname) + " "
                + names[genDefiner].ElementAt(randName) + " "
                + GetRandomAge();

            return studentFullName; 
        }

        public string GetStudent()
        {
            return students.ElementAt(random.Next(0, students.Count - 1));
        }
    }
}
