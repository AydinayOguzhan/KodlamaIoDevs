using Application.Features.Authorizations.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.SocialLinks.Rules;
using Application.Features.Technologies.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<SocialLinkBusinessRules>();
            services.AddScoped<AuthorizationBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();

            services.AddScoped<IAuthSevrice, AuthService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            return services;
        }
    }
}
