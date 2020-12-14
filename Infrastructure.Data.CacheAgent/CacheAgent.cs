using System.IO.Pipes;
using Common.Core.Cache.PipeCache;
using Common.Core.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.CacheAgent
{
    [ServiceLocate(typeof(ICacheAgent<>))]
    public class CacheAgent<TEntity> : ICacheAgent<TEntity> where TEntity: class
    {
        private readonly IPipeCacheClient _pipeCacheClient;

        public CacheAgent(
            IPipeCacheClient pipeCacheClient, 
            IConfiguration config)
        {
            _pipeCacheClient = pipeCacheClient;
           
            _pipeCacheClient.SetupPipeClient(
                new NamedPipeClientStream(
                config["PipeClientSettings:PipeServer"], 
                config["PipeClientSettings:PipeName"], 
                PipeDirection.InOut));
        }

        public TEntity Get<TEntity>(string key) where TEntity : class
        {
            return _pipeCacheClient.Get<TEntity>(key);
        }
    }
}
