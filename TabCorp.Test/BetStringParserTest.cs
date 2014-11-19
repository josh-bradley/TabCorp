using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabCorp.DividendService;

namespace TabCorp.Test
{
    [TestClass]
    public class BetStringParserTest
    {
        [TestMethod]
        public void Should_handle_no_bets()
        {
            var parser = new BetStringParser();

            var results = parser.ParseBetStrings(String.Empty);
        
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Should_return_seperate_entry_for_each_bet_type()
        {
            var parser = new BetStringParser();
            var betString = "W:1:100;P:4:59;W:4:34";

            var results = parser.ParseBetStrings(betString);

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void Should_parse_bet_type_correctly()
        {
            var parser = new BetStringParser();
            var betString = "W:1:100";

            var results = parser.ParseBetStrings(betString);

            Assert.AreEqual("W", results.Keys.First());
        }

        [TestMethod]
        public void Should_parse_selection_string_correctly()
        {
            var parser = new BetStringParser();
            var betString = "W:1:100";

            var results = parser.ParseBetStrings(betString);

            Assert.AreEqual("1", results["W"][0].SelectionString);
        }

        [TestMethod]
        public void Should_parse_bet_amount_correctly()
        {
            var parser = new BetStringParser();
            var betString = "W:1:100";

            var results = parser.ParseBetStrings(betString);

            Assert.AreEqual(100, results["W"][0].BetAmount);
        }

        [TestMethod]
        public void Should_return_correct_number_of_bets()
        {
            var parser = new BetStringParser();
            var betString = "W:1:100;P:4:59;W:4:34;Q:1,2:12;E:3,4:23;Q:2,3:12";

            var results = parser.ParseBetStrings(betString);

            Assert.AreEqual(2, results["W"].Count);
            Assert.AreEqual(1, results["P"].Count);
            Assert.AreEqual(2, results["Q"].Count);
            Assert.AreEqual(1, results["E"].Count);
        }
    }
}
