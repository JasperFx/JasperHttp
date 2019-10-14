﻿using System.Collections.Generic;

namespace JasperHttp.Routing
{
    public class Segment : ISegment
    {
        public Segment(string path, int position)
        {
            Path = path;
            Position = position;
            SegmentPath = path;
        }

        public string Path { get; }
        public int Position { get; }

        public string CanonicalPath()
        {
            return Path;
        }

        public string SegmentPath { get; }

        public string SegmentFromModel(object model)
        {
            return Path;
        }

        public string ReadRouteDataFromMethodArguments(List<object> arguments)
        {
            return Path;
        }

        public string SegmentFromParameters(IDictionary<string, object> parameters)
        {
            return Path;
        }
    }
}
