using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabCorp.DividendService;
using TabCorp.DividendService.DividendCalculators;

namespace TabCorp.Test
{
    [TestClass]
    public class TotePlaceDividendCalculatorTest
    {
        [TestMethod]
        public void Should_return_three_result()
        {
            var totePlaceCalculator = new TotePlaceDividendCalculator();

            var bets = Mother.GetThreeWinPlaceBets();
            var raceResult = Mother.GetRaceResult();;
            var results = totePlaceCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Should_set_bet_strings_correctly()
        {
            var totePlaceCalculator = new TotePlaceDividendCalculator();

            var bets = Mother.GetThreeWinPlaceBets();
            var raceResult = Mother.GetRaceResult();;
            var results = totePlaceCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(1, results.Count(x => x.SelectionString == "1"));
            Assert.AreEqual(1, results.Count(x => x.SelectionString == "2"));
            Assert.AreEqual(1, results.Count(x => x.SelectionString == "3"));
        }

        [TestMethod]
        public void Should_calculate_each_place_dividend_correctly()
        {
            var totePlaceCalculator = new TotePlaceDividendCalculator();

            var bets = Mother.GetThreeWinPlaceBets(150, 50, 100);
            var raceResult = Mother.GetRaceResult();
            var results = totePlaceCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(0.59, results.Single(x => x.SelectionString == "1").Dividend);
            Assert.AreEqual(1.76, results.Single(x => x.SelectionString == "2").Dividend);
            Assert.AreEqual(0.88, results.Single(x => x.SelectionString == "3").Dividend);
        }

        [TestMethod]
        public void Should_calculate_each_place_dividend_correctly_multibets_per_place()
        {
            var totePlaceCalculator = new TotePlaceDividendCalculator();

            var bets = Mother.GetThreeWinPlaceBets(25, 100, 100);
            bets.Add(new Bet("1", 75));
            var raceResult = Mother.GetRaceResult();;
            var results = totePlaceCalculator.GetDividends(bets, raceResult);

            Assert.AreEqual(0.88, results.Single(x => x.SelectionString == "1").Dividend);
        }

    }
}
