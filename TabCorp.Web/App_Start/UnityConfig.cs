using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Web.Http;
using TabCorp.DividendService;
using TabCorp.DividendService.DividendCalculators;
using Unity.WebApi;

namespace TabCorp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            var pools = BuildDividendCalculators();

            container.RegisterInstance<IPoolFactory>(new PoolFactory(pools));
            container.RegisterType<IDividendFormater, DividendFormater>();
            container.RegisterType<IRaceResultsParser, RaceResultsParser>();
            container.RegisterType<IBetStringParser, BetStringParser>();
            container.RegisterType<IDividendService, DividendService.DividendService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static Dictionary<string, Pool>  BuildDividendCalculators()
        {
            var pools = new Dictionary<string, Pool>();
            pools.Add("W", new Pool(new ToteWinDividendCalculator(), "Win"));
            pools.Add("P", new Pool(new TotePlaceDividendCalculator(), "Place"));
            pools.Add("E", new Pool(new ToteExactaDividendCalculator(), "Exacta", true));
            pools.Add("Q", new Pool(new ToteQuinellaDividendCalculator(), "Quinella", true));

            return pools;
        }
    }
}