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
        #region WorkerAsync - Func<ListEvent<T, T1, T2, T3, T4, T5, T6>, Task>[]
        public static async Task SplitEventAsync<T, T1, T2, T3, T4, T5, T6>(List<T> data, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, params Func<ListEvent<T, T1, T2, T3, T4, T5, T6>, Task>[] actions)
            => await SplitEventAsync<T, T1, T2, T3, T4, T5, T6>(ProcessType.Default, data, item1, item2, item3, item4, item5, item6, actions);
        public static async Task SplitEventAsync<T, T1, T2, T3, T4, T5, T6>(ProcessType typeProcess, List<T> data, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, params Func<ListEvent<T, T1, T2, T3, T4, T5, T6>, Task>[] actions)
        {
            if (!data.Any()) return;
            int i = 0, co = -1, lots = actions.Count(), c = count(data.Count, ref lots);

            List<Task> tasks = new List<Task>();
            foreach (Func<ListEvent<T, T1, T2, T3, T4, T5, T6>, Task> action in actions)
            {
                int re = (++co == actions.Count() ? data.Count % lots : 0);
                switch (typeProcess)
                {
                    case ProcessType.Enqueue:
                        await action.Invoke(new ListEvent<T, T1, T2, T3, T4, T5, T6>(typeProcess, data.GetRange(c * i++, c + re), item1, item2, item3, item4, item5, item6, container: co));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(action(new ListEvent<T, T1, T2, T3, T4, T5, T6>(typeProcess, data.GetRange(c * i++, c + re), item1, item2, item3, item4, item5, item6, container: co)));
                        break;
                }
            }

            if (tasks.Any())
                await Task.WhenAll(tasks);
        }
        #endregion
        public class ListEvent<T, T1, T2, T3, T4, T5, T6>
        {
            private readonly List<T> _data;
            private readonly int _container;
            private readonly T1 _item1;
            private readonly T2 _item2;
            private readonly T3 _item3;
            private readonly T4 _item4;
            private readonly T5 _item5;
            private readonly T6 _item6;
            private readonly ProcessType _processType = ProcessType.Default;
            public ListEvent(List<T> data, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int container = 0) => (_data, _item1, _item2, _item3, _item4, _item5, _item6, _container) = (data, item1, item2, item3, item4, item5, item6, container);            
            public ListEvent(ProcessType processType, List<T> data, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, int container = 0) => (_processType, _data, _item1, _item2, _item3, _item4, _item5, _item6, _container) = (processType, data, item1, item2, item3, item4, item5, item6, container);

            #region EventAsync - Func<ListEventHandler<T, T1, T2, T3, T4, T5, T6>>[]
            public async Task EventAsync(params Func<ListEventHandler<T, T1, T2, T3, T4, T5, T6>>[] events)
            {
                if (!events.Any()) return;
                int i = 0, l = -1, lots = events.Count(), c = count(_data.Count, ref lots);

                List<Task> tasks = new List<Task>();

                foreach (Func<ListEventHandler<T, T1, T2, T3, T4, T5, T6>> ev in events)
                {
                    ListEventHandler<T, T1, T2, T3, T4, T5, T6> handler = ev.Invoke();
                    int re = (++l == events.Count() ? _data.Count % lots : 0);

                    switch (_processType)
                    {
                        case ProcessType.Enqueue:
                            await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T, T1, T2, T3, T4, T5, T6>(_data.GetRange(c * i++, c + re), _item1, _item2, _item3, _item4, _item5, _item6, pack: (_container, l))));
                            break;
                        case ProcessType.RunAll:
                        default:
                            tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T, T1, T2, T3, T4, T5, T6>(_data.GetRange(c * i++, c + re), _item1, _item2, _item3, _item4, _item5, _item6, pack: (_container, l)))));
                            break;
                    }
                }

                if (tasks.Any())
                    await Task.WhenAll(tasks);
            }
            #endregion
        }
    }
}