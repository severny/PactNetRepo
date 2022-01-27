using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTestingDemo.Consumer
{
    public class ConsumerPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }

        public IMockProviderService MockProviderService { get; set; }

        public const int MockServicePort = 9224;

        public string MockProviderServiceBaseUri => $"http://localhost:{MockServicePort}";

        public ConsumerPact()
        {
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "3.0.0",
                PactDir = @"c:\pactnet\pacts",
                LogDir = @"c:\pactnet\logs",
            };
            PactBuilder = new PactBuilder(pactConfig);
            PactBuilder
                .ServiceConsumer("Service_Consumer")
                .HasPactWith("EmploeeList");

            MockProviderService = PactBuilder.MockService(MockServicePort);
        }

        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}
