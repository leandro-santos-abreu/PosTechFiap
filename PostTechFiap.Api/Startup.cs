using DatabaseMigration.Migrations;
using FluentMigrator.Runner;

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
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        if (env.EnvironmentName != "Test")
        {
            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            migrator.MigrateUp();
        }

    }
}
