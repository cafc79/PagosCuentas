namespace PAT.Common.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static async Task<TResult> MapV<T, TResult>(this T value, Func<T, Task<TResult>> fn)
            => await fn(value);

        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static TResult MapV<T, TResult>(this T value, Func<T, TResult> fn)
            => fn(value);

        /// <summary>
        /// Executes a function, returns the value
        /// </summary>
        public static T Execute<T>(this T returnValue, Action action)
        {
            action.Invoke();
            return returnValue;
        }

        /// <summary>
        /// Executes a function, returns the value
        /// </summary>
        public static T Execute<T>(this T returnValue, Action<T> action)
        {
            action.Invoke(returnValue);
            return returnValue;
        }

        /// <summary>
        /// Executes a function, returns the value
        /// </summary>
        public static T Execute<T, T1>(this T returnValue, T1 arg1, Action<T, T1> action)
        {
            action.Invoke(returnValue, arg1);
            return returnValue;
        }
    }
}
