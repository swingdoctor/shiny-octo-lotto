using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInARow.LotteryWinner.ResultsParser.EuroMillions
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    public class PastResultsRetriever
    {
        private readonly Uri baseUri = new Uri("http://www.lottery.co.uk/results/euromillions/");

        private readonly List<string> resultsPages = new List<string>() { "archive-2004.asp", "archive-2005.asp", "archive-2006.asp", "archive-2007.asp", "archive-2008.asp", "archive-2009.asp", "archive-2010.asp", "archive-2011.asp", "archive-2012.asp", "archive-2013.asp" };

        public IEnumerable<string> GetResultPages()
        {
            var returnList = new List<string>();
            var client = new HttpClient() { BaseAddress = this.baseUri };
            
            foreach (var page in this.resultsPages)
            {
                ////var response = client.GetStringAsync(page);
                ////returnList.Add(response.Result);

                // Don't spam the site
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            return returnList;
        } 
    }
}
