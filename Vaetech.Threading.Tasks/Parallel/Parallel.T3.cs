using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult.Events;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!
* Owners: Liiksoft
* Create by Luis Eduardo Cochachi Chamorro
* License: MIT or Apache-2.0
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!*/
namespace Vaetech.Threading.Tasks
{
    public class Parallel<T, T1, T2, T3>
    {
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandler;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerOne;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerTwo;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerThree;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerFour;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerFive;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerSix;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerSeven;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerEight;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerNine;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerTen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerEleven;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerTwelve;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerThirteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerFourteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerFifteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerSixteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerSeventeen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerEighteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerNineteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> DynamicEventHandlerTwenty;
        public void Run(Processors processors, List<T> list, T1 item1, T2 item2, T3 item3)
        {
            if (list == null)
                return;

            if (processors == Processors.None)
                processors = Processors.One;

            var process = (int)processors == 0 ? 0 : Convert.ToInt32(list.Count / (int)processors);

            switch (processors)
            {
                case Processors.One:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(() => (OnSendParameters(1, list, item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)));
                    }
                    break;
                case Processors.Two:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, list.Count - process * 1), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Three:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, list.Count - process * 2), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, list.Count - process * 3), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, list.Count - process * 4), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, list.Count - process * 5), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, list.Count - process * 6), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, list.Count - process * 7), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, list.Count - process * 8), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, list.Count - process * 9), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, list.Count - process * 10), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, list.Count - process * 11), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, list.Count - process * 12), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, list.Count - process * 13), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, list.Count - process * 14), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, list.Count - process * 15), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, list.Count - process * 16), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, list.Count - process * 17), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParameters(19, list.GetRange(process * 18, list.Count - process * 18), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNineteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        Parallel.InvokeEvent<T, T1, T2, T3>(
                            () => (OnSendParameters(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParameters(19, list.GetRange(process * 18, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNineteen?.Invoke(null, e)),
                            () => (OnSendParameters(20, list.GetRange(process * 19, list.Count - process * 19), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwenty?.Invoke(null, e))
                        );
                    }
                    break;
            }
        }
        public async Task RunAsync(Processors processors, List<T> list, T1 item1, T2 item2, T3 item3)
        {
            if (list == null)
                return;

            if (processors == Processors.None)
                processors = Processors.One;

            var process = (int)processors == 0 ? 0 : Convert.ToInt32(list.Count / (int)processors);
            List<T> ls = new List<T>();

            switch (processors)
            {
                case Processors.One:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(() => (OnSendParametersAsync(1, list, item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)));
                    }
                    break;
                case Processors.Two:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, list.Count - process * 1), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Three:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, list.Count - process * 2), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, list.Count - process * 3), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, list.Count - process * 4), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, list.Count - process * 5), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, list.Count - process * 6), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, list.Count - process * 7), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, list.Count - process * 8), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, list.Count - process * 9), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, list.Count - process * 10), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, list.Count - process * 11), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, list.Count - process * 12), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, list.Count - process * 13), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, list.Count - process * 14), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, list.Count - process * 15), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, list.Count - process * 16), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, list.Count - process * 17), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(19, list.GetRange(process * 18, list.Count - process * 18), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNineteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        await Parallel.InvokeEventAsync<T, T1, T2, T3>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(19, list.GetRange(process * 18, process), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerNineteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(20, list.GetRange(process * 19, list.Count - process * 19), item1, item2, item3), item1, item2, item3, (e) => DynamicEventHandlerTwenty?.Invoke(null, e))
                        );
                    }
                    break;
            }
        }
        private IEnumerable<T> OnSendParameters(int process, IEnumerable<T> list, T1 item1, T2 item2, T3 item3)
        {
            DynamicEventHandler?.Invoke(null, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
            return list;
        }
        private async Task<IEnumerable<T>> OnSendParametersAsync(int process, IEnumerable<T> list, T1 item1, T2 item2, T3 item3)
        {
            return await Task.Run(() =>
            {
                DynamicEventHandler?.Invoke(null, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                return list;
            });
        }
    }
}