using CacheSample.Cache.Abstract;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheSample.Cache.Concrete
{
    public class RedisCacheService : IRedisCacheManager
    {
        public void Add<T>(string key, T value, TimeSpan timeout) where T : class
        {
            using (IRedisClient client = new RedisClient())
            {
                client.Set(key, value, timeout);
            }
        }

        public T Get<T>(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.Get<T>(key);
            }
        }

        public bool IsSet(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.ContainsKey(key);
            }
        }

        public bool Remove(string key)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.Remove(key);
            }
        }
    }
}
