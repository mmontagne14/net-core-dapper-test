using BlogPostApi.Repository;
using Microsoft.Extensions.Configuration;
using System;


namespace BlogPostApi.Code
{

    public class ServiceLocator
    {
        public IConfiguration Configuration { get; }

        public string sqlServerConnectionString = string.Empty;
        public ServiceLocator(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        internal static T Find<T>() where T : class
        {
            if (typeof(T) == typeof(IRepositoryBase))
                return new SqlServerRepository() as T;

            throw new TypeLoadException($"cannot find type {typeof(T).Name}");
        }
    }
}