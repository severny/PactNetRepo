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
    using Mock;
    using PactNet.Mocks.MockHttpService.Models;

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

        [Fact]
        public void GetEmployeeDetails_VerifyIfItReturns()
        {
            _mockProviderService
                .Given("Employee details for id '1'")
                .UponReceiving("A GET request to retrieve the employee details")
                .With(new ProviderServiceRequest()
                {
                    Method = HttpVerb.Get,
                    Path = "/employee/2",
                    Headers = new Dictionary<string, object>
                    {
                        {"Accept", "application/json"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, object>()
                        {
                            {"Content-type", "application/json; charset=utf-8"}
                        },
                        Body = new
                        {
                            id = 2,
                            name = "Mary Smith",
                            city = "Paris"
                        }
                    });

            var consumer = new ApiClient(_mockProviderServiceBaseUri);

            var result = consumer.GetEmployeeDetails(2);

            Assert.Equal("Mary Smith", result.Name);
            _mockProviderService.VerifyInteractions();
        }
    }
}
