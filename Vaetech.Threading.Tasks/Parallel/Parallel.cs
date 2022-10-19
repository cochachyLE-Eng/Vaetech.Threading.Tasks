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
        #region Invoke - Simple Actions
        public static void Invoke(params Action[] actions) => Invoke(ProcessType.Default, actions);
        public static void Invoke(ProcessType typeProcess, params Action[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.Enqueue:
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
                case ProcessType.Enqueue:
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
                case ProcessType.Enqueue:
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
    }
}