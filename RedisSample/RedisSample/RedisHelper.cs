using StackExchange.Redis;
using System;

namespace RedisSample
{
    public class RedisHelper
    {
        static RedisHelper()
        {
            RedisHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        private int Count = 100;

        public void SaveStringData()
        {
            var cache = Connection.GetDatabase();

            var rnd = new Random();
            for (int i = 1; i <= Count; i++)
            {
                var value = rnd.Next(0, Count);
                cache.StringSet($"KEY_{i}", value);
            }
        }

        public void ReadStringData()
        {
            var cache = Connection.GetDatabase();

            for (int i = 1; i <= Count; i++)
            {
                var value = cache.StringGet($"KEY_{i}");
                Console.WriteLine($"Value={value}");
            }
        }

        public void ClearData()
        {
            var cache = Connection.GetDatabase();

            cache.Execute("flushdb");
        }
    }
}
