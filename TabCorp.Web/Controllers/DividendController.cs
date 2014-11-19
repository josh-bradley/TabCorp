using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TabCorp.DividendService;
using TabCorp.Web.Models;

namespace TabCorp.Web.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DividendController : ApiController
    {
        private readonly IDividendService _dividendService;

        public DividendController(IDividendService dividendService)
        {
            _dividendService = dividendService;
        }

        [HttpPost]
        public IEnumerable<String> Post([FromBody]ToteRaceBets raceResult)
        {
            return _dividendService.GetListOfDividends(raceResult.BetString, raceResult.ResultsString);
        }

    }
}