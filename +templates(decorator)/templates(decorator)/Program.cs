using templates_decorator.concrete;

namespace templates_decorator
{
    class Program
    {
        static void Main()
        {
            var bytes = new byte[7000];
            const int intVal = int.MaxValue;

            for (var i = 0; i < bytes.Length; ++i)
                bytes[i] = (byte) i;

            var fileStream = StreamFactoryMethodClass.GetFileStream("fileStream.txt");
            fileStream.PutBytes(bytes);
            fileStream.PutInt(intVal);
            fileStream.HandleBufferFull();

            var compressedFileStream = StreamFactoryMethodClass.GetDecorateCompressionStream(
                StreamFactoryMethodClass.GetFileStream("compressedFileStream.txt"));
            compressedFileStream.PutBytes(bytes);
            compressedFileStream.PutInt(intVal);
            compressedFileStream.HandleBufferFull();

            var acsii7FileStream = StreamFactoryMethodClass.GetDecorateAscii7Stream(
                StreamFactoryMethodClass.GetFileStream("ascii7FileStream.txt"));
            acsii7FileStream.PutBytes(bytes);
            acsii7FileStream.PutInt(intVal);
            acsii7FileStream.HandleBufferFull();

            var acsii7CompressedFileStream = StreamFactoryMethodClass.GetDecorateAscii7Stream(
                StreamFactoryMethodClass.GetDecorateCompressionStream(
                StreamFactoryMethodClass.GetFileStream("acsii7CompressedFileStream.txt")));
            acsii7CompressedFileStream.PutBytes(bytes);
            acsii7CompressedFileStream.PutInt(intVal);
            acsii7CompressedFileStream.HandleBufferFull();
        }
    }
}
