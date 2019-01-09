using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
