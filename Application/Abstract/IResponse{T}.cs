namespace Application.Abstract;

public interface IResponse<T> : IResponse
{
    T Data { get; set; }
}
