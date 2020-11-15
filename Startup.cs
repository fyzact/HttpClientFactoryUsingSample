using System;
using HttpClientFactoryUsingSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HttpClientFactoryUsingSample.DelegatingHandlers;
using Polly;

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
            services.AddHttpClient<DummyEmployeeService>()
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _=>TimeSpan.FromSeconds(6)))
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
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
