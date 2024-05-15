using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Domain.Entities
{
    public class ResponseData
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("numeric")]
        public double? Numeric { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}
