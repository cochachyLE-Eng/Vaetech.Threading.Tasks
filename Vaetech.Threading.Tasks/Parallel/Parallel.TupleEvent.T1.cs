using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult.Events;

namespace Vaetech.Threading.Tasks
{
    public partial class Parallel
    {
        #region WorkerAsync - Func<TupleEvent<T1,T2>, Task>[]
        public static async Task WorkerAsync<T1, T2>(List<T1> data1, List<T2> data2, params Func<TupleEvent<T1, T2>, Task>[] actions)
            => await WorkerAsync<T1, T2>(ProcessType.Default, data1, data2, actions);
        public static async Task WorkerAsync<T1, T2>(ProcessType typeProcess, List<T1> data1, List<T2> data2, params Func<TupleEvent<T1, T2>, Task>[] actions)
        {
            switch (typeProcess)
            {
                case ProcessType.RunInOrder:
                    {
                        foreach (Func<TupleEvent<T1, T2>, Task> action in actions)
                            await action(new TupleEvent<T1, T2>(typeProcess, data1, data2));
                    }
                    break;
                case ProcessType.RunAll:
                default:
                    {
                        List<Task> tasks = new List<Task>();

                        foreach (Func<TupleEvent<T1, T2>, Task> action in actions)
                            tasks.Add(action(new TupleEvent<T1, T2>(typeProcess, data1, data2)));

                        await Task.WhenAll(tasks);
                    }
                    break;
            }
        }
        #endregion

        public class TupleEvent<T1,T2>
        {
            private readonly List<T1> _data1;
            private readonly List<T2> _data2;            
            private readonly ProcessType _processType = ProcessType.Default;
            public TupleEvent(List<T1> data1, List<T2> data2) => (_data1, _data2) = (data1, data2);
            public TupleEvent(ProcessType processType, List<T1> data1, List<T2> data2) => (_processType, _data1, _data2) = (processType, data1, data2);

            #region RunAsync - Func<(TupleEventHandler<List<T1>> e1, TupleEventHandler<List<T2>>e2)>[]
            public async Task TupleEventAsync(params Func<(TupleEventHandler<List<T1>> e1, TupleEventHandler<List<T2>>e2)>[] events)
            {
                if (!events.Any()) return;
                int i1 = 0, i2 = 0;
                int count1 = _data1.Count, count2 = _data2.Count;

                switch (_processType)
                {
                    case ProcessType.RunInOrder:
                        await Task.WhenAll(events.Select(el => {
                            var func = el.Invoke();
                            return Task.Run(() => (func.e1, func.e2) = ((s, e) => e = new TupleEventArgs<List<T1>>(_data1?.GetRange(count1 * i1++, count1)), (s, e) => e = new TupleEventArgs<List<T2>>(_data2?.GetRange(count2 * i2++, count2))));
                        }));
                        break;
                    case ProcessType.RunAll:
                    default:
                        await Task.WhenAll(events.Select(el => {
                            var func = el.Invoke();
                            return Task.Factory.StartNew(() => (func.e1, func.e2) = ((s, e) => e = new TupleEventArgs<List<T1>>(_data1?.GetRange(count1 * i1++, count1)), (s, e) => e = new TupleEventArgs<List<T2>>(_data2?.GetRange(count2 * i2++, count2))));
                        }));
                        break;
                }
            }
            #endregion

            #region RunAsync - (Func<TupleEventHandler<List<T1>>> e1, Func<TupleEventHandler<List<T2>>> e2)[]
            public async Task TupleEventAsync2(params (Func<TupleEventHandler<List<T1>>> e1, Func<TupleEventHandler<List<T2>>> e2)[] events)
            {
                int i1 = 0, i2 = 0;
                int count1 = _data1.Count, count2 = _data2.Count;
                
                switch (_processType)
                {
                    case ProcessType.RunInOrder:
                        await Task.WhenAll(events.Select(el => Task.Run(() => (el.e1, el.e2) = (() => (s, e) => e = new TupleEventArgs<List<T1>>(_data1?.GetRange(count1 * i1++, count1)), () => (s, e) => e = new TupleEventArgs<List<T2>>(_data2?.GetRange(count2 * i2++, count2))))));
                        break;
                    case ProcessType.RunAll:
                    default:
                        await Task.WhenAll(events.Select(el => Task.Factory.StartNew(() => (el.e1, el.e2) = (() => (s, e) => e = new TupleEventArgs<List<T1>>(_data1?.GetRange(count1 * i1++, count1)), () => (s, e) => e = new TupleEventArgs<List<T2>>(_data2?.GetRange(count2 * i2++, count2))))));
                        break;
                }
            }
            #endregion
        }
    }
}