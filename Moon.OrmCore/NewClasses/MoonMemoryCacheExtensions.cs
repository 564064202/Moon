using System;
using System.Runtime.Caching;

namespace Moon.Orm
{
    public static class MoonMemoryCacheExtensions
    {

        public static object Insert(this MemoryCache cache, string key, object value, object nullObj, DateTime expire, TimeSpan zero)
        {
           return MemoryCache.Default.AddOrGetExisting(key, value, new DateTimeOffset(expire));
        }
    }

}
