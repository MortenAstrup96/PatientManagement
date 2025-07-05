
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddTransient<IRequestHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();
        //services.AddTransient<IRequestHandler<GetUserByIdQuery, UserDto>, GetUserByIdQueryHandler>();
        return services;
    }
}
