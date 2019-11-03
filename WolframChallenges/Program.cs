using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using WolframChallenges.Shared;

namespace WolframChallenges
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DependencyInjection.BuildDependencyInjectionContainer();

            List<List<object>> objectList = new List<List<object>>
            {
                new List<object>
                {
                    "a","b","c"
                },
                new List<object>
                {
                    1,2,3
                }
            };

            DeriffleList deriffleList = DependencyInjection.Container.Resolve<DeriffleList>();
            IUtilities utilities = DependencyInjection.Container.Resolve<IUtilities>();
            string listString = utilities.GetListString(deriffleList.DeRiffle(deriffleList.Riffle(objectList), 2));


            Console.WriteLine(listString);
            //Pause to read output
            Console.ReadLine();
        }
    }
}
