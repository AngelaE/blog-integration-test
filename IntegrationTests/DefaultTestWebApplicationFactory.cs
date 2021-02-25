using IntegrationTests.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace IntegrationTests
{
  public class DefaultTestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
  {
    public ITestOutputHelper TestOutputHelper { get; set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      // Register the xUnit logger
      builder.ConfigureLogging(loggingBuilder =>
      {
        loggingBuilder.AddProvider(new XUnitLoggerProvider(TestOutputHelper));
      });
    }
  }
}
