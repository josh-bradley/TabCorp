using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService.DividendCalculators
{
    public class ToteQuinellaDividendCalculator : BaseDividendCalculator
    {
        public ToteQuinellaDividendCalculator() : base(18)
        {
        }

        protected override Dictionary<String, IEnumerable<Bet>> FindWinners(IEnumerable<Bet> bets, RaceResult raceResult)
        {
            var firstAndSecondPlace = raceResult.StarterResults.Take(2);
            var winningBets = bets.Where(bet => firstAndSecondPlace.Intersect(bet.StarterNumberSelections).Count() == 2);

            var winningSelectionBets = new Dictionary<String, IEnumerable<Bet>>();
            var selectionString = String.Format("{0},{1}", raceResult.FirstPlaceStarterNumber, raceResult.SecondPlaceStarterNumber);
            winningSelectionBets.Add(selectionString, winningBets);

            return winningSelectionBets;
        }
    }
}
