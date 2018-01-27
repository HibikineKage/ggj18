namespace GGJ2018A.Common
{
    public class SimpleSingleton <T>
        where T : SimpleSingleton<T>, new()
    {
        public static T Instance { get; private set; }

        public static void Init()
        {
            Instance = new T();
        }

        public static void Kill()
        {
            Instance = null;          
        }
    }
}