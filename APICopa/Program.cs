using Amazon.Auth.AccessControlPolicy;
using Microsoft.EntityFrameworkCore;
using ProjetoCopa.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjetoCopaContext>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ProjetoCopa"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  );

app.UseAuthorization();

app.MapControllers();

app.Run();
