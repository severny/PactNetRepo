
namespace ContractTestingDemo.Test
{
    using System.Collections.Generic;
    using Helper;
    using PactNet;
    using PactNet.Infrastructure.Outputters;
    using Xunit;
    using Xunit.Abstractions;

    public class ProviderPactTest
    {
        private readonly ITestOutputHelper _output;

        public ProviderPactTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestProvider()
        {
            var config = new PactVerifierConfig()
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                },
                Verbose = true
            };

            new PactVerifier(config)
            .ServiceProvider("EmployeeList", "http://localhost:35965")
            .HonoursPactWith("Service_Consumer")
            .PactUri(@"C:\pactnet\pacts\service_consumer-employeelist.json")
            .Verify();
        }
    }
}
