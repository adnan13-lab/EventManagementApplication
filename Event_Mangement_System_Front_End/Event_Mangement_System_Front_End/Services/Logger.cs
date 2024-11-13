namespace Event_Mangement_System_Front_End.Services
{
    public sealed class Logger
    {
        private static Logger? Instance = null;
        private static object _lock = new object();
        private Logger() { }

        public static Logger instance()
        {
            if(Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null)
                    {
                        Instance = new Logger();
                    }
                }
            }
            return Instance;
        }

        public void Log(string message) {
            Console.WriteLine($"Massage:{message}");

        }


    }
}
