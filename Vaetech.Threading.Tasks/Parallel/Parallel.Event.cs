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
        #region Run - Tuple Events (IEnumerable<T>)        
        private static void RunEvent<T>(Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action)
            => RunEvent<T, Exception>(action);
        private static void RunEvent<T, TException>(Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action)
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>>(invoke.action));
        }            
        private static void RunEvent<T,T1>(Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action)
            => RunEvent<T,T1, Exception>(action);
        private static void RunEvent<T,T1, TException>(Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>,T1>(invoke.action, invoke.item1));
        }
        private static void RunEvent<T, T1, T2>(Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action)
            => RunEvent<T, T1, T2, Exception>(action);
        private static void RunEvent<T, T1, T2, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2>(invoke.action, invoke.item1, invoke.item2));
        }
        private static void RunEvent<T, T1, T2, T3>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action)
            => RunEvent<T, T1, T2, T3, Exception>(action);
        private static void RunEvent<T, T1, T2, T3, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(invoke.action, invoke.item1, invoke.item2, invoke.item3));
        }
        private static void RunEvent<T, T1, T2, T3, T4>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action)
            => RunEvent<T, T1, T2, T3, T4, Exception>(action);
        private static void RunEvent<T, T1, T2, T3, T4, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>(invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4));
        }
        private static void RunEvent<T, T1, T2, T3, T4, T5>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action)
            => RunEvent<T, T1, T2, T3, T4, T5, Exception>(action);
        private static void RunEvent<T, T1, T2, T3, T4, T5, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>(invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5));
        }
        private static void RunEvent<T, T1, T2, T3, T4, T5, T6>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action)
            => RunEvent<T, T1, T2, T3, T4, T5, T6, Exception>(action);
        private static void RunEvent<T, T1, T2, T3, T4, T5, T6, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>(invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5, invoke.item6));
        }
        private static void RunEvent<T, T1, T2, T3, T4, T5, T6, T7>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action)
            => RunEvent<T, T1, T2, T3, T4, T5, T6, T7, Exception>(action);
        private static void RunEvent<T, T1, T2, T3, T4, T5, T6, T7, TException>(Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>(invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5, invoke.item6, invoke.item7));
        }
        #endregion

        #region Run - Tuple Events (string)
        private static void RunEvent(Func<(String action, Action<DynamicEventArgs<String>> result)> action)
            => RunEvent<Exception>(action);
        private static void RunEvent<TException>(Func<(String action, Action<DynamicEventArgs<String>> result)> action)
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<String>(invoke.action));
        }
        private static void RunEvent(Func<(String[] action, Action<DynamicEventArgs<String[]>> result)> action)
            => RunEvent<Exception>(action);
        private static void RunEvent<TException>(Func<(String[] action, Action<DynamicEventArgs<String[]>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<String[]>(invoke.action));
        }
        #endregion

        #region Run - Tuple Events (struct)
        private static void RunEvent<T>(Func<(T action, Action<DynamicEventArgs<T>> result)> action) where T : struct
            => RunEvent<T, Exception>(action);
        private static void RunEvent<T, TException>(Func<(T action, Action<DynamicEventArgs<T>> result)> action) where T : struct
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<T>(invoke.action));            
        }
        private static void RunEvent<T>(Func<(T[] action, Action<DynamicEventArgs<T[]>> result)> action) where T : struct
            => RunEvent<T, Exception>(action);
        private static void RunEvent<T, TException>(Func<(T[] action, Action<DynamicEventArgs<T[]>> result)> action) where T : struct
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<T[]>(invoke.action));
        }
        #endregion

        #region Run - Tuple Events
        private static void RunEvent<T>(Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action) => RunEvent<T, Exception>(action);
        private static void RunEvent<T, TException>(Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<ActionResult<T>>(invoke.action));
        }
        #endregion

        #region RunAsync - Tuple Events (IEnumerable<T>)
        private static async Task RunEventAsync<T>(Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action) => await RunEventAsync<T, Exception>(action);
        private static async Task RunEventAsync<T, TException>(Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action)
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>>(await invoke.action));
        }
        private static async Task RunEventAsync<T,T1>(Func<(Task<IEnumerable<T>> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action) => await RunEventAsync<T, T1, Exception>(action);
        private static async Task RunEventAsync<T, T1, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>,T1>(await invoke.action,invoke.item1));
        }
        private static async Task RunEventAsync<T, T1, T2>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action) => await RunEventAsync<T, T1, T2, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2>(await invoke.action, invoke.item1, invoke.item2));
        }
        private static async Task RunEventAsync<T, T1, T2, T3>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action) => await RunEventAsync<T, T1, T2, T3, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, T3, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(await invoke.action, invoke.item1, invoke.item2, invoke.item3));
        }
        private static async Task RunEventAsync<T, T1, T2, T3, T4>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action) => await RunEventAsync<T, T1, T2, T3, T4, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, T3, T4, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>(await invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4));
        }
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action) => await RunEventAsync<T, T1, T2, T3, T4, T5, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>(await invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5));
        }
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5, T6>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action) => await RunEventAsync<T, T1, T2, T3, T4, T5, T6, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5, T6, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>(await invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5, invoke.item6));
        }
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5, T6, T7>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action) => await RunEventAsync<T, T1, T2, T3, T4, T5, T6, T7, Exception>(action);
        private static async Task RunEventAsync<T, T1, T2, T3, T4, T5, T6, T7, TException>(Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action)
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>(await invoke.action, invoke.item1, invoke.item2, invoke.item3, invoke.item4, invoke.item5, invoke.item6, invoke.item7));
        }
        #endregion

        #region RunAsync - Tuple Events (string)
        private static async Task RunEventAsync(Func<(Task<String> action, Action<DynamicEventArgs<String>> result)> action) => await RunEventAsync<Exception>(action);
        private static async Task RunEventAsync<TException>(Func<(Task<String> action, Action<DynamicEventArgs<String>> result)> action)
            where TException : Exception
        {           
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<String>(await invoke.action));
        }
        private static async Task RunEventAsync(Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)> action) => await RunEventAsync<Exception>(action);
        private static async Task RunEventAsync<TException>(Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)> action)
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<String[]>(await invoke.action));
        }
        #endregion

        #region RunAsync - Tuple Events (struct)
        private static async Task RunEventAsync<T>(Func<(Task<T> action, Action<DynamicEventArgs<T>> result)> action) where T : struct
            => await RunEventAsync<T, Exception>(action);
        private static async Task RunEventAsync<T, TException>(Func<(Task<T> action, Action<DynamicEventArgs<T>> result)> action)
            where T : struct
            where TException : Exception
        {
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<T>(await invoke.action));
        }
        private static async Task RunEventAsync<T>(Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)> action) where T : struct
            => await RunEventAsync<T, Exception>(action);
        private static async Task RunEventAsync<T, TException>(Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)> action)
            where T : struct
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<T[]>(await invoke.action));
        }
        #endregion

        #region RunAsync - Tuple Events
        private static async Task RunEventAsync<T>(Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action) => await RunEventAsync<T, Exception>(action);
        private static async Task RunEventAsync<T, TException>(Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action)
            where TException : Exception
        {            
            var invoke = action();
            invoke.result?.Invoke(new DynamicEventArgs<ActionResult<T>>(await invoke.action));            
        }
        private static async Task RunEventAsync(Func<(Task action, Action<DynamicEventArgs<object>> result)> action) => await RunEventAsync<Exception>(action);
        private static async Task RunEventAsync<TException>(Func<(Task action, Action<DynamicEventArgs<object>> result)> action)
            where TException : Exception
        {            
            var invoke = action.Invoke(); await invoke.action;
            invoke.result?.Invoke(new DynamicEventArgs<object>(invoke.action.AsyncState));            
        }
        #endregion

        #region RunAsync - Events (IEnumerable<T>)
        public static async Task RunEventAsync<T>(Func<Task<IEnumerable<T>>> action, Action<DynamicEventArgs<TupleResult<IEnumerable<T>>>> result)
            => await RunEventAsync<T, Exception>(action, result);
        public static async Task RunEventAsync<T, TException>(Func<Task<IEnumerable<T>>> action, Action<DynamicEventArgs<TupleResult<IEnumerable<T>>>> result)
            where TException : Exception
        {
            try
            {
                IEnumerable<T> value = await action();
                result?.Invoke(new DynamicEventArgs<TupleResult<IEnumerable<T>>>(new TupleResult<IEnumerable<T>>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<TupleResult<IEnumerable<T>>>(new TupleResult<IEnumerable<T>>(true, ex.Message)));
            }
        }
        #endregion

        #region RunAsync - Events (string)
        public static async Task RunEventAsync(Func<Task<String>> action, Action<DynamicEventArgs<TupleResult<String>>> result)
            => await RunEventAsync<Exception>(action, result);
        public static async Task RunEventAsync<TException>(Func<Task<String>> action, Action<DynamicEventArgs<TupleResult<String>>> result)
            where TException : Exception
        {
            try
            {
                String value = await action();
                result?.Invoke(new DynamicEventArgs<TupleResult<String>>(new TupleResult<String>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<TupleResult<String>>(new TupleResult<String>(true, ex.Message)));
            }
        }
        public static async Task RunEventAsync(Func<Task<String[]>> action, Action<DynamicEventArgs<TupleResult<String[]>>> result)
            => await RunEventAsync<Exception>(action, result);
        public static async Task RunEventAsync<TException>(Func<Task<String[]>> action, Action<DynamicEventArgs<TupleResult<String[]>>> result)
            where TException : Exception
        {
            try
            {
                String[] value = await action();
                result?.Invoke(new DynamicEventArgs<TupleResult<String[]>>(new TupleResult<String[]>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<TupleResult<String[]>>(new TupleResult<String[]>(true, ex.Message)));
            }
        }
        #endregion

        #region RunAsync - Events (struct)
        public static async Task RunEventAsync<T>(Func<Task<T>> action, Action<DynamicEventArgs<TupleResult<T>>> result) where T : struct
            => await RunEventAsync<T, Exception>(action, result);
        public static async Task RunEventAsync<T, TException>(Func<Task<T>> action, Action<DynamicEventArgs<TupleResult<T>>> result) where T : struct
            where TException : Exception
        {
            try
            {
                T value = await action();
                result?.Invoke(new DynamicEventArgs<TupleResult<T>>(new TupleResult<T>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<TupleResult<T>>(new TupleResult<T>(true, ex.Message)));
            }
        }
        public static async Task RunEventAsync<T>(Func<Task<T[]>> action, Action<DynamicEventArgs<TupleResult<T[]>>> result) where T : struct
            => await RunEventAsync<T, Exception>(action, result);
        public static async Task RunEventAsync<T, TException>(Func<Task<T[]>> action, Action<DynamicEventArgs<TupleResult<T[]>>> result) where T : struct
            where TException : Exception
        {
            try
            {
                T[] value = await action();
                result?.Invoke(new DynamicEventArgs<TupleResult<T[]>>(new TupleResult<T[]>(value)));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<TupleResult<T[]>>(new TupleResult<T[]>(true, ex.Message)));
            }
        }
        #endregion

        #region RunAsync - Events
        public static async Task RunEventAsync<T>(Func<Task<ActionResult<T>>> action, Action<DynamicEventArgs<ActionResult<T>>> result)
            => await RunEventAsync<T, Exception>(action, result);
        public static async Task RunEventAsync<T, TException>(Func<Task<ActionResult<T>>> action, Action<DynamicEventArgs<ActionResult<T>>> result)
            where TException : Exception
        {
            try
            {
                result?.Invoke(new DynamicEventArgs<ActionResult<T>>(await action()));
            }
            catch (TException ex)
            {
                result?.Invoke(new DynamicEventArgs<ActionResult<T>>(new ActionResult<T>(true, ex.Message)));
            }
        }
        #endregion

        #region Invoke - Tuple Events (IEnumerable<T>)
        public static void InvokeEvent<T>(params Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)>[] actions) => InvokeEvent<T>(ProcessType.Default, actions);
        public static void InvokeEvent<T>(ProcessType typeProcess, params Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action in actions)
                            Task.Run(() => RunEvent(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1>(params Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>, T1>> result)>[] actions) => InvokeEvent<T, T1>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>, T1>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T,T1>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1, T2>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)>[] actions) => InvokeEvent<T, T1, T2>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }        
        public static void InvokeEvent<T, T1, T2, T3>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)>[] actions) => InvokeEvent<T, T1, T2, T3>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2, T3>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2, T3>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2, T3>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1, T2, T3, T4>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)>[] actions) => InvokeEvent<T, T1, T2, T3, T4>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2, T3, T4>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2, T3, T4>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2, T3, T4>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1, T2, T3, T4, T5>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)>[] actions) => InvokeEvent<T, T1, T2, T3, T4, T5>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2, T3, T4, T5>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2, T3, T4, T5>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2, T3, T4, T5>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1, T2, T3, T4, T5, T6>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)>[] actions) => InvokeEvent<T, T1, T2, T3, T4, T5, T6>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2, T3, T4, T5, T6>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2, T3, T4, T5, T6>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2, T3, T4, T5, T6>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T, T1, T2, T3, T4, T5, T6, T7>(params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)>[] actions) => InvokeEvent<T, T1, T2, T3, T4, T5, T6, T7>(ProcessType.Default, actions);
        public static void InvokeEvent<T, T1, T2, T3, T4, T5, T6, T7>(ProcessType typeProcess, params Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action in actions)
                            Task.Run(() => RunEvent<T, T1, T2, T3, T4, T5, T6, T7>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(IEnumerable<T> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T, T1, T2, T3, T4, T5, T6, T7>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Events (string)
        public static void InvokeEvent(params Func<(String action, Action<DynamicEventArgs<String>> result)>[] actions) => InvokeEvent(ProcessType.Default, actions);
        public static void InvokeEvent(ProcessType typeProcess, params Func<(String action, Action<DynamicEventArgs<String>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(String action, Action<DynamicEventArgs<String>> result)> action in actions)
                            Task.Run(() => RunEvent(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(String action, Action<DynamicEventArgs<String>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent(params Func<(String[] action, Action<DynamicEventArgs<String[]>> result)>[] actions) => InvokeEvent(ProcessType.Default, actions);
        public static void InvokeEvent(ProcessType typeProcess, params Func<(String[] action, Action<DynamicEventArgs<String[]>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(String[] action, Action<DynamicEventArgs<String[]>> result)> action in actions)
                            Task.Run(() => RunEvent(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(String[] action, Action<DynamicEventArgs<String[]>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Events (struct)
        public static void InvokeEvent<T>(params Func<(T action, Action<DynamicEventArgs<T>> result)>[] actions) where T : struct => InvokeEvent<T>(ProcessType.Default, actions);
        public static void InvokeEvent<T>(ProcessType typeProcess, params Func<(T action, Action<DynamicEventArgs<T>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(T action, Action<DynamicEventArgs<T>> result)> action in actions)
                            Task.Run(() => RunEvent(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(T action, Action<DynamicEventArgs<T>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        public static void InvokeEvent<T>(params Func<(T[] action, Action<DynamicEventArgs<T[]>> result)>[] actions) where T : struct => InvokeEvent<T>(ProcessType.Default, actions);
        public static void InvokeEvent<T>(ProcessType typeProcess, params Func<(T[] action, Action<DynamicEventArgs<T[]>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(T[] action, Action<DynamicEventArgs<T[]>> result)> action in actions)
                            Task.Run(() => RunEvent(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(T[] action, Action<DynamicEventArgs<T[]>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region Invoke - Tuple Events
        public static void InvokeEvent<T>(params Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)>[] actions) => InvokeEvent<T>(ProcessType.Default, actions);
        public static void InvokeEvent<T>(ProcessType typeProcess, params Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action in actions)
                            Task.Run(() => RunEvent<T>(action)).Wait();
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(ActionResult<T> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action in actions)
                            tasks.Add(Task.Factory.StartNew(() => RunEvent<T>(action)));

                        Task.WaitAll(tasks.ToArray());
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<T>)> : (IEnumerable<T>)
        public static async Task InvokeEventAsync<T>(params Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)>[] actions)
            => await InvokeEventAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action in actions)
                            await RunEventAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, Action<DynamicEventArgs<IEnumerable<T>>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T,T1>(params Func<(Task<IEnumerable<T>> action,T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)>[] actions)
            => await InvokeEventAsync<T,T1>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T,T1>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action in actions)
                            await RunEventAsync<T, T1, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, Action<DynamicEventArgs<IEnumerable<T>,T1>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, Action<DynamicEventArgs<IEnumerable<T>, T1, T2>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2, T3>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2, T3>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2, T3>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, T3, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, T3, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2, T3, T4>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, T3, T4, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, T3, T4, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2, T3, T4, T5>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, T3, T4, T5, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, T3, T4, T5, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5, T6>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2, T3, T4, T5, T6>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5, T6>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, T3, T4, T5, T6, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, T3, T4, T5, T6, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5, T6, T7>(params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)>[] actions)
            => await InvokeEventAsync<T, T1, T2, T3, T4, T5, T6, T7>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T, T1, T2, T3, T4, T5, T6, T7>(ProcessType typeProcess, params Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action in actions)
                            await RunEventAsync<T, T1, T2, T3, T4, T5, T6, T7, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<IEnumerable<T>> action, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, Action<DynamicEventArgs<IEnumerable<T>, T1, T2, T3, T4, T5, T6, T7>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, T1, T2, T3, T4, T5, T6, T7, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<string>)> : (string)
        public static async Task InvokeEventAsync(params Func<(Task<String> action, Action<DynamicEventArgs<String>> result)>[] actions)
            => await InvokeEventAsync(ProcessType.Default, actions);
        public static async Task InvokeEventAsync(ProcessType typeProcess, params Func<(Task<String> action, Action<DynamicEventArgs<String>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<String> action, Action<DynamicEventArgs<String>> result)> action in actions)
                            await RunEventAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<String> action, Action<DynamicEventArgs<String>> result)> action in actions)
                            tasks.Add(RunEventAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync(params Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)>[] actions)
            => await InvokeEventAsync(ProcessType.Default, actions);
        public static async Task InvokeEventAsync(ProcessType typeProcess, params Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)> action in actions)
                            await RunEventAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<String[]> action, Action<DynamicEventArgs<String[]>> result)> action in actions)
                            tasks.Add(RunEventAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<T>)> : (struct)
        public static async Task InvokeEventAsync<T>(params Func<(Task<T> action, Action<DynamicEventArgs<T>> result)>[] actions) where T : struct
            => await InvokeEventAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T>(ProcessType typeProcess, params Func<(Task<T> action, Action<DynamicEventArgs<T>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<T> action, Action<DynamicEventArgs<T>> result)> action in actions)
                            await RunEventAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<T> action, Action<DynamicEventArgs<T>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        public static async Task InvokeEventAsync<T>(params Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)>[] actions) where T : struct
            => await InvokeEventAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T>(ProcessType typeProcess, params Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)>[] actions) where T : struct
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)> action in actions)
                            await RunEventAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<T[]> action, Action<DynamicEventArgs<T[]>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task<ActionResult<T>>)>
        public static async Task InvokeEventAsync<T>(params Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)>[] actions)
            => await InvokeEventAsync<T>(ProcessType.Default, actions);
        public static async Task InvokeEventAsync<T>(ProcessType typeProcess, params Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action in actions)
                            await RunEventAsync<T, Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task<ActionResult<T>> action, Action<DynamicEventArgs<ActionResult<T>>> result)> action in actions)
                            tasks.Add(RunEventAsync<T, Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        #region InvokeAsync - Func<(Task)>
        public static async Task InvokeEventAsync(params Func<(Task action, Action<DynamicEventArgs<object>> result)>[] actions)
            => await InvokeEventAsync(ProcessType.Default, actions);
        public static async Task InvokeEventAsync(ProcessType typeProcess, params Func<(Task action, Action<DynamicEventArgs<object>> result)>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<(Task action, Action<DynamicEventArgs<object>> result)> action in actions)
                            await RunEventAsync<Exception>(action);
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<(Task action, Action<DynamicEventArgs<object>> result)> action in actions)
                            tasks.Add(RunEventAsync<Exception>(action));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion
    }
}
