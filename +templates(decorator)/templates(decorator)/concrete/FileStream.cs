using System.IO;
using templates_decorator.@abstract;

namespace templates_decorator.concrete
{
    public class FileStream : AbstractStream
    {
        public FileStream(string fileName)
        {
            Stream = new System.IO.FileStream(fileName, FileMode.OpenOrCreate);
        }
    }
}