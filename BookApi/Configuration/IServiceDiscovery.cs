using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Configuration
{
    public interface IServiceDiscovery
    {
        public Uri GetServiceUri(string name);
    }
}
