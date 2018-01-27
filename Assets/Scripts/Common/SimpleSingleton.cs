namespace ggj2018
{
    public class SimpleSingleton <T>
        where T : SimpleSingleton<T>, new()
    {
        private  static T _Instance;

        public static T Instance
        { 
            get {
                if (_Instance == null) {
                    Init();
                }
                return _Instance;
            }
        }

        public static void Init()
        {
            _Instance = new T();
        }

        public static void Kill()
        {
            _Instance = null;          
        }
    }
}