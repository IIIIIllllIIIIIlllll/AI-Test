using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AITest.OpenAI
{
    /// <summary>
    /// 表示OpenAI API错误响应
    /// </summary>
    public class OpenAIErrorResponse
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonPropertyName("error")]
        public OpenAIError Error { get; set; } = new OpenAIError();
    }

    /// <summary>
    /// 表示OpenAI API错误详情
    /// </summary>
    public class OpenAIError
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 错误类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 错误参数
        /// </summary>
        [JsonPropertyName("param")]
        public string? Param { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }

    /// <summary>
    /// OpenAI API异常类
    /// </summary>
    public class OpenAIException : System.Exception
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public string ErrorType { get; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string? ErrorCode { get; }

        /// <summary>
        /// HTTP状态码
        /// </summary>
        public System.Net.HttpStatusCode StatusCode { get; }

        public OpenAIException(string message, string errorType, string? errorCode = null, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.BadRequest) 
            : base(message)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public OpenAIException(OpenAIError error, System.Net.HttpStatusCode statusCode) 
            : base(error.Message)
        {
            ErrorType = error.Type;
            ErrorCode = error.Code;
            StatusCode = statusCode;
        }
    }
}