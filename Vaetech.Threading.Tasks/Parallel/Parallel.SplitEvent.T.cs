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
        #region WorkerAsync - Func<ListEvent<T>, Task>[]
        public static async Task SplitEventAsync<T>(List<T> data, params Func<ListEvent<T>, Task>[] actions)
            => await SplitEventAsync<T>(ProcessType.Default, data, actions);
        public static async Task SplitEventAsync<T>(ProcessType typeProcess, List<T> data, params Func<ListEvent<T>, Task>[] actions)
        {
            if (!data.Any()) return;
            int i = 0, co = 0, lots = actions.Count(), c = count(data.Count, ref lots);            
            
            List<Task> tasks = new List<Task>();
            foreach (Func<ListEvent<T>, Task> action in actions)
            {
                int re = (++co == actions.Count() ? data.Count % lots : 0);
                switch (typeProcess)
                {
                    case ProcessType.Enqueue:
                        await action.Invoke(new ListEvent<T>(typeProcess, data.GetRange(c * i++, c + re), container: co - 1));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(action(new ListEvent<T>(typeProcess, data.GetRange(c * i++, c + re), container: co - 1)));
                        break;
                }
            }

            if(tasks.Any())
                await Task.WhenAll(tasks);
        }
        #endregion

        #region SplitEventAsync - Func<ListEventHandler<T>>
        public static async Task SplitEventAsync<T>(List<T> data, int lots, ListEventHandler<T> @event)
            => await SplitEventAsync<T>(ProcessType.Default, data, lots, @event);
        public static async Task SplitEventAsync<T>(ProcessType typeProcess, List<T> data, int lots, ListEventHandler<T> @event)
        {
            if (!data.Any() || lots <= 0) return;                        
            int i = 0, c = count(data.Count, ref lots);

            IEnumerable<int> r = range(0, lots);
            List<Task> tasks = new List<Task>();

            foreach (int l in r)
            {
                var handler = new Lazy<ListEventHandler<T>>(() => @event).Value;                
                int re = (l == r.Max() ? data.Count % lots : 0);

                switch (typeProcess)
                {
                    case ProcessType.Enqueue:                        
                        await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T>(data.GetRange(c * i++, c + re), pack: (0,l))));
                        break;
                    case ProcessType.RunAll:
                    default:
                        tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T>(data.GetRange(c * i++, c + re), pack: (0,l)))));
                        break;
                }
            }

            if(tasks.Any())
                await Task.WhenAll(tasks);              
        }
        private static int count(int count, ref int lots)
        {
            bool n = count < lots;
            int m = Math.Abs(count - lots), cc = n ? 1 : (count / lots);
            lots = lots - (n ? m : 0);
            return cc;
        }
        #endregion

        private static IEnumerable<int> range(int start, int count)
        {
            int num = start + count - 1;
            if (count < 0 || num > int.MaxValue)
            {
                throw new ArgumentException("count");
            }
            return rangeIterator(start, count);
            IEnumerable<int> rangeIterator(int s, int c)
            {
                for (int i = 0; i < c; i++)
                {
                    yield return s + i;
                }
            }
        }       

        public class ListEvent<T>
        {
            private readonly List<T> _data;
            private readonly int _container;
            private readonly ProcessType _processType = ProcessType.Default;
            public ListEvent(List<T> data, int container = 0) => (_data, _container) = (data, container);
            public ListEvent(ProcessType processType, List<T> data, int container = 0) => (_processType, _data, _container) = (processType, data, container);

            #region RunAsync - Func<TupleEventHandler<List<T>>>
            public async Task EventAsync(params Func<ListEventHandler<T>>[] events)
            {
                if (!events.Any()) return;
                int i = 0, l = -1, lots = events.Count(), c = count(_data.Count, ref lots);
                
                List<Task> tasks = new List<Task>();

                foreach (Func<ListEventHandler<T>> ev in events) 
                {
                    ListEventHandler<T> handler = ev.Invoke();
                    int re = (++l == events.Count() ? _data.Count % lots : 0);

                    switch (_processType)
                    {                    
                        case ProcessType.Enqueue:
                            await Task.Run(() => handler?.Invoke(null, new ListEventArgs<T>(_data.GetRange(c * i++, c + re), pack: (_container, l))));                            
                            break;
                        case ProcessType.RunAll:
                        default:
                            tasks.Add(Task.Factory.StartNew(() => handler?.Invoke(null, new ListEventArgs<T>(_data.GetRange(c * i++, c + re), pack: (_container, l)))));                            
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