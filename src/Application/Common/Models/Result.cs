using Microsoft.AspNetCore.Http;
namespace data_visualization_api.Application.Common.Models;


public class Result<T>
{
    internal Result(bool succeeded, T? data, IEnumerable<string> errors, int statusCode)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = [.. errors];
        StatusCode = statusCode;
    }

    public bool Succeeded { get; init; }
    public T? Data { get; init; }
    public string[] Errors { get; init; }
    public int StatusCode { get; init; }

    public static Result<T> Success(T data, int statusCode = StatusCodes.Status200OK)
        => new(true, data, [], statusCode);

    public static Result<T> Failure(IEnumerable<string> errors, int statusCode = StatusCodes.Status400BadRequest)
        => new(false, default, errors, statusCode);

    public static Result<T> Failure(string error, int statusCode = StatusCodes.Status400BadRequest)
        => new(false, default, [error], statusCode);
}

public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors, int statusCode)
    {
        Succeeded = succeeded;
        Errors = [.. errors];
        StatusCode = statusCode;
    }

    public bool Succeeded { get; init; }
    public string[] Errors { get; init; }
    public int StatusCode { get; init; }

    public static Result Success(int statusCode = StatusCodes.Status200OK)
        => new(true, [], statusCode);

    public static Result Failure(IEnumerable<string> errors, int statusCode = StatusCodes.Status400BadRequest)
        => new(false, errors, statusCode);

    public static Result Failure(string error, int statusCode = StatusCodes.Status400BadRequest)
        => new(false, [error], statusCode);
}