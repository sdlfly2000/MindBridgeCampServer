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
        private string ServerName;
        private string PipeName;

        public CacheAgent(
            IPipeCacheClient pipeCacheClient, 
            IConfiguration config)
        {
            _pipeCacheClient = pipeCacheClient;
            ServerName = config["PipeClientSettings:PipeServer"];
            PipeName = config["PipeClientSettings:PipeName"];
        }

        public TEntity Get<TEntity>(string key) where TEntity : class
        {
            SetupPipeClient();
            return _pipeCacheClient.Get<TEntity>(key);
        }

        #region Private Methods

        private void SetupPipeClient()
        {
            _pipeCacheClient.SetupPipeClient(
                new NamedPipeClientStream(ServerName, PipeName, PipeDirection.InOut));
        }

        #endregion
    }
}
