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

        #region RunAsync - Tuple Func<(Task<T> action, Action<ActionResult<T>> result)>
        public static async Task RunTupleAsync<T>(Func<(Task<T> action, Action<ActionResult<T>> result)> action) => await RunTupleAsync<T, Exception>(action);
        public static async Task RunTupleAsync<T, TException>(Func<(Task<T> action, Action<ActionResult<T>> result)> action)
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
        #region RunAsync - Tuple Func<(Task<T> action, Action<ActionResult<T>> result)>
        public static async Task RunTupleAsync<T>(Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)> action) => await RunTupleAsync<T, Exception>(action);
        public static async Task RunTupleAsync<T, TException>(Func<(Task<ActionResult<T>> action, Action<ActionResult<T>> result)> action)
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
        #endregion
    }
}
