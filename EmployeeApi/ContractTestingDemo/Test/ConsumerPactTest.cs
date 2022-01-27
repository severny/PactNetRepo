using ContractTestingDemo.Consumer;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContractTestingDemo.Test
{
    // consumer test
    public class ConsumerPactTest : IClassFixture<ConsumerPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPactTest(ConsumerPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions();
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

    }
}
