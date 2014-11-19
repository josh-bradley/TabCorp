using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabCorp.DividendService;
using TabCorp.DividendService.DividendCalculators;

namespace TabCorp.Test
{
    [TestClass]
    public class ToteExactaDividendCalculatorTest
    {
        [TestMethod]
        public void Should_return_one_result()
        {
            var toteExactaDividendCalculator = new ToteExactaDividendCalculator();
            var bets = Mother.GetThreeExactaQuinellaBets();
            var raceResult = Mother.GetRaceResult();

            var results = toteExactaDividendCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void Should_set_bet_string_correctly()
        {
            var toteExactaDividendCalculator = new ToteExactaDividendCalculator();
            var bets = Mother.GetThreeExactaQuinellaBets();
            var raceResult = Mother.GetRaceResult();

            var results = toteExactaDividendCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual("1,2", results.First().SelectionString);
        }

        [TestMethod]
        public void Should_take_18_percent_commission()
        {
            var toteExactaDividendCalculator = new ToteExactaDividendCalculator();
            var bets = new List<Bet>() {new Bet("1,2", 100)};
            var raceResult = Mother.GetRaceResult();

            var results = toteExactaDividendCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(0.82, results.First().Dividend);
        }

        [TestMethod]
        public void Should_calculate_dividend_correctly_for_multiple_winners()
        {
            var toteExactaDividendCalculator = new ToteExactaDividendCalculator();

            var bet = new Bet("1,2", 100);
            var bets = new List<Bet> {bet, bet};

            var raceResult = Mother.GetRaceResult();
            var results = toteExactaDividendCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(0.82, results.First().Dividend);
        }

        [TestMethod]
        public void Should_not_match_bets_with_starters_in_wrong_order()
        {
            var toteExactaDividendCalculator = new ToteExactaDividendCalculator();

            var bet1 = new Bet("1,2", 100);
            var bet2 = new Bet("2,1", 100);
            
            var bets = new List<Bet> { bet1, bet2 };

            var raceResult = Mother.GetRaceResult();
            var results = toteExactaDividendCalculator.GetDividends(bets, raceResult);

            // 164 would be the pool total split two ways.
            Assert.AreEqual(1.64, results.First().Dividend);
        }
    }
}
