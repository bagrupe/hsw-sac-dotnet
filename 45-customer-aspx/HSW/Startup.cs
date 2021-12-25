using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HSW;
public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "sac1_customer_aspx", Version = "v1" });
        });
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("customer"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "sac1_customer_aspx v1"));
        }

        app.UseCors(builder =>
                          {
                              builder.AllowAnyOrigin();
                              builder.AllowAnyHeader();
                              builder.AllowAnyMethod();
                          });

        //app.UseHttpsRedirection();

        app.UseRouting();

        //app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}