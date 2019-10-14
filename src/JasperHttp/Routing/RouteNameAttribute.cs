﻿using System;

namespace JasperHttp.Routing
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RouteNameAttribute : Attribute
    {
        public RouteNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
