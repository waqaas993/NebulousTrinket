using UnityEngine;

namespace NebulousTrinket
{
    public static class SingletonController<T> where T : MonoBehaviour, IInstance
    {
        private static T _Instance;

        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = Object.FindObjectOfType<T>();

                    if (_Instance == null)
                    {
                        Debug.LogError($"Singleton of {typeof(T)} not found!");
                    }
                }
                return _Instance;
            }
        }
    }
}