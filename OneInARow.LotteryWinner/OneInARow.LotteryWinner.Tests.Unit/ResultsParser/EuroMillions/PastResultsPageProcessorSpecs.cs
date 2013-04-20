using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInARow.LotteryWinner.Tests.Unit.ResultsParser.EuroMillions
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;

    using Machine.Specifications;

    using OneInARow.LotteryWinner.Domain;
    using OneInARow.LotteryWinner.ResultsParser.EuroMillions;

    [Subject("EuroMillions Page Processor")]
    public class PastResultsPageProcessorSpecs
    {
        protected static string SampleHtmlFileRelativePath = @"ResultsParser\EuroMillions\html\sample.html";

        protected static string SampleHtml;

        protected static PastResultsPageProcessor PageProcessor;

        protected static List<EuroMillionsResult> Results;

        protected static Exception ex;

        Establish context = () =>
            {
                var path = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath)), SampleHtmlFileRelativePath);
                SampleHtml = File.ReadAllText(path);
                PageProcessor = new PastResultsPageProcessor();
            };

        Because of = () => ex = Catch.Exception(() => Results = PageProcessor.GetResults(SampleHtml));

        It should_not_fail = () => ex.ShouldBeNull();

        It should_have_multiple_results = () => Results.ShouldNotBeEmpty();
    }
}
