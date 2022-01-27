using ContractTestingDemo.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ContractTestingDemo.Mock
{
    internal class ApiClient
    {
        private readonly HttpClient _client;
        public ApiClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:35965/") };
        }

        public EmployeeModel GetEmployeeDetails(int id)
        {

            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/employee/{id}");
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var status = response.StatusCode;

            reasonPhrase = response.ReasonPhrase;
            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !string.IsNullOrEmpty(content) ? JsonConvert.DeserializeObject<EmployeeModel>(content) : null;
            }

            throw new Exception(reasonPhrase);

        }
    }
}
