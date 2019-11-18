using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using WolframChallenges.Challenges;
using WolframChallenges.Shared;

namespace WolframChallenges
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DependencyInjection.BuildDependencyInjectionContainer();

            RunExponentiation();
            //Pause to read output
            Console.ReadLine();
        }

        public static void RunExponentiation()
        {

            Algorithms alg = DependencyInjection.Container.Resolve<Algorithms>();
            var num = alg.Exponentiation(2, 18);
            Console.WriteLine(num);
        }

        public static void RunRiffle()
        {
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
        }
    }
}
