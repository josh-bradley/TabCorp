using System;

namespace TabCorp.DividendService
{
    public interface IPoolFactory
    {
        Pool GetDividendCalculator(String betType);
    }
}