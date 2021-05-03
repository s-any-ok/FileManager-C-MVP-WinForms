using System.IO;
using System.Text;
using TextEditor._BL.Interfaces;

namespace TextEditor._BL
{
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding("utf-8");

        public bool IsExist(string filePath) => File.Exists(filePath);
        public string GetContent(string path) => GetContent(path, _defaultEncoding);
        public string GetContent(string path, Encoding encoding) => File.ReadAllText(path, encoding);
        
        public void SaveContent(string path, string content) => SaveContent(path, content, _defaultEncoding);
        public void SaveContent(string path, string content, Encoding encoding) => File.WriteAllText(path, content, encoding);

        public int GetSymbolCount(string content) => content.Length;
    }
}