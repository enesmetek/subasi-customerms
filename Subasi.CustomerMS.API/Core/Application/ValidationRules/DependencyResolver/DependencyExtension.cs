using FluentValidation;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands;
using Subasi.CustomerMS.API.Core.Application.ValidationRules.CommandRequestValidators.AddressCommandRequestValidators;
using Subasi.CustomerMS.API.Core.Application.ValidationRules.CommandRequestValidators.CustomerCommandRequestValidators;

namespace Subasi.CustomerMS.API.Core.Application.ValidationRules.DependencyResolver
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<CreateCustomerCommandRequest>, CreateCustomerCommandRequestValidator>();
            services.AddTransient<IValidator<UpdateCustomerCommandRequest>, UpdateCustomerComandRequestValidator>();

            services.AddTransient<IValidator<CreateAddressCommandRequest>, CreateAddressCommandRequestValidator>();
            services.AddTransient<IValidator<UpdateAddressCommandRequest>, UpdateAddressCommandRequestValidator>();
        }
    }
         
}
