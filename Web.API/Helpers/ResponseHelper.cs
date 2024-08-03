using System.Net;
using DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Helpers;

/// <summary>
///     Response oluşturmak için kullanılan yardımcı sınıf.
/// </summary>
public static class ResponseHelper
{
    /// <summary>
    ///     Response oluşturur.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="statusCode"></param>
    /// <param name="status"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static IActionResult CreateSuccesResponse<T>(T data, HttpStatusCode statusCode, string status,
        string message)
    {
        return new ObjectResult(WebApiResponseDto<T>.Success(data, (int)statusCode, message));
    }
    /// <summary>
    ///     Response oluşturur.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="statusCode"></param>
    /// <param name="status"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static IActionResult CreateSuccesResponse<T>(T data)
    {
        return new ObjectResult(WebApiResponseDto<T>.Success(data));
    }


    public static IActionResult CreateSuccesResponse<T>(T data, HttpStatusCode statusCode)
    {
        return new ObjectResult(WebApiResponseDto<T>.Success(data, (int)statusCode));
    }


    /// <summary>
    ///     Response oluşturur.
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="status"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static IActionResult CreateFailResponse(HttpStatusCode statusCode, string status, string message)
    {
        // how to create default null class 
        return new ObjectResult(WebApiResponseDto<object>.Fail((int)statusCode, message));
    }

    public static IActionResult CreateFailResponse(string message)
    {
        // how to create default null class 
        return new ObjectResult(WebApiResponseDto<object>.Fail(message));
    }

    public static IActionResult CreateFailResponse<T>(T data, string message)
    {
        return new ObjectResult(WebApiResponseDto<T>.Fail(data, message));
    }
}