using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Program.DTO
{
    public class ProgramDTO
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
