# AITest — 本地问答与评分工具（Windows Forms / .NET 8）

一个用于管理题目与标准答案，调用兼容 OpenAI 风格聊天接口（支持本地推理服务，如 llama.cpp HTTP server），并对 AI 回答进行人工或 API 打分的桌面工具。支持流式回答显示、批量自动回答、附件（文本/图片）随问题提交，以及评分列表查看与评语详情。

## 亮点功能
- 问题管理与持久化：以 `questions/*.json` 存储每题的标题、题干、标准答案、AI 答案、附件、评分。
- 流式回答：通过 SSE 解析 `/v1/chat/completions` 的增量内容，实时呈现。
- 附件支持：文本内容并入提示；图片以 Base64 Data URL 方式随上下文提交。
- 打分评估：人工评分或外部打分 API（可配置多套），保存分数与评语并可列表查看。
- 批量自动回答：一键为题库生成非流式 AI 回答，支持取消与进度输出。
- 图形化配置：在界面管理聊天 API 与打分 API，包含连接测试与模型列表获取。

## 适用场景
- 便捷测试本地模型的性能。

## 架构概览
- 存储层：应用根目录下维护 `questions/*.json`；附件存放于 `files/`，题目 JSON 中以文件名记录。
- 配置层：`api_settings.json`（聊天接口）与 `score_api_settings.json`（评分接口列表）。
- API 层：`LlamaApiClient` 统一适配 OpenAI 风格接口；支持非流式与流式（SSE）。
- UI 层：Windows Forms 多窗体交互，核心窗体 `MainWindow` 驱动题目与流程；延时定时器防抖保存文本。

## 主要窗体与业务流程
- MainWindow：主界面。增删题目、附件拖拽、编辑与自动保存、调用回答与打分、查看评分列表。
- AnswerStreamDialog：读取 `api_settings.json` → 组装提示与附件 → 调用流式接口 → 实时追加文本 → 保存 AI 答案并回填主窗体。
- AddQuestionDialog：新增题目，生成并写入 `questions/*.json`。
- ApiSettingsDialog：配置聊天 API（地址、密钥、模型、温度、MaxTokens、TopP、系统提示词），含连接测试与模型列表。
- ScoreApiSettingsDialog：管理多个打分 API（含连接测试与模型清单），保存到 `score_api_settings.json`。
- ScoreRequestDialog：执行评分（人工或 API 流式）。提取 0–100 分并持久化，同时保存评语文本。
- ScoreListDialog：查看评分列表，打开 `EvaluationDialog` 查看评语详情。
- AutoAnswerDialog + AutoAnswerService：批量生成 AI 回答（非流式），写入 `aiAnswer` 字段；支持取消与日志/进度。

## 关键逻辑
- LlamaApiClient
  - CreateFromConfig：从 `api_settings.json` 读取基础参数（`ApiBaseUrl`、`ApiKey`）。
  - SendStreamChatRequestAsync：POST `/v1/chat/completions`，解析 SSE `data:` 行，取 `choices[0].delta.content` 增量回调；附件支持 `image_url` 的数据 URL。
  - SendChatRequestAsync：非流式一次性返回，取 `choices[0].message.content`。
  - GetModelsAsync：获取模型列表（OpenAI 风格 `data[*].id`）。
  - TestConnectionAsync：模型端点探测与连通性测试。
- 题目文件结构：含 `title/question/answer/aiAnswer/files/score` 等字段；评分列表保存 `modelName/socre/evaluation`（注意字段名 `socre` 的拼写）。
- 文本保存防抖：编辑框 `TextChanged` 触发 500ms 定时器，定时写回 JSON，避免频繁 IO。
- RichTextStreamAppender：优化流式文本追加性能与滚动体验。

## 代码结构（部分）
- 入口与项目：`Program.cs`、`AITest.csproj`、`AITest.slnx`
- 主窗体：`MainWindow.cs`（含 Designer/resx）
- 回答对话框：`AnswerStreamDialog.cs`（含 Designer/resx）
- 评分流程：`ScoreRequestDialog.cs`、`ScoreListDialog.cs`、`EvaluationDialog.cs`
- 配置对话框：`ApiSettingsDialog.cs`、`ScoreApiSettingsDialog.cs`
- 业务核心：`LlamaApiClient.cs`、`AutoAnswerService.cs`、`RichTextStreamAppender.cs`
- 问题管理：`AddQuestionDialog.cs`
- 其他：`Form1.cs`（早期或备用窗体）

## 环境与依赖
- 操作系统：Windows
- 运行时：.NET 8（`net8.0-windows`）
- UI：Windows Forms（`UseWindowsForms`）
- 依赖包：`Newtonsoft.Json`（13.x）

## 构建与运行
- Visual Studio 2022
  - 打开 `AITest.slnx`，设置启动项目为 `AITest`，构建并运行。
- 命令行（在项目目录）
  - 构建：`dotnet build`
  - 运行：`dotnet run`

## 配置文件示例
`api_settings.json`
```json
{
  "ApiBaseUrl": "http://127.0.0.1:8080",
  "ApiKey": "your_api_key_if_needed",
  "Model": "gpt-4o-mini-or-local-llama",
  "Temperature": 0.7,
  "MaxTokens": 2048,
  "TopP": 1.0,
  "SystemPrompt": "你是一个严谨的助手。"
}
```

`score_api_settings.json`（可包含多个打分端点）
```json
{
  "Apis": [
    {
      "Name": "LocalScoreAPI",
      "BaseUrl": "http://127.0.0.1:8081",
      "ApiKey": "",
      "Model": "score-model",
      "SystemPrompt": "请根据答案打0-100分并给出评语。"
    }
  ]
}
```

## 使用流程
1. 通过“添加问题”新建题目与标准答案。
2. 将相关附件拖拽到问题（文本/图片会随提问提交）。
3. 点击“提交问题”打开流式回答对话框，查看并保存 AI 答案。
4. 点击“打分”，选择人工评分或已配置的打分 API，保存分数与评语。
5. 在“评分列表”中查看各次评分记录与评语详情。
6. 如需批量生成 AI 回答，使用“批量自动回答”。

## 兼容性与注意事项
- 接口兼容：要求聊天接口兼容 OpenAI 风格 `/v1/chat/completions`，并支持 SSE 流式返回。
- 图片附件：以 Base64 数据 URL 传输，需服务端支持 `image_url` 输入。
- 评分字段：代码中评分字段为 `socre`（拼写如此），保存/读取请保持一致。
- 配置来源：以 JSON 配置为准；`App.config` 为旧式配置，当前逻辑不依赖其内容。
- 异常与健壮性：个别位置吞异常或以消息框提示；生产环境建议增强校验与日志。

## 路线与改进建议
- 增加单元测试与集成测试，覆盖文件读写与 API 交互。
- 增强错误与异常日志，支持导出与过滤。
- 支持更多附件类型与更灵活的上下文拼接策略。
- 评分解析更健壮（结构化返回或正则校验）。
- 针对不同的本地模型，将答案与分数分开统计。

## 致谢
感谢开源生态与本地推理项目（如 llama.cpp）提供的兼容接口与工具支持。

