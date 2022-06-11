using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCli
{
    internal class Storage
    {
        private static readonly string appDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static byte[] Load(string path)
        {
            string filePath = Path.Combine(appDir, $"{path}.json");
            byte[] result = Array.Empty<byte>();
            Console.WriteLine($"path: {filePath}, {appDir}");
            try
            {
                result = File.ReadAllBytes(filePath);
            }
            catch (FileNotFoundException)
            {
                Directory.CreateDirectory(appDir);
                File.Create(filePath);
            }
            return result;
        }

        public static void Save(string path, byte[] data)
        {
            File.WriteAllBytes($"{appDir}/{path}.json", data);
        }
    }
}
