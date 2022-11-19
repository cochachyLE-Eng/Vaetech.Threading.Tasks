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
        #region SplitAsync - Func<ListEvent<T, T1>, Task>[]
        public static async Task SplitAsync<T, T1>(List<T> data, T1 item1, params Func<ListEvent<T, T1>, Task>[] funcs)
            => await SplitAsync<T, T1>(ProcessType.Default, data, item1, funcs);
        public static async Task SplitAsync<T, T1>(ProcessType processType, List<T> data, T1 item1, params Func<ListEvent<T, T1>, Task>[] funcs)
        {
            if (!data.Any()) return;
            int i = 0, co = -1, lots = funcs.Count(), c = Count(data.Count, ref lots);

            List<Task> tasks = new List<Task>();
            foreach (Func<ListEvent<T, T1>, Task> fn in funcs.Take(c * lots))
            {
                int re = ++co == lots - 1 ? data.Count % lots : 0;
                switch (processType)
                {
                    case ProcessType.Enqueue:
                        await fn.Invoke(new ListEvent<T, T1>(processType, data.GetRange(c * i++, c + re), item1, container: co));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(fn(new ListEvent<T, T1>(processType, data.GetRange(c * i++, c + re), item1, container: co)));
                        break;
                }
            }            
            await Task.WhenAll(tasks);
        }
        #endregion

        public class ListEvent<T, T1>
        {
            private readonly List<T> _data;
            private readonly int _container;
            private readonly T1 _item1;
            private readonly ProcessType _processType = ProcessType.Default;
            public ListEvent(List<T> data, T1 item1, int container = 0) => (_data, _item1, _container) = (data, item1, container);            
            public ListEvent(ProcessType processType, List<T> data, T1 item1, int container) => (_processType, _data, _item1, _container) = (processType, data, item1, container);

            #region EventAsync - Func<ListEventHandler<T, T1>>[]
            public async Task EventAsync(params Func<ListEventHandler<T, T1>>[] events)
            {
                if (!events.Any()) return;
                int i = 0, l = -1, lots = events.Count(), c = Count(_data.Count, ref lots);

                List<Task> tasks = new List<Task>();
                foreach (Func<ListEventHandler<T, T1>> fn in events.Take(c * lots))
                {
                    ListEventHandler<T, T1> handler = fn.Invoke();
                    int re = ++l == lots - 1 ? _data.Count % lots : 0;

                    switch (_processType)
                    {
                        case ProcessType.Enqueue:
                            await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T, T1>(_data.GetRange(c * i++, c + re), _item1, pack: (_container, l))));
                            break;
                        case ProcessType.RunAll:
                        default:
                            tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T, T1>(_data.GetRange(c * i++, c + re), _item1, pack: (_container, l)))));
                            break;
                    }
                }                
                await Task.WhenAll(tasks);
            }
            #endregion
        }
    }
}