using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.DataCreators
{
    internal class CsvConvertToDict
    {

        public Dictionary<string, List<string>> GetDictFromCsv(string filePath)
        {
            string manDefiner = "m";
            string womanDefiner = "f";
            string[] lines;
            Dictionary<string, List<string>> stringByGender = new Dictionary<string, List<string>>();
            List<string> men = new List<string>();
            List<string> women = new List<string>();

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл с данными в директории /Data не найден");
                Console.WriteLine(ex.Message);
                lines = new string[0];
                throw;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                string name = data[0];
                string gender = data[1];

                if (gender == manDefiner) men.Add(name);
                else women.Add(name);
            }
            if (lines.Length > 0)
            {
                stringByGender.Add(manDefiner, men);
                stringByGender.Add(womanDefiner, women);
            }

            return stringByGender;
        }
    }
}
