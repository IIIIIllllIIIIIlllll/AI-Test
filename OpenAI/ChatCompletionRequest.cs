using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AITest.OpenAI
{
    /// <summary>
    /// 表示OpenAI Chat Completions API的请求参数
    /// </summary>
    public class ChatCompletionRequest
    {
        /// <summary>
        /// 要使用的模型的ID
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo";

        /// <summary>
        /// 聊天消息列表
        /// </summary>
        [JsonPropertyName("messages")]
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

        /// <summary>
        /// 为每个提示生成的补全数量
        /// </summary>
        [JsonPropertyName("n")]
        public int? N { get; set; } = 1;

        /// <summary>
        /// 补全的最大令牌数
        /// </summary>
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// 采样温度，控制输出的随机性
        /// </summary>
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; } = 1;

        /// <summary>
        /// 核采样，一种替代温度采样的方法
        /// </summary>
        [JsonPropertyName("top_p")]
        public double? TopP { get; set; } = 1;

        /// <summary>
        /// 是否流式返回响应
        /// </summary>
        [JsonPropertyName("stream")]
        public bool? Stream { get; set; } = false;

        /// <summary>
        /// 包含停止序列的字符串列表
        /// </summary>
        [JsonPropertyName("stop")]
        public List<string>? Stop { get; set; }

        /// <summary>
        /// 生成结果的惩罚，用于减少重复
        /// </summary>
        [JsonPropertyName("presence_penalty")]
        public double? PresencePenalty { get; set; } = 0;

        /// <summary>
        /// 基于令牌频率的惩罚
        /// </summary>
        [JsonPropertyName("frequency_penalty")]
        public double? FrequencyPenalty { get; set; } = 0;

        /// <summary>
        /// 对数概率信息
        /// </summary>
        [JsonPropertyName("logprobs")]
        public bool? Logprobs { get; set; } = false;

        /// <summary>
        /// 回应中包含的令牌对数概率数量
        /// </summary>
        [JsonPropertyName("top_logprobs")]
        public int? TopLogprobs { get; set; }

        /// <summary>
        /// 生成补全时使用的用户标识符
        /// </summary>
        [JsonPropertyName("user")]
        public string? User { get; set; }
    }

    /// <summary>
    /// 表示聊天消息
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// 消息角色，可以是system、user或assistant
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 消息名称（可选）
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
