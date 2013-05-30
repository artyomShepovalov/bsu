namespace templates_decorator.@abstract
{
    public interface IStreamDecorator : IStream
    {
        IStream Stream { get; set; }
    }
}
