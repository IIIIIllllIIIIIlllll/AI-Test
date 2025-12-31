using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest.OpenAI
{
    /// <summary>
    /// OpenAI API配置类
    /// </summary>
    public class OpenAIConfig
    {
        /// <summary>
        /// API密钥
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// API基础URL，默认为OpenAI官方API
        /// </summary>
        public string BaseUrl { get; set; } = "http://127.0.0.1:8080/";

        /// <summary>
        /// API版本，默认为v1
        /// </summary>
        public string ApiVersion { get; set; } = "v1";

        /// <summary>
        /// 组织ID（可选）
        /// </summary>
        public string? OrganizationId { get; set; }

        /// <summary>
        /// HTTP请求超时时间（毫秒），默认为30秒
        /// </summary>
        public int TimeoutMs { get; set; } = 30000;

        /// <summary>
        /// 用户代理标识
        /// </summary>
        public string UserAgent { get; set; } = "AITest/1.0";

        /// <summary>
        /// 验证配置是否有效
        /// </summary>
        /// <returns>如果配置有效返回true，否则返回false</returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ApiKey) &&
                   !string.IsNullOrWhiteSpace(BaseUrl) &&
                   !string.IsNullOrWhiteSpace(ApiVersion);
        }

        /// <summary>
        /// 获取完整的API端点URL
        /// </summary>
        /// <param name="endpoint">API端点路径</param>
        /// <returns>完整的API URL</returns>
        public string GetEndpointUrl(string endpoint)
        {
            // 确保BaseUrl不以/结尾
            var baseUrl = BaseUrl.EndsWith("/") ? BaseUrl.Substring(0, BaseUrl.Length - 1) : BaseUrl;

            // 确保endpoint不以/开头
            var cleanEndpoint = endpoint.StartsWith("/") ? endpoint.Substring(1) : endpoint;

            // 确保ApiVersion以/开头
            var apiVersion = ApiVersion.StartsWith("/") ? ApiVersion : "/" + ApiVersion;


            Debug.WriteLine($"{baseUrl}{apiVersion}/{cleanEndpoint}");

            return $"{baseUrl}{apiVersion}/{cleanEndpoint}";
        }
    }
}
