using templates_decorator.@abstract;

namespace templates_decorator.concrete
{
    public static class StreamFactoryMethodClass
    {
        public static IStream GetMemoryStream()
        {
            return new MemoryStream();
        }

        public static IStream GetFileStream(string fileName)
        {
            return new FileStream(fileName);
        }

        public static IStream GetDecorateCompressionStream(IStream stream)
        {
            return new CompressingStream(stream);
        }

        public static IStream GetDecorateAscii7Stream(IStream stream)
        {
            return new Ascii7Stream
                       {
                           Stream = stream
                       };
        }
    }
}
