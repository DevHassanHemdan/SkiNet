using API.Errors;
using Core.Interfaces;
using InfraStructure.Data;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(_IGenericRepository<>), (typeof(_GenericRepository<>)));
            services.AddScoped<_IUnitOfWork, _UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                              .Where(e => e.Value.Errors.Count > 0)
                                              .SelectMany(x => x.Value.Errors)
                                              .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
