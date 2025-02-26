// namespace data_visualization_api.Application.Common.Models;

// public class Result
// {
//     internal Result(bool succeeded, IEnumerable<string> errors)
//     {
//         Succeeded = succeeded;
//         Errors = errors.ToArray();
//     }

//     public bool Succeeded { get; init; }

//     public string[] Errors { get; init; }

//     public static Result Success()
//     {
//         return new Result(true, Array.Empty<string>());
//     }

//     public static Result Failure(IEnumerable<string> errors)
//     {
//         return new Result(false, errors);
//     }
// }

// Application/Common/Models/Result.cs
namespace data_visualization_api.Application.Common.Models;

public class Result<T>
{
    internal Result(bool succeeded, T? data, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }
    public T? Data { get; init; }
    public string[] Errors { get; init; }

    public static Result<T> Success(T data)
        => new(true, data, Array.Empty<string>());

    public static Result<T> Failure(IEnumerable<string> errors)
        => new(false, default, errors);

    public static Result<T> Failure(string error)
        => new(false, default, new[] { error });
}

// Non-generic version for void operations
public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }
    public string[] Errors { get; init; }

    public static Result Success()
        => new(true, Array.Empty<string>());

    public static Result Failure(IEnumerable<string> errors)
        => new(false, errors);

    public static Result Failure(string error)
        => new(false, new[] { error });
}