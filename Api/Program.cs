using Api.ExceptionHandling;
using Application.Abstractions.Services;
using Application.Implementation.Queries.Author;
using Application.Implementation.Services;
using Application.Implementation.Services.Filtering.Authors;
using Application.Implementation.Services.Filtering.Books;
using Application.Mapping.AutoMappingProfiles;
using Domain.Abstractions.Repositories;
using Infrastructure.DB.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
builder.Services.AddAutoMapper(cfg => { }, typeof(AuthorProfile).Assembly);
builder.Services.AddAutoMapper(cfg => { }, typeof(BookProfile).Assembly);
builder.Services.AddDbContext<LibraryManagementDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllAuthorsQuery).Assembly));

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IAuthorsFilteringService, AuthorFilteringService>();
builder.Services.AddScoped<IBooksFilteringService, BooksFilteringService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBusinessRuleValidationService, BusinessRuleValidationServiceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
