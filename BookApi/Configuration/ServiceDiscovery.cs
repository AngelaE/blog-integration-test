using System;

namespace BookApi.Configuration
{
  public class ServiceDiscovery : IServiceDiscovery
  {
    public Uri GetServiceUri(string name)
    {
      return new Uri($"http://{name}");
    }
  }
}
