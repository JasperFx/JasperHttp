﻿using System;
using System.Reflection;
using Jasper.Conneg;
using JasperHttp.Model;
using LamarCodeGeneration.Frames;
using LamarCodeGeneration.Model;

namespace JasperHttp.ContentHandling
{
    public class UseReader : MethodCall
    {
        public UseReader(RouteChain chain, bool isLocal) : base(typeof(IRequestReader),
            selectMethod(chain.InputType))
        {
            if (isLocal) Target = new Variable(typeof(IRequestReader), nameof(RouteHandler.Reader));

            creates.Add(ReturnVariable);
        }

        private static MethodInfo selectMethod(Type inputType)
        {
            return typeof(IRequestReader)
                .GetMethod(nameof(IRequestReader.ReadFromRequest))
                .MakeGenericMethod(inputType);
        }
    }
}
