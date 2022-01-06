using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult;
using Vaetech.Data.ContentResult.Events;

namespace Vaetech.Threading.Tasks
{
    public enum ProcessType
    {
        Default = 0,
        /// <summary>
        /// Run everything at the same time.
        /// </summary>
        RunAll = 0,
        /// <summary>
        /// Run in order of entry.
        /// </summary>
        RunInOrder
    }    
    public class Parallel
    {
        #region RunAsync - Actions
        public static async Task RunAsync<T>(Func<Task<T>> action, Action<ActionResult<T>> result)
            => await RunAsync<T, Exception>(action, result);
        public static async Task RunAsync<T, TException>(Func<Task<T>> action, Action<ActionResult<T>> result)
            where TException : Exception            
        {
            try
            {
                T value = await action();
                result(new ActionResult<T>(value));
            }
            catch (TException ex)
            {
                result(new ActionResult<T>(default(T), true, ex.Message));
            }
        }        
        
        public static async Task RunAsync<T>(Func<Task<ActionResult<T>>> action, Action<ActionResult<T>> result)
            => await RunAsync<T, Exception>(action, result);
        public static async Task RunAsync<T, TException>(Func<Task<ActionResult<T>>> action, Action<ActionResult<T>> result)
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
        #endregion

        #region RunAsync - Events
        public static async Task RunAsync<T>(Func<Task<T>> action, DynamicEventHandler<ActionResult<T>> result)
            => await RunAsync<T, Exception>(action, result);
        public static async Task RunAsync<T, TException>(Func<Task<T>> action, DynamicEventHandler<ActionResult<T>> result)
            where TException : Exception
        {
            try
            {
                T value = await action();
                result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(default(T), true, ex.Message)));
            }
        }

        public static async Task RunAsync<T>(Func<Task<ActionResult<T>>> action, DynamicEventHandler<ActionResult<T>> result)
            => await RunAsync<T, Exception>(action, result);
        public static async Task RunAsync<T, TException>(Func<Task<ActionResult<T>>> action, DynamicEventHandler<ActionResult<T>> result)
            where TException : Exception
        {
            try
            {
                result?.Invoke(null,new DynamicEventArgs<ActionResult<T>>(await action()));
            }
            catch (TException ex)
            {
                result?.Invoke(null,new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(default(T), true, ex.Message)));
            }
        }
        #endregion

        #region RunAsync - Tuple Actions
        private static void Run<T>(Func<(T action, Action<ActionResult<T>> result)> action)
            => Run<T,Exception>(action);
        private static void Run<T,TException>(Func<(T action, Action<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(true, ex.Message));
            }
        }
        private static void Run<T>(Func<(ActionResult<T> action, Action<ActionResult<T>> result)> action) => Run<T, Exception>(action);
        private static void Run<T,TException>(Func<(ActionResult<T> action, Action<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(invoke.action);
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(true, ex.Message));
            }
        }
        private static async Task RunAsync<T>(Func<(Task<T> action, Action<ActionResult<T>> result)> action) => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T,TException>(Func<(Task<T> action, Action<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(await invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(true,ex.Message));
            }
        }
        private static async Task RunAsync<T>(Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)> action) => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T, TException>(Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(await invoke.action);
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T>(true, ex.Message));
            }
        }
        private static async Task RunAsync(Func<(Task action, Action<ActionResult> result)> action) => await RunAsync<Exception>(action);
        private static async Task RunAsync<TException>(Func<(Task action, Action<ActionResult> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action.Invoke(); await invoke.action;
                invoke.result(new ActionResult(invoke.action.AsyncState));
            }
            catch (TException ex)
            {
                action.Invoke().result(new ActionResult<Delegate>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Tuple Events
        private static void Run<T>(Func<(T action, DynamicEventHandler<ActionResult<T>> result)> action)
            => Run<T, Exception>(action);
        private static void Run<T, TException>(Func<(T action, DynamicEventHandler<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(invoke.action)));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(true, ex.Message)));
            }
        }
        private static void Run<T>(Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)> action) => Run<T, Exception>(action);
        private static void Run<T, TException>(Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result?.Invoke(null,new DynamicEventArgs<ActionResult<T>>(invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result?.Invoke(null,new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(true, ex.Message)));
            }
        }
        private static async Task RunAsync<T>(Func<(Task<T> action, DynamicEventHandler<ActionResult<T>> result)> action) => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T, TException>(Func<(Task<T> action, DynamicEventHandler<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result?.Invoke(null,new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(await invoke.action)));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(true, ex.Message)));
            }
        }
        private static async Task RunAsync<T>(Func<(Task<ActionResult<T>> action, DynamicEventHandler<ActionResult<T>> result)> action) => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T, TException>(Func<(Task<ActionResult<T>> action, DynamicEventHandler<ActionResult<T>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(await invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(true, ex.Message)));
            }
        }
        private static async Task RunAsync(Func<(Task action, DynamicEventHandler<ActionResult> result)> action) => await RunAsync<Exception>(action);
        private static async Task RunAsync<TException>(Func<(Task action, DynamicEventHandler<ActionResult> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action.Invoke(); await invoke.action;
                invoke.result?.Invoke(null, new DynamicEventArgs<ActionResult>(new ActionResult(invoke.action.AsyncState)));
            }
            catch (TException ex)
            {
                action.Invoke().result.Invoke(null,new DynamicEventArgs<ActionResult>(new ActionResult<Delegate>(true, ex.Message)));
            }
        }
        #endregion

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

        #region Invoke - Tuple Actions
        public static void Invoke<T>(params Func<(T action,Action<ActionResult<T>> result)>[] actions) => Invoke<T>(ProcessType.Default,actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(T action,Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(T action, Action<ActionResult<T>> result)> action in actions)                        
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(T action,Action<ActionResult<T>> result)> action in actions)                        
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));
                                                
                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        
        public static void Invoke<T>(params Func<(ActionResult<T> action, Action<ActionResult<T>> result)>[] actions) => Invoke<T>(ProcessType.Default, actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(ActionResult<T> action, Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(ActionResult<T> action, Action<ActionResult<T>> result)> action in actions)
                            Task.Run(() => Run<T>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(ActionResult<T> action,Action<ActionResult<T>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run<T>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Events
        public static void Invoke<T>(params Func<(T action, DynamicEventHandler<ActionResult<T>> result)>[] actions) => Invoke<T>(ProcessType.Default, actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(T action, DynamicEventHandler<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(T action, DynamicEventHandler<ActionResult<T>> result)> action in actions)
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(T action, DynamicEventHandler<ActionResult<T>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }

        public static void Invoke<T>(params Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)>[] actions) => Invoke<T>(ProcessType.Default, actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)> action in actions)
                            Task.Run(() => Run<T>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(ActionResult<T> action, DynamicEventHandler<ActionResult<T>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run<T>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Func<T>
        public static ActionResult<T> Invoke<T>(Func<T> action) => Invoke<T, Exception>(action);
        public static ActionResult<T> Invoke<T, TException>(Func<T> action) where TException : Exception
        {
            try
            {
                T value = action();
                return new ActionResult<T>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        
        public static ActionResult<T> Invoke<T>(Func<ActionResult<T>> action) => Invoke<T, Exception>(action);
        public static ActionResult<T> Invoke<T, TException>(Func<ActionResult<T>> action) where TException : Exception
        {
            try
            {                
                return action();
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        #endregion

        #region InvokeAsync - Func<Task>
        public static async Task InvokeAsync(params Func<Task>[] actions) => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<Task>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<Task> action in actions)
                            await InvokeAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<Task> action in actions)
                            tasks.Add(InvokeAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task<ActionResult> InvokeAsync(Func<Task> action) => await InvokeAsync<Exception>(action);
        public static async Task<ActionResult> InvokeAsync<TException>(Func<Task> action)
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

        #region InvokeAsync - Func<Task>
        public static async Task InvokeAsync(params Func<(Task action, Action<ActionResult> result)>[] actions)            
            => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<(Task action, Action<ActionResult> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task action, Action<ActionResult> result)> action in actions)
                            await RunAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task action, Action<ActionResult> result)> action in actions)
                            tasks.Add(RunAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeAsync<T>(params Func<(Task<T> action, Action<ActionResult<T>> result)>[] actions) 
            => await InvokeAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeAsync<T>(ProcessType typeProcess, params Func<(Task<T> action, Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<T> action,Action<ActionResult<T>> result)> action in actions)
                            await RunAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<T> action, Action<ActionResult<T>> result)> action in actions)
                            tasks.Add(RunAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeAsync<T>(params Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)>[] actions)
            => await InvokeAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeAsync<T>(ProcessType typeProcess, params Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<ActionResult<T>> action,Action<ActionResult<T>> result)> action in actions)
                            await RunAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<ActionResult<T>> action,Action<ActionResult<T>> result)> action in actions)
                            tasks.Add(RunAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion


        #region InvokeAsync - Tuple Actions
        public static async Task<ActionResult<T>> InvokeAsync<T>(Func<Task<T>> action)
            => await InvokeAsync<T, Exception>(action);
        public static async Task<ActionResult<T>> InvokeAsync<T, TException>(Func<Task<T>> action) where TException : Exception
        {
            try
            {
                T value = await action();
                return new ActionResult<T>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        public static async Task<ActionResult<T>> InvokeAsync<T>(Func<Task<ActionResult<T>>> action)
            => await InvokeAsync<T, Exception>(action);
        public static async Task<ActionResult<T>> InvokeAsync<T, TException>(Func<Task<ActionResult<T>>> action) where TException : Exception
        {
            try
            {                
                return await action();
            }
            catch (TException ex)
            {
                return new ActionResult<T>(default(T), true, ex.Message);
            }
        }
        #endregion
    }    
}
