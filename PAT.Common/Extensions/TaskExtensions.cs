namespace PAT.Common.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static async Task<Result> Map<T, Result>(this Task<T> task, Func<T, Result> function)
            => function(await task);

        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static async Task<Result> Map<T, Result>(this Task<T> task, Func<T, Result> function, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            return function(await task);
        }

        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static async Task<Result> FlatMap<T, Result>(this Task<T> task, Func<T, Task<Result>> function)
            => await function(await task);

        /// <summary>
        /// Maps a value to a function
        /// </summary>
        public static async Task ForEach<T>(this Task<T> task, Action<T> fn)
            => fn(await task);


        /// <summary>
        /// Executes a function, returns the value
        /// </summary>
        public static async Task<T> Execute<T, T1>(this Task<T> returnValue, T1 arg1, Action<T, T1> action)
        {
            var result = await returnValue;
            action.Invoke(result, arg1);
            return result;
        }
    }
}
