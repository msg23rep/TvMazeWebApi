using Microsoft.EntityFrameworkCore;
using TvMazeApi.Authentication;
using TvMazeApi.Interfaces.Authentication;
using TvMazeApi.Interfaces.Repositories;
using TvMazeApi.Interfaces.Services;
using TvMazeApi.Repositories;
using TvMazeApi.Services;
using TvMazeApi.TvMazeData;
using TvMazeApi.Utils;
using TvMazeApi.Utils.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TvMazeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpClient<TvMazeService>("tvMazeClient", (httpClient) =>
{
    httpClient.BaseAddress = new Uri(Constants.TvMazeApiBaseUrl);
});

builder.Services.AddScoped<ITvMazeService, TvMazeService>();
builder.Services.AddScoped<ITvMazeRepository, TvMazeRepository>();

builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();
builder.Services.AddScoped<ApiKeyAuthFilter>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(TvMazeMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
