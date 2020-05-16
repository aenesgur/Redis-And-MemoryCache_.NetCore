using CacheSample.Business;
using CacheSample.Cache.Abstract;
using CacheSample.Cache.Concrete;
using CacheSample.Entities;
using CacheSample.Entities.Enums;
using System;
using System.Collections.Generic;

namespace CacheSample.Console
{
    class Program
    {
        public static Book GetDummyData()
        {
            return new Book() { Id = 45132, Name = "The Alchemist", CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") };
        }

        static void Main(string[] args)
        {
            var cacheType = CreateCacheService(CacheTypes.Redis.ToString());
            var business = new CacheBusiness(cacheType);

            var key_Id = "45132";
            string key = $"book.data.{key_Id}";

            for (int i = 0; i < 3; i++)
            {
                var model = business.Get<Book>(key, (int)CacheKeys.Default_Cache, () =>
                {
                    return GetDummyData();
                });

                System.Console.WriteLine($"{key}--{model.Name}--{model.CurrentTime}");
                System.Console.ReadKey();
            }

            var isRemoved = business.Remove<Book>(key);

            var resultMessage = isRemoved ? "Succesfully deleted" : "Deletion not successful";
            System.Console.WriteLine($"{resultMessage}");
            System.Console.ReadKey();
        }
        public static ICacheManager CreateCacheService(string cacheService)
        {
            switch (cacheService)
            {
                case "Redis":
                    return new RedisCacheService();
                case "Memory":
                    return new MemoryCacheService();
                default:
                    throw new Exception("There is no defined cache service");
            }
        }
    }
}
