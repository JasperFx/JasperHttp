﻿using System.Linq;
using Alba.Stubs;
using JasperHttp.Routing;
using Shouldly;
using Xunit;

namespace HttpTests.Routing
{
    public class SpreadTests
    {
        [Fact]
        public void get_empty_spread_values_from_nested()
        {
            var parameter = new Spread(4);

            var env = StubHttpContext.Empty();

            parameter.SetValues(env, "a/b/c/d".Split('/'));

            env.GetSpreadData().Count().ShouldBe(0);
        }

        [Fact]
        public void get_empty_spread_values_from_root()
        {
            var parameter = new Spread(0);

            var env = StubHttpContext.Empty();

            parameter.SetValues(env, new string[0]);

            env.GetSpreadData().Count().ShouldBe(0);
        }

        [Fact]
        public void set_spread_values()
        {
            var parameter = new Spread(2);

            var env = StubHttpContext.Empty();

            parameter.SetValues(env, "a/b/c/d/e".Split('/'));

            env.GetSpreadData().ShouldBe(new[] {"c", "d", "e"});
        }

        [Fact]
        public void set_spread_values_from_0()
        {
            var parameter = new Spread(0);

            var env = StubHttpContext.Empty();

            parameter.SetValues(env, "a/b/c/d/e".Split('/'));

            env.GetSpreadData().ShouldBe(new[] {"a", "b", "c", "d", "e"});
        }

        [Fact]
        public void the_canonical_path_is_blank()
        {
            new Spread(2).CanonicalPath().ShouldBe(string.Empty);
        }
    }
}
