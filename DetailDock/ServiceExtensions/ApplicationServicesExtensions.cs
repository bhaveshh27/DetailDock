using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.Handler;
using DetailDock.Core.Application.Features.Program.Query;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using DetailDock.Infrastructure.Repositories;
using MediatR;

namespace DetailDock.ServiceExtensions
{
    public static class ApplicationServicesExtensions
    {
        public static void Register(this IServiceCollection service)
        {
            service.TransientServicesRegister();
            service.ProgramServiceRegister();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static void TransientServicesRegister(this IServiceCollection services)
        {
            services.AddTransient<IProgramRepository, ProgramRepository>();
        }

        public static void ProgramServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateProgramCommand, IResponse>, CreateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProgramCommand, IResponse>, UpdateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllProgramQuery, IResponse>, GetAllProgramsQueryHandler>();
            services.AddTransient<IRequestHandler<GetProgramByIdQuery, IResponse>, GetProgramByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteProgramCommand, IResponse>, DeleteProgramCommandHandler>();
        }

        
    }

}
