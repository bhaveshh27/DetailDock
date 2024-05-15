using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Domain.Entities
{
    public class Response
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("responseContent")]
        public ResponseData ResponseContent { get; set; }
    }
}
