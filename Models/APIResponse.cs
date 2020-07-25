using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapStoneProofOfConcept.Models
{
    public class APIResponse
    {
        [JsonPropertyName ("data")]
        public List<APIResult> Results { get; set; }
    }

    public class APIResult
    {
        public string Email { get; set; }
        public string Result { get; set; }

    }
}
