using DesignPatterns.Singleton;

namespace DesignPatterns.Singleton
{
    internal sealed class DatabaseSingleton
    {
        private static DatabaseSingleton instance;
        public string Value { get; set; }
        private static readonly object _lock = new object();
        private DatabaseSingleton()
        {

        }

        public static DatabaseSingleton GetInstance(string value)
        {
            if(instance is null) 
            {
                lock (_lock)
                {
                    if (instance is null)
                    {
                        instance = new DatabaseSingleton();
                        instance.Value = value;
                    }
                }

            }
            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });
            
            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            var singleton = DatabaseSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
        
    }
}
