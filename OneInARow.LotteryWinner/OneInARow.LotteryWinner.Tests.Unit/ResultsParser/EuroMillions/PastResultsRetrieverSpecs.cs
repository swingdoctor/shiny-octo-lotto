using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInARow.LotteryWinner.Tests.Unit.ResultsParser.EuroMillions
{
    using Machine.Specifications;

    using OneInARow.LotteryWinner.ResultsParser.EuroMillions;

    [Subject("Euromillions results retriever")]
    public class PastResultsRetrieverSpecs
    {
        protected static PastResultsRetriever ResultsRetriever;

        protected static IEnumerable<string> Pages;
        
        Establish context = () =>
            { ResultsRetriever = new PastResultsRetriever(); };

        Because of = () => Pages = ResultsRetriever.GetResultPages();

        It should_return_a_list = () => Pages.ShouldNotBeEmpty();
    }
}
