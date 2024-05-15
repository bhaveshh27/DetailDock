using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.Handler;
using DetailDock.Core.Application.Features.BasicInfo.Query;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.Handler;
using DetailDock.Core.Application.Features.Program.Query;
using DetailDock.Core.Application.Features.Question.Command;
using DetailDock.Core.Application.Features.Question.Handler;
using DetailDock.Core.Application.Features.Question.Query;
using DetailDock.Core.Application.Features.Response.Command;
using DetailDock.Core.Application.Features.Response.Handler;
using DetailDock.Core.Application.Features.Response.Query;
using DetailDock.Core.Application.Features.ResponseData.Command;
using DetailDock.Core.Application.Features.ResponseData.Handler;
using DetailDock.Core.Application.Features.ResponseData.Query;
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
            service.QuestionServiceRegister();
            service.BasicInfoServiceRegister();
            service.ResponseServiceRegister();
            service.ResponseDataServiceRegister();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static void TransientServicesRegister(this IServiceCollection services)
        {
            services.AddTransient<IProgramRepository, ProgramRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IBasicInfoRepository, BasicInfoRepository>();
            services.AddTransient<IResponseRepository, ResponseRepository>();
            services.AddTransient<IResponseDataRepository, ResponseDataRepository>();
        }

        public static void ProgramServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateProgramCommand, IResponse>, CreateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateProgramCommand, IResponse>, UpdateProgramCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllProgramQuery, IResponse>, GetAllProgramsQueryHandler>();
            services.AddTransient<IRequestHandler<GetProgramByIdQuery, IResponse>, GetProgramByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteProgramCommand, IResponse>, DeleteProgramCommandHandler>();
        }
        public static void QuestionServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateQuestionCommand, IResponse>, CreateQuestionCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateQuestionCommand, IResponse>, UpdateQuestionCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllQuestionsQuery, IResponse>, GetAllQuestionsQueryHandler>();
            services.AddTransient<IRequestHandler<GetQuestionByIdQuery, IResponse>, GetQuestionByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteQuestionCommand, IResponse>, DeleteQuestionCommandHandler>();
        }
        public static void BasicInfoServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateBasicInfoCommand, IResponse>, CreateBasicInfoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBasicInfoCommand, IResponse>, UpdateBasicInfoCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllBasicInfoQuery, IResponse>, GetAllBasicInfoQueryHandler>();
            services.AddTransient<IRequestHandler<GetBasicInfoByIdQuery, IResponse>, GetBasicInfoByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteBasicInfoCommand, IResponse>, DeleteBasicInfoCommandHandler>();

        }
        public static void ResponseServiceRegister(this IServiceCollection services) 
        {
            services.AddTransient<IRequestHandler<CreateResponseCommand, IResponse>, CreateResponseCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateResponseCommand, IResponse>, UpdateResponseCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllResponsesQuery, IResponse>, GetAllResponsesQueryHandler>();
            services.AddTransient<IRequestHandler<GetResponseByIdQuery, IResponse>, GetResponseByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteResponseCommand, IResponse>, DeleteResponseCommandHandler>();
        }
        public static void ResponseDataServiceRegister(this IServiceCollection services) 
        {
            services.AddTransient<IRequestHandler<CreateResponseDataCommand, IResponse>, CreateResponseDataCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateResponseDataCommand, IResponse>, UpdateResponseDataCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllResponseDataQuery, IResponse>, GetAllResponseDataQueryHandler>();
            services.AddTransient<IRequestHandler<GetResponseDataByIdQuery, IResponse>, GetResponseDataByIdQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteResponseDataCommand, IResponse>, DeleteResponseDataCommandHandler>();
        }


    }

}
