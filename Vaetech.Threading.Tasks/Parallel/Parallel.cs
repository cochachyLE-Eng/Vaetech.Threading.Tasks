using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult;
using Vaetech.Data.ContentResult.Events;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Threading.Tasks
{    
    public partial class Parallel
    {
        #region Run - Tuple Actions (IEnumerable<T>)
        private static void Run<T>(Func<(IEnumerable<T> action, Action<ActionResult<T>> result)> action)
            => Run<T,Exception>(action);
        private static void Run<T,TException>(Func<(IEnumerable<T> action, Action<ActionResult<T>> result)> action)
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
        #endregion

        #region Run - Tuple Actions (string)
        private static void Run(Func<(String action, Action<ActionResult<String>> result)> action)
            => Run<Exception>(action);
        private static void Run<TException>(Func<(String action, Action<ActionResult<String>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<String>(invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<String>(true, ex.Message));
            }
        }
        private static void Run(Func<(String[] action, Action<ActionResult<String[]>> result)> action)
            => Run<Exception>(action);
        private static void Run<TException>(Func<(String[] action, Action<ActionResult<String[]>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<String[]>(invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<String[]>(true, ex.Message));
            }
        }
        #endregion

        #region Run - Tuple Actions (struct)
        private static void Run<T>(Func<(T action, Action<ActionResult<T>> result)> action) where T: struct
            => Run<T,Exception>(action);
        private static void Run<T,TException>(Func<(T action, Action<ActionResult<T>> result)> action) where T : struct
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
        private static void Run<T>(Func<(T[] action, Action<ActionResult<T[]>> result)> action) where T : struct
            => Run<T, Exception>(action);
        private static void Run<T, TException>(Func<(T[] action, Action<ActionResult<T[]>> result)> action) where T : struct
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<T[]>(invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T[]>(true, ex.Message));
            }
        }
        #endregion

        #region Run - Tuple Actions
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
        #endregion
        
        #region RunAsync - Actions (IEnumerable<T>)
        public static async Task RunAsync<T>(Func<Task<IEnumerable<T>>> action, Action<ActionResult<T>> result)       
            => await RunAsync<T,Exception>(action, result);
        public static async Task RunAsync<T,TException>(Func<Task<IEnumerable<T>>> action, Action<ActionResult<T>> result)            
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

        #region RunAsync - Actions (string)
        public static async Task RunAsync(Func<Task<String>> action, Action<ActionResult<String>> result)
            => await RunAsync<Exception>(action, result);
        public static async Task RunAsync<TException>(Func<Task<String>> action, Action<ActionResult<String>> result)
            where TException : Exception
        {
            try
            {
                String value = await action();
                result(new ActionResult<String>(value));
            }
            catch (TException ex)
            {
                result(new ActionResult<String>(true, ex.Message));
            }
        }
        public static async Task RunAsync(Func<Task<String[]>> action, Action<ActionResult<String[]>> result)
            => await RunAsync<Exception>(action, result);
        public static async Task RunAsync<TException>(Func<Task<String[]>> action, Action<ActionResult<String[]>> result)
            where TException : Exception
        {
            try
            {
                String[] value = await action();
                result(new ActionResult<String[]>(value));
            }
            catch (TException ex)
            {
                result(new ActionResult<String[]>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Actions (struct)
        public static async Task RunAsync<T>(Func<Task<T>> action, Action<ActionResult<T>> result) where T: struct
            => await RunAsync<T,Exception>(action, result);
        public static async Task RunAsync<T,TException>(Func<Task<T>> action, Action<ActionResult<T>> result) where T: struct
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
        public static async Task RunAsync<T>(Func<Task<T[]>> action, Action<ActionResult<T[]>> result) where T: struct
            => await RunAsync<T,Exception>(action, result);
        public static async Task RunAsync<T,TException>(Func<Task<T[]>> action, Action<ActionResult<T[]>> result) where T: struct
            where TException : Exception
        {
            try
            {
                T[] value = await action();
                result(new ActionResult<T[]>(value));
            }
            catch (TException ex)
            {
                result(new ActionResult<T[]>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Actions
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

        #region RunAsync - Tuple Actions (IEnumerable<T>)
        private static async Task RunAsync<T>(Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)> action) => await RunAsync<T,Exception>(action);
        private static async Task RunAsync<T,TException>(Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)> action)
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
                invoke.result(new ActionResult<T>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Tuple Actions (string)
        private static async Task RunAsync(Func<(Task<String> action, Action<ActionResult<String>> result)> action) => await RunAsync<Exception>(action);
        private static async Task RunAsync<TException>(Func<(Task<String> action, Action<ActionResult<String>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<String>(await invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<String>(true,ex.Message));
            }
        }
        private static async Task RunAsync(Func<(Task<String[]> action, Action<ActionResult<String[]>> result)> action) => await RunAsync<Exception>(action);
        private static async Task RunAsync<TException>(Func<(Task<String[]> action, Action<ActionResult<String[]>> result)> action)
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<String[]>(await invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<String[]>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Tuple Actions (struct)
        private static async Task RunAsync<T>(Func<(Task<T> action, Action<ActionResult<T>> result)> action) where T: struct => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T, TException>(Func<(Task<T> action, Action<ActionResult<T>> result)> action) where T: struct
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
                invoke.result(new ActionResult<T>(true, ex.Message));
            }
        }
        private static async Task RunAsync<T>(Func<(Task<T[]> action, Action<ActionResult<T[]>> result)> action) where T : struct => await RunAsync<T, Exception>(action);
        private static async Task RunAsync<T, TException>(Func<(Task<T[]> action, Action<ActionResult<T[]>> result)> action) where T : struct
            where TException : Exception
        {
            try
            {
                var invoke = action();
                invoke.result(new ActionResult<T[]>(await invoke.action));
            }
            catch (TException ex)
            {
                var invoke = action();
                invoke.result(new ActionResult<T[]>(true, ex.Message));
            }
        }
        #endregion

        #region RunAsync - Tuple Actions
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
                var invoke = action.Invoke();
                await invoke.action;
                invoke.result(new ActionResult(invoke.action));
            }
            catch (TException ex)
            {
                action.Invoke().result(new ActionResult<Delegate>(true, ex.Message));
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

        #region Invoke - Tuple Actions (IEnumerable<T>)
        public static void Invoke<T>(params Func<(IEnumerable<T> action, Action<ActionResult<T>> result)>[] actions) => Invoke<T>(ProcessType.Default, actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(IEnumerable<T> action, Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, Action<ActionResult<T>> result)> action in actions)
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, Action<ActionResult<T>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Actions (string)
        public static void Invoke(params Func<(String action, Action<ActionResult<String>> result)>[] actions) => Invoke(ProcessType.Default, actions);
        public static void Invoke(ProcessType typeProcess, params Func<(String action, Action<ActionResult<String>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(String action, Action<ActionResult<String>> result)> action in actions)
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(String action, Action<ActionResult<String>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void Invoke(params Func<(String[] action, Action<ActionResult<String[]>> result)>[] actions) => Invoke(ProcessType.Default, actions);
        public static void Invoke(ProcessType typeProcess, params Func<(String[] action, Action<ActionResult<String[]>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(String[] action, Action<ActionResult<String[]>> result)> action in actions)
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(String[] action, Action<ActionResult<String[]>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Actions (struct)
        public static void Invoke<T>(params Func<(T action,Action<ActionResult<T>> result)>[] actions) where T: struct => Invoke<T>(ProcessType.Default,actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(T action,Action<ActionResult<T>> result)>[] actions)where T: struct
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
        public static void Invoke<T>(params Func<(T[] action, Action<ActionResult<T[]>> result)>[] actions) where T : struct => Invoke<T>(ProcessType.Default, actions);
        public static void Invoke<T>(ProcessType typeProcess, params Func<(T[] action, Action<ActionResult<T[]>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(T[] action, Action<ActionResult<T[]>> result)> action in actions)
                            Task.Run(() => Run(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(T[] action, Action<ActionResult<T[]>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => Run(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Actions
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

        #region Invoke - Func<T> (IEnumerable<T>)
        public static ActionResult<T> Invoke<T>(Func<IEnumerable<T>> action) => Invoke<T,Exception>(action);
        public static ActionResult<T> Invoke<T,TException>(Func<IEnumerable<T>> action) where TException : Exception
        {
            try
            {
                IEnumerable<T> value = action();
                return new ActionResult<T>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(true, ex.Message);
            }
        }
        #endregion

        #region Invoke - Func<T> (string)
        public static ActionResult<String> Invoke(Func<String> action) => Invoke<Exception>(action);
        public static ActionResult<String> Invoke<TException>(Func<String> action) where TException : Exception
        {
            try
            {
                String value = action();
                return new ActionResult<String>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<String>(true, ex.Message);
            }
        }
        public static ActionResult<String[]> Invoke(Func<String[]> action) => Invoke<Exception>(action);
        public static ActionResult<String[]> Invoke<TException>(Func<String[]> action) where TException : Exception
        {
            try
            {
                String[] value = action();
                return new ActionResult<String[]>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<String[]>(true, ex.Message);
            }
        }
        #endregion

        #region Invoke - Func<T> (struct)
        public static ActionResult<T> Invoke<T>(Func<T> action)where T: struct => Invoke<T, Exception>(action);
        public static ActionResult<T> Invoke<T, TException>(Func<T> action) 
            where T : struct 
            where TException : Exception
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
        public static ActionResult<T[]> Invoke<T>(Func<T[]> action) where T : struct => Invoke<T, Exception>(action);
        public static ActionResult<T[]> Invoke<T, TException>(Func<T[]> action)
            where T : struct
            where TException : Exception
        {
            try
            {
                T[] value = action();
                return new ActionResult<T[]>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T[]>(true, ex.Message);
            }
        }
        #endregion

        #region Invoke - Func<ActionResult<T>>

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

        #region InvokeAsync - Func<(Task<T>)> : (IEnumerable<T>)
        public static async Task InvokeAsync<T>(params Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)>[] actions)
            => await InvokeAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeAsync<T>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)> action in actions)
                            await RunAsync<T,Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, Action<ActionResult<T>> result)> action in actions)
                            tasks.Add(RunAsync<T,Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
                
        #endregion

        #region InvokeAsync - Func<(Task<string>)> : (string)
        public static async Task InvokeAsync(params Func<(Task<String> action, Action<ActionResult<String>> result)>[] actions)
            => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<(Task<String> action, Action<ActionResult<String>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<String> action, Action<ActionResult<String>> result)> action in actions)
                            await RunAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<String> action, Action<ActionResult<String>> result)> action in actions)
                            tasks.Add(RunAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeAsync(params Func<(Task<String[]> action, Action<ActionResult<String[]>> result)>[] actions)
            => await InvokeAsync(ProcessType.Default, actions);
        public static async Task InvokeAsync(ProcessType typeProcess, params Func<(Task<String[]> action, Action<ActionResult<String[]>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<String[]> action, Action<ActionResult<String[]>> result)> action in actions)
                            await RunAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<String[]> action, Action<ActionResult<String[]>> result)> action in actions)
                            tasks.Add(RunAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<T>)> : (struct)
        public static async Task InvokeAsync<T>(params Func<(Task<T> action, Action<ActionResult<T>> result)>[] actions)where T: struct 
            => await InvokeAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeAsync<T>(ProcessType typeProcess, params Func<(Task<T> action, Action<ActionResult<T>> result)>[] actions) where T: struct
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
        public static async Task InvokeAsync<T>(params Func<(Task<T[]> action, Action<ActionResult<T[]>> result)>[] actions) where T : struct
            => await InvokeAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeAsync<T>(ProcessType typeProcess, params Func<(Task<T[]> action, Action<ActionResult<T[]>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<T[]> action, Action<ActionResult<T[]>> result)> action in actions)
                            await RunAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<T[]> action, Action<ActionResult<T[]>> result)> action in actions)
                            tasks.Add(RunAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<ActionResult<T>>)>
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

        #region InvokeAsync - Func<(Task)>
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
        #endregion

        #region InvokeAsync - Func<Task<T>> : (IEnumerable<T>)
        public static async Task<ActionResult<T>> InvokeAsync<T>(Func<Task<IEnumerable<T>>> action)
            => await InvokeAsync<T,Exception>(action);
        public static async Task<ActionResult<T>> InvokeAsync<T,TException>(Func<Task<IEnumerable<T>>> action)
            where TException : Exception
        {
            try
            {
                IEnumerable<T> value = await action();
                return new ActionResult<T>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T>(true, ex.Message);
            }
        }
        #endregion

        #region InvokeAsync - Func<Task<T>> : (string)
        public static async Task<ActionResult<String>> InvokeAsync(Func<Task<String>> action)
            => await InvokeAsync<Exception>(action);
        public static async Task<ActionResult<String>> InvokeAsync<TException>(Func<Task<String>> action)
            where TException : Exception
        {
            try
            {
                String value = await action();
                return new ActionResult<String>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<String>(true, ex.Message);
            }
        }
        public static async Task<ActionResult<String[]>> InvokeAsync(Func<Task<String[]>> action)
            => await InvokeAsync<Exception>(action);
        public static async Task<ActionResult<String[]>> InvokeAsync<TException>(Func<Task<String[]>> action)
            where TException : Exception
        {
            try
            {
                String[] value = await action();
                return new ActionResult<String[]>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<String[]>(true, ex.Message);
            }
        }
        #endregion

        #region InvokeAsync - Func<Task<T>> : (struct)
        public static async Task<ActionResult<T>> InvokeAsync<T>(Func<Task<T>> action) where T: struct
            => await InvokeAsync<T, Exception>(action);
        public static async Task<ActionResult<T>> InvokeAsync<T, TException>(Func<Task<T>> action)
            where T : struct
            where TException : Exception
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
        public static async Task<ActionResult<T[]>> InvokeAsync<T>(Func<Task<T[]>> action) where T : struct
            => await InvokeAsync<T, Exception>(action);
        public static async Task<ActionResult<T[]>> InvokeAsync<T, TException>(Func<Task<T[]>> action)
            where T : struct
            where TException : Exception
        {
            try
            {
                T[] value = await action();
                return new ActionResult<T[]>(value);
            }
            catch (TException ex)
            {
                return new ActionResult<T[]>(true, ex.Message);
            }
        }
        #endregion

        #region InvokeAsync - Func<Task<T>>
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
                return new ActionResult<T>(true, ex.Message);
            }
        }
        #endregion
    }    
}
