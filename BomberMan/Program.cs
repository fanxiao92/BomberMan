namespace BomberMan
{
    using System;
    using Serilog;
    using Serilog.Core;

    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Logger = log;

            var world = new World.World();
            world.Init(1000);
            world.Tick(33);
            world.PostTick();
            Console.ReadLine();
        }
    }
}