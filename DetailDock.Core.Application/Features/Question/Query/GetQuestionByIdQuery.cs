﻿using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Question.Query
{
    public class GetQuestionByIdQuery : IRequest<IResponse>
    {
        public string QuestionId { get; set; }
    }

}