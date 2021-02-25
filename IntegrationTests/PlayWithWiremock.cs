using FluentAssertions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace IntegrationTests
{
  public class PlayWithWiremock
  {
    [Fact]
    public async Task Test()
    {
      var server = WireMockServer.Start();

      server.Given(
          Request.Create().WithPath("/ping").UsingGet()
      )
      .RespondWith(
          Response.Create()
              .WithStatusCode(200)
              .WithBody("pong"));

      server.Given(
          Request.Create().WithPath("/xxx").UsingGet())
      .RespondWith(
          Response.Create()
              .WithStatusCode(500)
              .WithDelay(TimeSpan.FromSeconds(200)));

      var client = new HttpClient();
      var port = server.Ports[0];
      client.BaseAddress = new Uri($"http://localhost:{port}");
      var response = await client.GetAsync("/ping");

      response.StatusCode.Should().Be(200);
      var body = await response.Content.ReadAsStringAsync();
      body.Should().BeEquivalentTo("pong");

      response = await client.GetAsync("xxx");
      response.StatusCode.Should().Be(500);

      server.Stop();
    }
  }
}
