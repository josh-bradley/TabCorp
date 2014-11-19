using System;
using System.Collections.Generic;
using System.Linq;

namespace TabCorp.DividendService.DividendCalculators
{
    public abstract class BaseDividendCalculator
    {
        protected BaseDividendCalculator(double commission)
        {
            _commissionPercentage = commission;
        }

        private readonly double _commissionPercentage; 

        protected abstract Dictionary<String, IEnumerable<Bet>> FindWinners(IEnumerable<Bet> bets, RaceResult raceResult);

        protected virtual double CalculatePoolTotalAfterCommission(IEnumerable<Bet> bets)
        {
            var poolTotal = bets.Sum(x => x.BetAmount);
            return poolTotal  -  poolTotal*_commissionPercentage/100;
        }

        public List<SelectionDividend> GetDividends(List<Bet> bets, RaceResult raceResult)
        {
            var winningBetsBySelection = FindWinners(bets, raceResult);
            var poolTotal = CalculatePoolTotalAfterCommission(bets);

            var selectionDividends = new List<SelectionDividend>();
            foreach (var selectionBets in winningBetsBySelection)
            {
                var selectionTotal = poolTotal/winningBetsBySelection.Count;
                var dividend = (winningBetsBySelection.Count == 0) ? 0 : selectionTotal/selectionBets.Value.Sum(x => x.BetAmount);
            
                selectionDividends.Add(new SelectionDividend(selectionBets.Key, Math.Round(dividend, 2)));
            }

            return selectionDividends;
        }
    }
}
