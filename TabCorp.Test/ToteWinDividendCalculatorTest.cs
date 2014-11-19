using System.Collections.Generic;
using System.Linq;
using TabCorp.DividendService;
using TabCorp.DividendService.DividendCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TabCorp.Test
{
    [TestClass]
    public class ToteWinDividendCalculatorTest
    {
        [TestMethod]
        public void Should_return_single_result()
        {
            var toteWinCalculator = new ToteWinDividendCalculator();

            var bet = new Bet("1", 1);
            var raceResult = Mother.GetRaceResult();
            var results = toteWinCalculator.GetDividends(new List<Bet>() { bet }, raceResult);

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void Should_set_bet_string_correctly()
        {
            var toteWinCalculator = new ToteWinDividendCalculator();

            var bet = new Bet("1", 1);
            var raceResult = Mother.GetRaceResult();
            var results = toteWinCalculator.GetDividends(new List<Bet>() { bet }, raceResult);

            Assert.AreEqual("1", results.First().SelectionString);
        }

        [TestMethod]
        public void Should_take_15_percent_commission_before_calculating_dividends()
        {
            var toteWinCalculator = new ToteWinDividendCalculator();

            var bet = new Bet("1", 100);
            var raceResult = Mother.GetRaceResult();
            var results = toteWinCalculator.GetDividends(new List<Bet>() { bet }, raceResult);

            Assert.AreEqual(0.85, results.First().Dividend);
        }

        [TestMethod]
        public void Should_calculate_dividend_correctly_with_multiple_winners()
        {
            var toteWinCalculator = new ToteWinDividendCalculator();

            var bet1 = new Bet("1", 100);
            var bet2 = new Bet("1", 200);
            
            var raceResult = Mother.GetRaceResult();
            var results = toteWinCalculator.GetDividends(new List<Bet>() { bet1, bet2 }, raceResult);

            Assert.AreEqual(0.85, results.First().Dividend);
        }

        [TestMethod]
        public void Should_only_divide_amongst_winning_bets()
        {
            var toteWinCalculator = new ToteWinDividendCalculator();

            var bet1 = new Bet("1", 100);
            var bet2 = new Bet("1", 150);
            var bet3 = new Bet("2", 50);
            
            var raceResult = Mother.GetRaceResult();
            var results = toteWinCalculator.GetDividends(new List<Bet>() { bet1, bet2, bet3 }, raceResult);

            Assert.AreEqual(1.02, results.First().Dividend);
        }
    }
}
