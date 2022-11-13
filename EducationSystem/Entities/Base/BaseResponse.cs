namespace EducationSystem.Entities.Base;

public class BaseResponse<T> where T : class
{
    public BaseResponse()
    {
    }

    public BaseResponse(T data) : this()
    {
        Data = data;
    }

    public BaseResponse(bool isError, string description, T data = default) : this(data)
    {
        IsError = isError;
        Description = description;
    }

    public bool IsError { get; set; }
    public string? Description { get; set; }
    public T Data { get; set; }
}