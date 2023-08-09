using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Functions.Payloads;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
// using Azure;
// using Azure.AI.OpenAI;

namespace Functions
{
    public class Webhook
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string accessToken;

        public Webhook(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            accessToken = configuration.GetValue<string>("LINE_CHANNEL_ACCESS_TOKEN");
        }

        [FunctionName("Webhook")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // textイベント（メッセージ受信）としてパース
            TextEventPayload request;
            try
            {
                request = await JsonSerializer.DeserializeAsync<TextEventPayload>(req.Body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            catch (Exception)
            {
                log.LogWarning("Send event is not text event. body = {body}", await new StreamReader(req.Body).ReadToEndAsync());
                return null;
            }

            // 一件目のイベントのみ取得
            var firstEvent = request?.Events.FirstOrDefault();
            if (firstEvent == null || firstEvent.Type != "message")
            {
                log.LogWarning("Send event is not text event. body = {body}", await new StreamReader(req.Body).ReadToEndAsync());
                return null;
            }

            // オウム返しする
            // この一行をコメントアウトする
            await Reply(firstEvent.ReplyToken, firstEvent.Message.Text);

            // 以下のコメントアウトをはずす
            // var prompt = firstEvent.Message.Text;
            // var client = new OpenAIClient(
            //     new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_URL")),
            //     new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")));
            // var responseWithoutStream = await client.GetChatCompletionsAsync(
            //     Environment.GetEnvironmentVariable("AZURE_OPENAI_API_MODEL_NAME"),
            //     new ChatCompletionsOptions()
            //     {
            //         Messages =
            //         {
            //             new ChatMessage(ChatRole.System, "あなたは親切なアシスタントAIです。"),
            //             new ChatMessage(ChatRole.User, prompt),
            //         },
            //         MaxTokens = 800,
            //     });
            // if (responseWithoutStream.Value == null || !responseWithoutStream.Value.Choices.Any())
            // {
            //     log.LogWarning("Azure OpenAI Service response is null. prompt = {prompt}", prompt);
            //     return null;
            // }
            // var replyText = responseWithoutStream.Value.Choices[0].Message.Content;
            // log.LogInformation("replyText: {replyText}", replyText);
            // await Reply(firstEvent.ReplyToken, replyText);

            return new OkResult();
        }

        /// <summary>
        /// reply APIをコールする
        /// </summary>
        /// <param name="replyToken">リプライトークン</param>
        /// <param name="text">送信する文言</param>
        /// <returns></returns>
        private async Task Reply(string replyToken, string text)
        {
            var reply = new ReplyPayload
            {
                ReplyToken = replyToken,
                Messages = new List<ReplyPayload.TextMessage> { new ReplyPayload.TextMessage { Text = text } },
            };
            var json = JsonSerializer.Serialize(reply, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = httpClientFactory.CreateClient("line");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            await client.PostAsync("/v2/bot/message/reply", content);
        }
    }
}
