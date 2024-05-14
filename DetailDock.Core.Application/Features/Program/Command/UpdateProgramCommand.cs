using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Program.Command
{
    public class UpdateProgramCommand : IRequest<IResponse>
    {
        public int ProgramId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
