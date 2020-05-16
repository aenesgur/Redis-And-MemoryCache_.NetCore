using System;
using System.Collections.Generic;
using System.Text;

namespace CacheSample.Cache.Abstract
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Add<T>(string key, T value, TimeSpan timeout) where T : class;
        bool IsSet(string key);
        bool Remove(string key);

    }
}
