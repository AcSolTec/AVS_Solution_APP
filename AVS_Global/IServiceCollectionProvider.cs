using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global
{
   public interface IServiceCollectionProvider
    {
        IServiceCollection ServiceCollection { get; set; }
    }

    public sealed class ServiceCollectionProvider : IServiceCollectionProvider
    {
        public ServiceCollectionProvider(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        public IServiceCollection ServiceCollection { get; set; }
    }
}
