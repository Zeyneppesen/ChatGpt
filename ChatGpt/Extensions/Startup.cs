using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChatGpt.Extensions;

using Configuration = FluentAssertions.Common.Configuration;

namespace ChatGpt.Extensions
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenAIAPI(_configuration.GetSection("APIKey").Value);
            services.AddControllers();
        }
    }
}
