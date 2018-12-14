﻿using Newtonsoft.Json.Linq;

namespace HotChocolate.AspNetClassic
{
    internal class ClientQueryRequest
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
