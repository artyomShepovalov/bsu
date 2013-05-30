namespace templates_decorator.@abstract
{
    public interface IStream
    {
        void PutBytes(byte[] bytes);

        void PutInt(int number);

        void HandleBufferFull();
    }
}