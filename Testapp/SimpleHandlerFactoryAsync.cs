using Paramore.Brighter;
using System;
using TestAppService.Handlers;

namespace Testapp
{
    internal class SimpleHandlerFactoryAsync : IAmAHandlerFactoryAsync
    {

        private readonly IServiceProvider _serviceProvider;

        public SimpleHandlerFactoryAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Release(IHandleRequestsAsync handler)
        {
        }

        IHandleRequestsAsync IAmAHandlerFactoryAsync.Create(Type handlerType)
        {
            return (IHandleRequestsAsync)_serviceProvider.GetService(handlerType);
        }


    }
}