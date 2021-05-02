using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace ProxyCacheJC
{
    class ProxyCache<T> where T : class, new()
    {
        ObjectCache cache = MemoryCache.Default;

        public T Get(string CacheItem)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
            {
                Console.WriteLine("Passe par le cache");
                return obj;
            }
            //do request and get 
            Views views = new Views();
            string[] strings = CacheItem.Split('_');
            string stationNum = strings[0];
            string contractName = strings[1];
            T myobj = (T)Activator.CreateInstance(typeof(T), views.getInfos(stationNum, contractName));
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
            };
            cache.Add(CacheItem, myobj, cacheItemPolicy);
            return myobj;
        }
        public T Get(string CacheItem, double dt_seconds)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
            {
                Console.WriteLine("Passe par le cache");
                return obj;
            }
            //do request and get 
            Views s = new Views();
            string[] strings = CacheItem.Split('_');
            string stationNum = strings[0];
            string contractName = strings[1];
            T myobj = (T)Activator.CreateInstance(typeof(T), s.getInfos(stationNum, contractName));
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds),
            };
            cache.Add(CacheItem, myobj, cacheItemPolicy);
            return myobj;
        }
        public T Get(string CacheItem, DateTimeOffset dt)
        {
            T obj = (T)cache.Get(CacheItem);
            if (obj != null)
            {
                Console.WriteLine("Passe par le cache");
                return obj;
            }
            //do request and get
            Views s = new Views();
            string[] strings = CacheItem.Split('_');
            string stationNum = strings[0];
            string contractName = strings[1];
            JCDecauxItem j = new JCDecauxItem();
            j.response = s.getInfos(stationNum, contractName);
            T myobj = (T)Activator.CreateInstance(typeof(T), s.getInfos(stationNum, contractName));
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = dt,
            };
            cache.Add(CacheItem, myobj, cacheItemPolicy);
            return myobj;
        }

        public ObjectCache getCache()
        {
            return cache;
        }
    }
}
