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

namespace Api.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorsFilteringService, AuthorFilteringService>();
        services.AddScoped<IBooksFilteringService, BooksFilteringService>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>(); 
        services.AddScoped<IBusinessRuleValidationService, BusinessRuleValidationServiceService>();
        
        return services;
    }

    public static IServiceCollection AddAppMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllAuthorsQuery).Assembly));
        
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, typeof(AuthorProfile).Assembly);
        services.AddAutoMapper(cfg => { }, typeof(BookProfile).Assembly);
        
        return services;
    }

    public static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryManagementDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
     
        return services;
    }
}