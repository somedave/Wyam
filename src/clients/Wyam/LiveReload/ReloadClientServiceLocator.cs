using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

using Microsoft.Practices.ServiceLocation;

namespace Wyam.LiveReload
{
    internal class ReloadClientServiceLocator : IServiceLocator
    {
        readonly ConcurrentBag<ReloadClient> _clients = new ConcurrentBag<ReloadClient>();

        public IEnumerable<ReloadClient> ReloadClients => _clients.ToArray();

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            if (typeof(TService) == typeof(ReloadClient))
            {
                var client = CreateClient();
                return (TService) client;
            }

            throw new NotImplementedException();
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        private object CreateClient()
        {
            var client = new ReloadClient();
            _clients.Add(client);
            return client;
        }
    }
}