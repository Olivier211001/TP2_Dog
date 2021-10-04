using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ApiHelper
{
    public class ListBreedModel
    {
        public static IEnumerable Keys { get; set; }
        [JsonProperty("message")]

        public Dictionary<string, List<string>> Breeds { get; set;}
    }
}
