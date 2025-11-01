using Application.Abstractions.Repositories;
using Application.Implementation.Queries.Author;
using Application.Mapping.AutoMappingProfiles;
using Infrastructure.DB.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>(); 
        
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