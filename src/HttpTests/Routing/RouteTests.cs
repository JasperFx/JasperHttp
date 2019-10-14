﻿using System;
using JasperHttp.Routing;
using Shouldly;
using Xunit;

namespace HttpTests.Routing
{
    public class RouteTests
    {
        [Fact]
        public void argument_in_brackets()
        {
            var arg = Route.ToParameter("{bar}", 3).ShouldBeOfType<RouteArgument>();
            arg.Position.ShouldBe(3);
            arg.Key.ShouldBe("bar");
        }

        [Fact]
        public void argument_starting_with_colon()
        {
            var arg = Route.ToParameter(":foo", 2).ShouldBeOfType<RouteArgument>();
            arg.Position.ShouldBe(2);
            arg.Key.ShouldBe("foo");
        }

        [Fact]
        public void blank_segment()
        {
            Route.ToParameter("foo", 0).ShouldBeOfType<Segment>().Path.ShouldBe("foo");
        }

        [Fact]
        public void cannot_have_a_spread()
        {
            Exception<InvalidOperationException>.ShouldBeThrownBy(() => { new Route("...", "GET"); });
        }

        [Fact]
        public void cannot_have_multiple_spreads_either()
        {
            Action action = () => { new Route("a/.../b/...", "GET"); };

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void cannot_have_only_an_argument()
        {
            Exception<InvalidOperationException>.ShouldBeThrownBy(() => { new Route(":arg", "GET"); });
        }

        [Fact]
        public void spread()
        {
            Route.ToParameter("...", 4).ShouldBeOfType<Spread>()
                .Position.ShouldBe(4);
        }

        [Fact]
        public void spread_has_to_be_last()
        {
            Action action = () => { new Route("a/.../b", "GET"); };
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }

    public class building_a_route_from_segments_Tests
    {
        public building_a_route_from_segments_Tests()
        {
            segments = new ISegment[]
                {new Segment("folder", 0), new Segment("folder2", 1), new RouteArgument("name", 2)};


            route = new Route(segments, HttpVerbs.PUT);
        }

        private readonly ISegment[] segments;
        private readonly Route route;

        [Fact]
        public void should_build_the_pattern_from_the_segments()
        {
            route.Pattern.ShouldBe("folder/folder2/:name");
        }

        [Fact]
        public void should_remember_the_httpMethod()
        {
            route.HttpMethod.ShouldBe(HttpVerbs.PUT);
        }

        [Fact]
        public void still_derives_the_name()
        {
            route.Name.ShouldBe("PUT:folder/folder2/:name");
        }

        [Fact]
        public void still_has_the_original_segments()
        {
            route.Segments.ShouldHaveTheSameElementsAs(segments);
        }
    }
}
