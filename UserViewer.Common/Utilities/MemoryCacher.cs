using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using UserViewer.Common.Model;

namespace UserViewer.Common.Utilities
{
  public class MemoryCacher<T> where T : User
  {
    private ObjectCache cache;
    private readonly TimeSpan cacheDuration;

    public MemoryCacher(TimeSpan cacheDuration)
    {
      cache = MemoryCache.Default;      
      this.cacheDuration = cacheDuration;
    }

    public bool Add(string key, IEnumerable<T> value)
    {
      CacheItemPolicy policy = new CacheItemPolicy();
      policy.AbsoluteExpiration = DateTimeOffset.Now.Add(cacheDuration);
      return cache.Add(key, value, policy);
    }

    public object Remove(string key)
    {
      if (cache.Contains(key))
      {
        return cache.Remove(key);
      }
      return null;
    }

    public IEnumerable<T> Get(string key)
    {
      return cache.Get(key) as IEnumerable<T>;
    }

  }
}
