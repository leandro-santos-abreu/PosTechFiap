using DatabaseMigration.Migrations;
using FluentMigrator.Runner;
using Prometheus;

namespace PostTechFiap.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(Configuration.GetValue<string>("Settings:DbConnectionString"))
                .ScanIn(typeof(M0001_CreateDDDTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole().AddConsole());

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediator();

        services.AddScoped<IDbContext, DbContext>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IDDDRepository, DDDRepository>();
        services.AddScoped<IContactService, ContactService>();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseMetricServer("/metrics");

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = "swagger"; // Set to an empty string to serve Swagger at the app's root
        });


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapMetrics();
        });

        if (env.EnvironmentName != "Test")
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            migrator.MigrateUp();
        }

    }
}
