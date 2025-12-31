using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AITest.OpenAI
{
    /// <summary>
    /// 表示OpenAI Chat Completions API的响应
    /// </summary>
    public class ChatCompletionResponse
    {
        /// <summary>
        /// 请求的ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 对象类型，固定为"chat.completion"
        /// </summary>
        [JsonPropertyName("object")]
        public string Object { get; set; } = "chat.completion";

        /// <summary>
        /// 创建时间戳
        /// </summary>
        [JsonPropertyName("created")]
        public long Created { get; set; }

        /// <summary>
        /// 使用的模型
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// 聊天补全选择列表
        /// </summary>
        [JsonPropertyName("choices")]
        public List<ChatCompletionChoice> Choices { get; set; } = new List<ChatCompletionChoice>();

        /// <summary>
        /// 令牌使用情况
        /// </summary>
        [JsonPropertyName("usage")]
        public ChatCompletionUsage? Usage { get; set; }

        /// <summary>
        /// 系统指纹（可选）
        /// </summary>
        [JsonPropertyName("system_fingerprint")]
        public string? SystemFingerprint { get; set; }
    }

    /// <summary>
    /// 表示聊天补全选择
    /// </summary>
    public class ChatCompletionChoice
    {
        /// <summary>
        /// 选择索引
        /// </summary>
        [JsonPropertyName("index")]
        public int Index { get; set; }

        /// <summary>
        /// 聊天消息
        /// </summary>
        [JsonPropertyName("message")]
        public ChatMessage Message { get; set; } = new ChatMessage();

        /// <summary>
        /// 完成原因
        /// </summary>
        [JsonPropertyName("finish_reason")]
        public string? FinishReason { get; set; }

        /// <summary>
        /// 对数概率信息
        /// </summary>
        [JsonPropertyName("logprobs")]
        public ChatCompletionLogProbs? LogProbs { get; set; }
    }

    /// <summary>
    /// 表示聊天对数概率信息
    /// </summary>
    public class ChatCompletionLogProbs
    {
        /// <summary>
        /// 令牌的对数概率
        /// </summary>
        [JsonPropertyName("content")]
        public List<ChatCompletionTokenLogprob>? Content { get; set; }
    }

    /// <summary>
    /// 表示聊天令牌对数概率
    /// </summary>
    public class ChatCompletionTokenLogprob
    {
        /// <summary>
        /// 令牌
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 对数概率值
        /// </summary>
        [JsonPropertyName("logprob")]
        public double Logprob { get; set; }

        /// <summary>
        /// 字节列表
        /// </summary>
        [JsonPropertyName("bytes")]
        public List<int>? Bytes { get; set; }

        /// <summary>
        /// 前N个对数概率
        /// </summary>
        [JsonPropertyName("top_logprobs")]
        public List<ChatCompletionTopLogprob>? TopLogprobs { get; set; }
    }

    /// <summary>
    /// 表示聊天前N个对数概率
    /// </summary>
    public class ChatCompletionTopLogprob
    {
        /// <summary>
        /// 令牌
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 对数概率值
        /// </summary>
        [JsonPropertyName("logprob")]
        public double Logprob { get; set; }

        /// <summary>
        /// 字节列表
        /// </summary>
        [JsonPropertyName("bytes")]
        public List<int>? Bytes { get; set; }
    }

    /// <summary>
    /// 表示聊天令牌使用情况
    /// </summary>
    public class ChatCompletionUsage
    {
        /// <summary>
        /// 提示中使用的令牌数
        /// </summary>
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        /// <summary>
        /// 补全中使用的令牌数
        /// </summary>
        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        /// <summary>
        /// 总令牌数
        /// </summary>
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
