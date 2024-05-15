using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.Handler;
using DetailDock.Core.Application.Features.BasicInfo.Query;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.Handler;
using DetailDock.Core.Application.Features.Program.Query;
using DetailDock.Core.Application.Features.QuestionType.Command;
using DetailDock.Core.Application.Features.QuestionType.Handler;
using DetailDock.Core.Application.Features.QuestionType.Query;
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
            service.QuestionTypeServiceRegister();
            service.BasicInfoServiceRegister();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static void TransientServicesRegister(this IServiceCollection services)
        {
            services.AddTransient<IProgramRepository, ProgramRepository>();
            services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();
            services.AddTransient<IBasicInfoRepository, BasicInfoRepository>();
        }

        public static void ProgramServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateProgramCommand, IResponse>, CreateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProgramCommand, IResponse>, UpdateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllProgramQuery, IResponse>, GetAllProgramsQueryHandler>();
            services.AddTransient<IRequestHandler<GetProgramByIdQuery, IResponse>, GetProgramByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteProgramCommand, IResponse>, DeleteProgramCommandHandler>();
        }
        public static void QuestionTypeServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateQuestionTypeCommand, IResponse>, CreateQuestionTypeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateQuestionTypeCommand, IResponse>, UpdateQuestionTypeCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllQuestionTypesQuery, IResponse>, GetAllQuestionTypesQueryHandler>();
            services.AddTransient<IRequestHandler<GetQuestionTypeByIdQuery, IResponse>, GetQuestionTypeByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteQuestionTypeCommand, IResponse>, DeleteQuestionTypeCommandHandler>();
        }
        public static void BasicInfoServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateBasicInfoCommand, IResponse>, CreateBasicInfoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBasicInfoCommand, IResponse>, UpdateBasicInfoCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllBasicInfoQuery, IResponse>, GetAllBasicInfoQueryHandler>();
            services.AddTransient<IRequestHandler<GetBasicInfoByIdQuery, IResponse>, GetBasicInfoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteBasicInfoCommand, IResponse>, DeleteBasicInfoCommandHandler>();

        }


    }

}
