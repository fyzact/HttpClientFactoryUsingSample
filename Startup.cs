using System;
using HttpClientFactoryUsingSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HttpClientFactoryUsingSample.DelegatingHandlers;

namespace HttpClientFactoryUsingSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ValidateUserAgentKeyHeaderHandler>();
            services.AddHttpClient("movie-sample-api", c =>
            {
                c.BaseAddress = new Uri("https://sampleapis.com/");
               
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryUsingSample");
            }).AddHttpMessageHandler<ValidateUserAgentKeyHeaderHandler>();
            services.AddHttpClient<DummyEmployeeService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
