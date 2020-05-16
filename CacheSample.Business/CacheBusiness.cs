using CacheSample.Cache.Abstract;
using CacheSample.Cache.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheSample.Business
{
    public class CacheBusiness
    {
        private ICacheManager _cacheManager;
        public CacheBusiness(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public T Get<T>(string key, int cacheTime, Func<T> acquire) where T : class
        {
            if (_cacheManager.IsSet(key))
            {
                return _cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (result != null)
                    _cacheManager.Add<T>(key, result, TimeSpan.FromSeconds(cacheTime));
                return result;
            }
        }

        public bool Remove<T>(string key)
        {
            return _cacheManager.Remove(key);
        }
    }
}
