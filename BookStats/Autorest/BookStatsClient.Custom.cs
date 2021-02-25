﻿using System;
using System.Net.Http;

namespace BookStats.Autorest
{
  public partial class BookStatsClient
  {
    // http://michaco.net/blog/IntegratingAutorestWithHttpClientFactoryAndDI
    // disposeHttpClient can be set to true, HttpClientFactory sets disposeHandler to false so that the HttpClient does not dispose the important HttpClientHandle...
    public BookStatsClient(Uri baseUri, HttpClient httpClient)
        : base(httpClient, disposeHttpClient: true)
    {
      BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
    }
  }
}
