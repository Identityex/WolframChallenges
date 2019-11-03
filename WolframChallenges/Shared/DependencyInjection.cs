using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolframChallenges.Shared
{
    public class DependencyInjection
    {

        public static ContainerBuilder builder;
        public static IContainer Container;
        /// <summary>
        /// Builds the Container for injection using autofac
        /// </summary>
        /// <returns></returns>
        public static void BuildDependencyInjectionContainer()
        {

            builder = new ContainerBuilder();



            //Register anything we would like to have an injection with
            builder.RegisterType<Utilities>().As<IUtilities>();
            builder.RegisterType<DeriffleList>().AsSelf();

            Container = builder.Build();

        }

    }
}
