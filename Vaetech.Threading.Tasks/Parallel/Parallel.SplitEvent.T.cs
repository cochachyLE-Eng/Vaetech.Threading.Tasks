using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #region SplitAsync - Func<ListEvent<T>, Task>[]
        public static async Task SplitAsync<T>(List<T> data, params Func<ListEvent<T>, Task>[] funcs)
            => await SplitAsync<T>(ProcessType.Default, data, funcs);
        public static async Task SplitAsync<T>(ProcessType processType, List<T> data, params Func<ListEvent<T>, Task>[] funcs)
        {
            if (!data.Any()) return;
            int i = 0, co = -1, lots = funcs.Count(), c = Count(data.Count, ref lots);            
            
            List<Task> tasks = new List<Task>();
            foreach (Func<ListEvent<T>, Task> fn in funcs.Take(c * lots))
            {
                int re = ++co == lots - 1 ? data.Count % lots : 0;
                switch (processType)
                {
                    case ProcessType.RunInOrder:
                        await fn.Invoke(new ListEvent<T>(processType, data.GetRange(c * i++, c + re), container: co));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(fn(new ListEvent<T>(processType, data.GetRange(c * i++, c + re), container: co)));
                        break;
                }
            }
            await Task.WhenAll(tasks);
        }
        #endregion

        #region SplitAsync - ListEventHandler<T>
        public static async Task SplitAsync<T>(List<T> data, int lots, ListEventHandler<T> @event)
            => await SplitAsync<T>(ProcessType.Default, data, lots, @event);
        public static async Task SplitAsync<T>(ProcessType typeProcess, List<T> data, int lots, ListEventHandler<T> @event)
        {
            if (!data.Any() || lots <= 0) return;                        
            int i = 0, c = Count(data.Count, ref lots);

            IEnumerable<int> r = Enumerable.Range(0, lots);
            List<Task> tasks = new List<Task>();

            foreach (int l in r)
            {
                var handler = new Lazy<ListEventHandler<T>>(() => @event).Value;                
                int re = l == lots - 1 ? data.Count % lots : 0;

                switch (typeProcess)
                {
                    case ProcessType.RunInOrder:
                        T[] data1 = default;
                        await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T>(data1, pack: (0, l))));
                        await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T>(data.GetRange(c * i++, c + re), pack: (0,l))));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T>(data.GetRange(c * i++, c + re), pack: (0,l)))));
                        break;
                }
            }            
            await Task.WhenAll(tasks);              
        }        
        #endregion            

        public class ListEvent<T>
        {
            private readonly List<T> _data;
            private readonly int _container;
            private readonly ProcessType _processType = ProcessType.Default;
            public ListEvent(List<T> data, int container = 0) => (_data, _container) = (data, container);
            public ListEvent(ProcessType processType, List<T> data, int container = 0) => (_processType, _data, _container) = (processType, data, container);

            #region EventAsync - Func<ListEventHandler<List<T>>>
            public async Task EventAsync(params Func<ListEventHandler<T>>[] events)
            {
                if (!events.Any()) return;
                int i = 0, l = -1, lots = events.Count(), c = Count(_data.Count, ref lots);
                
                List<Task> tasks = new List<Task>();
                foreach (Func<ListEventHandler<T>> fn in events.Take(c * lots)) 
                {
                    ListEventHandler<T> handler = fn.Invoke();
                    int re = ++l == lots -1 ? _data.Count % lots : 0;

                    switch (_processType)
                    {                    
                        case ProcessType.RunInOrder:
                            await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T>(_data.GetRange(c * i++, c + re), pack: (_container, l))));                            
                            break;
                        case ProcessType.RunAll:
                        default:
                            tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T>(_data.GetRange(c * i++, c + re), pack: (_container, l)))));                            
                            break;
                    }
                }                
                await Task.WhenAll(tasks);
            }
            #endregion
        }
    }
}