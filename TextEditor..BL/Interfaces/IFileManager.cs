using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor._BL.Interfaces
{
    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetContent(string path);
        string GetContent(string path, Encoding encoding);
        void SaveContent(string path, string content);
        void SaveContent(string path, string content, Encoding encoding);
        int GetSymbolCount(string content);
    }
}
