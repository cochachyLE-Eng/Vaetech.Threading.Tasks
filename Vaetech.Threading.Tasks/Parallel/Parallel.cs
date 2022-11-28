using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Threading.Tasks
{    
    public partial class Parallel
    {        
        #region Invoke - Simple Actions
        public static void Invoke(params Action[] actions) => Invoke(ProcessType.Default, actions);
        public static void Invoke(ProcessType typeProcess, params Action[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Action action in actions)
                            Task.Run(() => Invoke(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Action action in actions)
                            tasks.Add(Task.Factory.StartNew(action));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static ActionResult Invoke(Action action) => Invoke<Exception>(action, out Exception exception);
        public static ActionResult Invoke<TException>(Action action, out TException exception) where TException : Exception
        {
            try
            {
                action();
                return new ActionResult(false, (exception = null)?.Message);
            }
            catch (TException ex)
            {
                return new ActionResult(true, (exception = ex).Message);
            }
        }
        #endregion

        #region InvokeAsync - Func<Task>[]
        public static async Task InvokeAsync(params Func<Task>[] actions) => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<Task>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<Task> action in actions)
                            await InvokeAsync(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<Task> action in actions)
                            tasks.Add(InvokeAsync(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        private static async Task<ActionResult> InvokeAsync(Func<Task> action) => await InvokeAsync<Exception>(action);
        private static async Task<ActionResult> InvokeAsync<TException>(Func<Task> action)
            where TException : Exception
        {
            try
            {
                await action();
                return new ActionResult(false, "successful process!");
            }
            catch (TException ex)
            {
                return new ActionResult(true, ex.Message);
            }
        }
        #endregion                

        #region InvokeAsync - Func<TaskLocal, Task>[]
        public static async Task InvokeAsync(params Func<TaskLocal, Task>[] actions)
            => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<TaskLocal,Task>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<TaskLocal, Task> action in actions)
                           await action(new TaskLocal());
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<TaskLocal, Task> action in actions)
                            tasks.Add(action(new TaskLocal()));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        public class TaskLocal
        {
            #region RunAsync - Func<Task<ActionResult<T,...T7>>>
            public async Task RunAsync<T>(Func<Task<ActionResult<T>>> action, Action<ActionResult<T>> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<ActionResult<T>>> action, Action<ActionResult<T>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T>(default(T), true, ex.Message));
                }
            }
            public async Task RunAsync<T1, T2>(Func<Task<ActionResult<T1, T2>>> action, Action<ActionResult<T1, T2>> result)
                => await RunAsync<T1, T2, Exception>(action, result);
            public async Task RunAsync<T1, T2, TException>(Func<Task<ActionResult<T1, T2>>> action, Action<ActionResult<T1, T2>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message)));
                }
            }
            public async Task RunAsync<T1, T2, T3>(Func<Task<ActionResult<T1, T2, T3>>> action, Action<ActionResult<T1, T2, T3>> result)
                => await RunAsync<T1, T2, T3, Exception>(action, result);
            public async Task RunAsync<T1, T2, T3, TException>(Func<Task<ActionResult<T1, T2, T3>>> action, Action<ActionResult<T1, T2, T3>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2, T3>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message), new ActionResult<T3>(true, ex.Message)));
                }
            }
            public async Task RunAsync<T1, T2, T3, T4>(Func<Task<ActionResult<T1, T2, T3, T4>>> action, Action<ActionResult<T1, T2, T3, T4>> result)
                => await RunAsync<T1, T2, T3, T4, Exception>(action, result);
            public async Task RunAsync<T1, T2, T3, T4, TException>(Func<Task<ActionResult<T1, T2, T3, T4>>> action, Action<ActionResult<T1, T2, T3, T4>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2, T3, T4>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message), new ActionResult<T3>(true, ex.Message), new ActionResult<T4>(true, ex.Message)));
                }
            }
            public async Task RunAsync<T1, T2, T3, T4, T5>(Func<Task<ActionResult<T1, T2, T3, T4, T5>>> action, Action<ActionResult<T1, T2, T3, T4, T5>> result)
                => await RunAsync<T1, T2, T3, T4, T5, Exception>(action, result);
            public async Task RunAsync<T1, T2, T3, T4, T5, TException>(Func<Task<ActionResult<T1, T2, T3, T4, T5>>> action, Action<ActionResult<T1, T2, T3, T4, T5>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2, T3, T4, T5>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message), new ActionResult<T3>(true, ex.Message), new ActionResult<T4>(true, ex.Message), new ActionResult<T5>(true, ex.Message)));
                }
            }
            public async Task RunAsync<T1, T2, T3, T4, T5, T6>(Func<Task<ActionResult<T1, T2, T3, T4, T5, T6>>> action, Action<ActionResult<T1, T2, T3, T4, T5, T6>> result)
                => await RunAsync<T1, T2, T3, T4, T5, T6, Exception>(action, result);
            public async Task RunAsync<T1, T2, T3, T4, T5, T6, TException>(Func<Task<ActionResult<T1, T2, T3, T4, T5, T6>>> action, Action<ActionResult<T1, T2, T3, T4, T5, T6>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2, T3, T4, T5, T6>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message), new ActionResult<T3>(true, ex.Message), new ActionResult<T4>(true, ex.Message), new ActionResult<T5>(true, ex.Message), new ActionResult<T6>(true, ex.Message)));
                }
            }
            public async Task RunAsync<T1, T2, T3, T4, T5, T6, T7>(Func<Task<ActionResult<T1, T2, T3, T4, T5, T6, T7>>> action, Action<ActionResult<T1, T2, T3, T4, T5, T6, T7>> result)
                => await RunAsync<T1, T2, T3, T4, T5, T6, T7, Exception>(action, result);
            public async Task RunAsync<T1, T2, T3, T4, T5, T6, T7, TException>(Func<Task<ActionResult<T1, T2, T3, T4, T5, T6, T7>>> action, Action<ActionResult<T1, T2, T3, T4, T5, T6, T7>> result)
                where TException : Exception
            {
                try
                {
                    result(await action());
                }
                catch (TException ex)
                {
                    result(new ActionResult<T1, T2, T3, T4, T5, T6, T7>(new ActionResult<T1>(true, ex.Message), new ActionResult<T2>(true, ex.Message), new ActionResult<T3>(true, ex.Message), new ActionResult<T4>(true, ex.Message), new ActionResult<T5>(true, ex.Message), new ActionResult<T6>(true, ex.Message), new ActionResult<T7>(true, ex.Message)));
                }
            }
            #endregion

            #region RunAsync - Func<Task<T>>
            public async Task RunAsync<T>(Func<Task<T>> action, Action<ActionResult> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<T>> action, Action<ActionResult> result)
                where TException : Exception
            {
                try
                {
                    T value = await action();
                    result(new ActionResult(data: value));
                }
                catch (TException ex)
                {
                    result(new ActionResult(true, ex.Message));
                }
            }
            #endregion

            #region RunAsync - Func<Task<T>>
            public async Task RunAsync<T>(Func<Task<T>> action, Action<ActionResult<T>> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<T>> action, Action<ActionResult<T>> result)
                where TException : Exception
            {
                try
                {
                    T value = await action();
                    result(new ActionResult<T>(value));
                }
                catch (TException ex)
                {
                    result(new ActionResult<T>(true, ex.Message));
                }
            }
            #endregion

            #region RunAsync - Func<Task<IEnumerable<T>>>
            public async Task RunAsync<T>(Func<Task<IEnumerable<T>>> action, Action<ActionResult<T>> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<IEnumerable<T>>> action, Action<ActionResult<T>> result)
                where TException : Exception
            {
                try
                {
                    IEnumerable<T> value = await action();
                    result(new ActionResult<T>(value));
                }
                catch (TException ex)
                {
                    result(new ActionResult<T>(true, ex.Message));
                }
            }
            #endregion

            #region RunAsync - Func<Task<IList<T>>>
            public async Task RunAsync<T>(Func<Task<IList<T>>> action, Action<ActionResult<T>> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<IList<T>>> action, Action<ActionResult<T>> result)
                where TException : Exception
            {
                try
                {
                    IList<T> value = await action();
                    result(new ActionResult<T>(value));
                }
                catch (TException ex)
                {
                    result(new ActionResult<T>(true, ex.Message));
                }
            }
            #endregion

            #region RunAsync - Func<Task<ICollection<T>>>
            public async Task RunAsync<T>(Func<Task<ICollection<T>>> action, Action<ActionResult<T>> result)
                => await RunAsync<T, Exception>(action, result);
            public async Task RunAsync<T, TException>(Func<Task<ICollection<T>>> action, Action<ActionResult<T>> result)
                where TException : Exception
            {
                try
                {
                    ICollection<T> value = await action();
                    result(new ActionResult<T>(value));
                }
                catch (TException ex)
                {
                    result(new ActionResult<T>(true, ex.Message));
                }
            }
            #endregion            
        }
    }
}