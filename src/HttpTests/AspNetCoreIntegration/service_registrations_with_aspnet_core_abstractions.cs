﻿using System;
using Jasper;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace HttpTests.AspNetCoreIntegration
{
    public class service_registrations_with_aspnet_core_abstractions
    {
        public interface IService
        {
        }

        public class FooService : IService
        {
        }

        [Fact]
        public void adds_the_core_service_provider_abstractions()
        {
            var registry = new JasperRegistry();
            registry.Services.AddTransient<IService, FooService>();

            using (var runtime = JasperHost.For(registry))
            {
                runtime.Get<IServiceProvider>().ShouldNotBeNull();
                runtime.Get<IServiceScopeFactory>().ShouldNotBeNull();
            }
        }

        [Fact]
        public void services_registered_by_the_DI_abstraction_are_in_the_container()
        {
            var registry = new JasperRegistry();
            registry.Services.AddTransient<IService, FooService>();

            using (var runtime = JasperHost.For(registry))
            {
                runtime.Container.Model.For<IService>().Default.ImplementationType
                    .ShouldBe(typeof(FooService));
            }
        }
    }
}
