using templates_decorator.@abstract;

namespace templates_decorator.concrete
{
    public class MemoryStream : AbstractStream
    {
        public MemoryStream()
        {
            Stream = new System.IO.MemoryStream(new byte[1000]);
        }
    }
}
