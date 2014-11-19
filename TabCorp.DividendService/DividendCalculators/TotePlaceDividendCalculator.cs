using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService.DividendCalculators
{
    public class TotePlaceDividendCalculator : BaseDividendCalculator
    {
        public TotePlaceDividendCalculator() : base(12)
        {
                
        }

        protected override Dictionary<String, IEnumerable<Bet>> FindWinners(IEnumerable<Bet> bets, RaceResult raceResult)
        {
            var top3Starters = raceResult.StarterResults.Take(3);
            return bets.Where(bet => top3Starters.Contains(bet.SelectionString))
                        .GroupBy(x => x.SelectionString)
                        .ToDictionary(x => x.Key, y => y.AsEnumerable());
        }
    }
}
