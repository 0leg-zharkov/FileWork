using System.IO;

namespace FileWork.Managers
{
    internal static class DirectoryManager
    {
        public static string GetFilePath(string fileName)
        {
            string dataDir = GetDataDirectory();

            return Path.Combine(dataDir, fileName);
        }

        public static string GetDataDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string projectRoot = Directory.GetParent(currentDir).Parent.FullName;
            string dataDir = Path.Combine(projectRoot, "Data");
            return dataDir;
        }
    }
}
