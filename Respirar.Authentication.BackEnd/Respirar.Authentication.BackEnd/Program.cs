using Respirar.Authentication.BackEnd.Application.CommandHandlers;
using Respirar.Authentication.BackEnd.Application.Commands;
using Respirar.Authentication.BackEnd.Application.DependencyInjection;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string host = builder.Configuration["Keyrock:Host"];
byte[] credentialsBytes = Encoding.UTF8.GetBytes($"{builder.Configuration["Keyrock:ClientId"]}:{builder.Configuration["Keyrock:ClientSecret"]}");
string clientCredentials = Convert.ToBase64String(credentialsBytes);

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);


builder.Services.AddKeyrockApiClient(httpClient =>
{
    httpClient.BaseAddress = new(host);
    httpClient.AddKeyrockSubjectHeaders(host, clientCredentials);
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
