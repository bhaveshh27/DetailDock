using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Domain.Entities
{
    public class Question
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        [JsonProperty("questionType")]
        public string QuestionType { get; set; }

        [JsonProperty("allowOther")]
        public bool AllowOther { get; set; }

        [JsonProperty("options")]
        public List<string> Options { get; set; }
    }
}
