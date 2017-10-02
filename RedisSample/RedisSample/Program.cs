using System;
using System.Diagnostics;


namespace RedisSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = @"C:\Program Files\Redis\redis-server.exe";
            process.StartInfo = startInfo;

            Console.WriteLine("Starting redis");
            process.Start();

            var redisHelper = new RedisHelper();

            Console.WriteLine("Saving data in cache");
            redisHelper.SaveStringData();

            Console.WriteLine("Reading data from cache");
            redisHelper.ReadStringData();

            Console.ReadLine();

            Console.WriteLine("Delete data from cache");
            redisHelper.ClearData();

            Console.ReadLine();
        }
    }
}
