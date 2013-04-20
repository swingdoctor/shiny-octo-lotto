using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInARow.LotteryWinner.ResultsParser.EuroMillions
{
    using System.Globalization;

    using CuttingEdge.Conditions;

    using HtmlAgilityPack;

    using OneInARow.LotteryWinner.Domain;

    public class PastResultsPageProcessor
    {
        public List<EuroMillionsResult> GetResults(string rawHtmlPage)
        {
            Condition.Requires(rawHtmlPage).IsNotNullOrWhiteSpace();

            var results = new List<EuroMillionsResult>();
            var htmlResultSections = this.GetHtmlResultsSection(rawHtmlPage);

            foreach (var section in htmlResultSections)
            {
                results.Add(this.ParseResultSection(section));
            }

            return results;
        }

        private List<HtmlNode> GetHtmlResultsSection(string rawHtmlPage)
        {
            var results = new List<HtmlNode>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(rawHtmlPage);
            var resultsNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class = 'main']");

            if (resultsNode == null)
            {
                return results;
            }

            foreach (var resultNode in resultsNode.SelectNodes(".//table[@class = 'table']"))
            {
                results.Add(resultNode);
            }

            return results;
        }

        private EuroMillionsResult ParseResultSection(HtmlNode section)
        {
            var date = DateTime.ParseExact(section.SelectSingleNode(".//div[@class = 'floatLeft']/a").InnerText, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var balls = section.SelectNodes(".//td[@class = 'euro-ball-s']").Select(x => Convert.ToInt32(x.InnerText));
            var bonusBalls = section.SelectNodes(".//td[@class = 'euro-lucky-star-s']").Select(x => Convert.ToInt32(x.InnerText));

            return new EuroMillionsResult(date, 0, balls.ToList(), bonusBalls.ToList());
        }
    }
}