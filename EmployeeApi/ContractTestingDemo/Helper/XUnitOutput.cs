namespace ContractTestingDemo.Helper
{
    using PactNet.Infrastructure.Outputters;
    using Xunit.Abstractions;

    public class XUnitOutput : IOutput
    {
        private readonly ITestOutputHelper _output;

        public XUnitOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        void IOutput.WriteLine(string line)
        {
            _output.WriteLine(line);
        }
    }
}
