using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest.DataStruct
{
    public class ModelInfo
    {
        /// <summary>
        /// 这个模型所属的API
        /// </summary>
        public string Api { get; set; } = "";
        public string Model { get; set; } = "";
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 8192;
        public double TopP { get; set; } = 0.95;
        public string SystemPrompt { get; set; } = "你是一个专业的AI助手，擅长回答各种学科的问题。请提供准确、详细且易于理解的答案。";

    }
}
