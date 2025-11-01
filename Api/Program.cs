using Api.Configurations;
using Api.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());

builder.Services.AddAppDatabase(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddAppServices();
builder.Services.AddAppMediatr();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
