using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> GetAIBasedResult(string SearchText)
        {
            //  string APIKey = "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";
            string APIKey = "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";
            string answer=string.Empty;
            var openai=new OpenAIAPI(APIKey);
            CompletionRequest completion=new CompletionRequest();
            completion.Prompt = SearchText;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 900;
            var result=openai.Completions.CreateCompletionAsync(completion);
            foreach(var item in result.Result.Completions)
            {
                answer=item.Text;
            }
            return Ok(answer);
        }
    }
}
