using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton obj = Singleton.Instance;

        }
    }

    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {
            Console.WriteLine("I am in Singleton design pattern");
            Console.ReadLine();
        }

        public static Singleton Instance
        {
            get
            {

                // Thread safe version
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
    public sealed class NetSingleton
    {
        private static readonly Lazy<NetSingleton> lazy =
            new Lazy<NetSingleton>(() => new NetSingleton());

        public static NetSingleton Instance { get { return lazy.Value; } }

        private NetSingleton()
        {
        }
    }
}
