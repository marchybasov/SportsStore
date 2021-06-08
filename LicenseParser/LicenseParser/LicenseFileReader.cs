using System.IO;

namespace LicenseParser
{
    class LicenseFileReader : ILicenseFileReader
    {
        private string[] ReadFile(string logFilePath)
        {
            if (logFilePath == string.Empty)
            {
                string path = @"E:\GIT\";
                string fileName = "lmgrd.log";
                string filePath = Path.Combine(path + fileName);
                return File.ReadAllLines(filePath);
            }
            return File.ReadAllLines(logFilePath);
           


        }
        public string[] GetLicenseFileInfo(string logFilePath) => ReadFile(logFilePath);

    }


}
