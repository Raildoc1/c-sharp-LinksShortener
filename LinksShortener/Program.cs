using LinksShortener.Data.Common;
using LinksShortener.Data.PostgresSQL;
using LinksShortener.Interface;
using ShortenerConfig = LinksShortener.Logic.Shortener.Config;
using ShortenerController = LinksShortener.Logic.Shortener.Controller;
using PostgresSQLConfig = LinksShortener.Data.PostgresSQL.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Random>();
builder.Services.AddScoped<LinksDbContext>();
builder.Services.AddScoped<IRepository, DbRepository>();
builder.Services.AddScoped<ShortenerController>();

builder
   .Services
   .AddOptions<ShortenerConfig>()
   .BindConfiguration("Shortener", o => o.BindNonPublicProperties = true)
   .Validate(c => c.Validate())
   .ValidateOnStart();

builder
   .Services
   .AddOptions<PostgresSQLConfig>()
   .BindConfiguration("Database", o => o.BindNonPublicProperties = true);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RestMapper.Map(app);

app.Run();
