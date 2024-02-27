using System.IO;

namespace marking_test_task.Services
{
    public static class FileService
    {
        public static async Task<IEnumerable<string>> ReadAll(string fileName)
        {
            string[] fileData = await File.ReadAllLinesAsync(fileName);

            return fileData;
        }

        public static async Task WriteAll(string dir, string fileName, string data)
        {
            string pathToFile = Path.Combine(dir, fileName);
            await File.WriteAllTextAsync(pathToFile, data);
        }

        public static async Task WriteAll(string fileName, string data)
        {
            string executionDir = AppDomain.CurrentDomain.BaseDirectory;
            await WriteAll(executionDir, fileName, data);            
        }
    }
}
