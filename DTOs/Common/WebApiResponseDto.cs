namespace DTOs.Common;

public class WebApiResponseDto<T>
{
    public T Data { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }

    // statik olarak oluşturulmuş başarılı bir response
    public static WebApiResponseDto<T> Success(T data, int statusCode, string message)
    {
        return new WebApiResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static WebApiResponseDto<T> Success(T data)
    {
        return new WebApiResponseDto<T>
        {
            Data = data,
            StatusCode = 200,
            Message = string.Empty
        };
    }


    // statik olarak oluşturulmuş başarısız bir response
    public static WebApiResponseDto<T> Fail(int statusCode, string message)
    {
        return new WebApiResponseDto<T>
        {
            Data = default,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static WebApiResponseDto<T> Fail(T data, string message)
    {
        return new WebApiResponseDto<T>
        {
            Data = data,
            StatusCode = 400,
            Message = message
        };
    }


    // statik olarak oluşturulmuş başarısız bir response
    public static WebApiResponseDto<T> Fail(string message)
    {
        return new WebApiResponseDto<T>
        {
            Data = default,
            StatusCode = 400,
            Message = message
        };
    }

    // statik olarak oluşturulmuş başarılı bir response
    public static WebApiResponseDto<T> Success(T data, int statusCode)
    {
        return new WebApiResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = "Success"
        };
    }
}