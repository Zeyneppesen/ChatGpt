using OpenAI_API;

namespace ChatGpt.Extensions
{
    public static class OpenAIAPIExtensions
    {
        public static void AddOpenAIAPI(this IServiceCollection services, string apiKey)
        {
            services.AddSingleton<OpenAIAPI>(new OpenAIAPI(apiKey));
        }
    }
}
