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
            string APIKey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(APIKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = SearchText;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 900;
            var result = openai.Completions.CreateCompletionAsync(completion);
            foreach (var item in result.Result.Completions)
            {
                answer = item.Text;
            }
            return Ok(answer);
        }
        //[HttpPost]
        //public async Task<ActionResult> GetAIBasedResult(string SearchText)
        //{
        //   string APIKey = "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";
        //    string answer = string.Empty;

        //    try
        //    {
        //        var openai = new OpenAIAPI(APIKey);
        //        var completion = new CompletionRequest
        //        {
        //            Prompt = SearchText,
        //            Model = OpenAI_API.Models.Model.DavinciText,
        //            MaxTokens = 900
        //        };

        //        var result = await openai.Completions.CreateCompletionAsync(completion);

        //        foreach (var item in result.Completions)
        //        {
        //            answer = item.Text;
        //        }

        //        return Ok(answer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata durumunda isteğin nasıl ele alınacağını belirle
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        //    }
        //}

    }
}