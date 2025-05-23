using GranShopAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conexao = builder.Configuration.GetConnectionString("conexao");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(conexao));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GranShop",
        Version = "v1",
        Description = "Documentação API",
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var DbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
       await DbContext.Database.EnsureCreatedAsync();
        //await DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GranShop v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
