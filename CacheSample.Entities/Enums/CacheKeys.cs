using System;
using System.Collections.Generic;
using System.Text;

namespace CacheSample.Entities.Enums
{
    // Values stored as second
    public enum CacheKeys
    {
        Default_Cache = 180,

    }
    public enum CacheTypes
    {
        Redis,
        Memory
    }
}
