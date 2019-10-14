﻿using System.Collections.Generic;

namespace JasperHttp.Routing
{
    public static class HttpVerbs
    {
        public static readonly string GET = "GET";
        public static readonly string POST = "POST";
        public static readonly string PUT = "PUT";
        public static readonly string DELETE = "DELETE";
        public static readonly string OPTIONS = "OPTIONS";
        public static readonly string PATCH = "PATCH";
        public static readonly string HEAD = "HEAD";

        public static readonly IEnumerable<string> All = new[] {GET, POST, PUT, DELETE, OPTIONS, PATCH, HEAD};
    }
}
