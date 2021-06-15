using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    using Common.Core.AOP;

    public static class RegisterCache
    {
        public static void Register(IServiceCollection services, IList<string> domains)
        {
            var asms = domains.Select(domain => Assembly.Load(domain)).ToList();

            var implements = asms
                .SelectMany(asm => asm.GetTypes())
                .Where(type => !type.IsInterface)
                .Where(type => type.GetCustomAttributes(typeof(AspectCacheAttribute)).Any())
                .Distinct().ToList();

            var methods = implements
                .Where(implement => implement.GetCustomAttributes(typeof(AspectCacheAttribute)).Any())
                .SelectMany(implement => implement.GetMethods()).ToList();

            var proxy = new CacheProxy();

        }
    }
}