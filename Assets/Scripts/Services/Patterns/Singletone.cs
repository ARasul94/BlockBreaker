using UnityEngine;

namespace Services.Patterns
{
    /// <summary>
    /// Реализация паттерна синглтон. Используется только для имплементации сервислокатора
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singletone<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance { get; set; } = null;

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
