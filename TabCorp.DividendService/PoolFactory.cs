using System;
using System.Collections.Generic;

namespace TabCorp.DividendService
{
    public class PoolFactory : IPoolFactory
    {
        public PoolFactory(Dictionary<string, Pool> dividendCalculators)
        {
            _dividendCalculators = dividendCalculators;
        }

        private Dictionary<string, Pool> _dividendCalculators;

        public Pool GetDividendCalculator(String betType)
        {
            return _dividendCalculators[betType];
        }
    }
}