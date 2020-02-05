using email_wrapper.Contracts;
using NSubstitute;
using System;
using System.Net.Http;
using Xunit;

namespace email_wrapper.tests
{
    public class TestsBase: IDisposable
    {
        public IHttpClientFactory _mockHttpClientFactory;
        public IEmailHelperRepository _mockEmailHelperRepository;
        public HttpClient _mockHttpClient;
        protected TestsBase()
        {
            _mockHttpClientFactory = Substitute.For<IHttpClientFactory>();
            _mockEmailHelperRepository = Substitute.For<IEmailHelperRepository>();
            _mockHttpClient = Substitute.For<HttpClient>();
            Console.WriteLine();
        }

        public void Dispose()
        {
            // Dispose resources here
            // Since we are only mocking interfaces, there's nothing to dispose
            Console.WriteLine("Disposing resources");
        }
    }
}
