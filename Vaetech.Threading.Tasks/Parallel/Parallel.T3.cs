using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult.Events;

namespace Vaetech.Threading.Tasks
{
    public class Parallel<T, T1, T2, T3>
    {
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandler;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerOne;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerTwo;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerThree;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerFour;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerFive;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerSix;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerSeven;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerEight;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerNine;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerTen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerEleven;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerTwelve;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerThirteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerFourteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerFifteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerSixteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerSeventeen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerEighteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerNineteen;
        public event DynamicEventHandler<IEnumerable<T>, T1, T2, T3> _dynamicEventHandlerTwenty;
        public void InitParallel(Processors processors, List<T> list, T1 item1, T2 item2, T3 item3)
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
                        Parallel.Invoke(
                            () => OnSendParameters(1, list, item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Two:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), list.Count - (process * 1)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Three:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), list.Count - (process * 2)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), list.Count - (process * 3)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), list.Count - (process * 4)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), list.Count - (process * 5)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), list.Count - (process * 6)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), list.Count - (process * 7)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), list.Count - (process * 8)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), list.Count - (process * 9)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), list.Count - (process * 10)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), list.Count - (process * 11)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), list.Count - (process * 12)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), list.Count - (process * 13)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), list.Count - (process * 14)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), process), item1, item2, item3),
                            () => OnSendParameters(16, list.GetRange((process * 15), list.Count - (process * 15)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), process), item1, item2, item3),
                            () => OnSendParameters(16, list.GetRange((process * 15), process), item1, item2, item3),
                            () => OnSendParameters(17, list.GetRange((process * 16), list.Count - (process * 16)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), process), item1, item2, item3),
                            () => OnSendParameters(16, list.GetRange((process * 15), process), item1, item2, item3),
                            () => OnSendParameters(17, list.GetRange((process * 16), process), item1, item2, item3),
                            () => OnSendParameters(18, list.GetRange((process * 17), list.Count - (process * 17)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), process), item1, item2, item3),
                            () => OnSendParameters(16, list.GetRange((process * 15), process), item1, item2, item3),
                            () => OnSendParameters(17, list.GetRange((process * 16), process), item1, item2, item3),
                            () => OnSendParameters(18, list.GetRange((process * 17), process), item1, item2, item3),
                            () => OnSendParameters(19, list.GetRange((process * 18), list.Count - (process * 18)), item1, item2, item3)
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process), item1, item2, item3),
                            () => OnSendParameters(2, list.GetRange((process * 1), process), item1, item2, item3),
                            () => OnSendParameters(3, list.GetRange((process * 2), process), item1, item2, item3),
                            () => OnSendParameters(4, list.GetRange((process * 3), process), item1, item2, item3),
                            () => OnSendParameters(5, list.GetRange((process * 4), process), item1, item2, item3),
                            () => OnSendParameters(6, list.GetRange((process * 5), process), item1, item2, item3),
                            () => OnSendParameters(7, list.GetRange((process * 6), process), item1, item2, item3),
                            () => OnSendParameters(8, list.GetRange((process * 7), process), item1, item2, item3),
                            () => OnSendParameters(9, list.GetRange((process * 8), process), item1, item2, item3),
                            () => OnSendParameters(10, list.GetRange((process * 9), process), item1, item2, item3),
                            () => OnSendParameters(11, list.GetRange((process * 10), process), item1, item2, item3),
                            () => OnSendParameters(12, list.GetRange((process * 11), process), item1, item2, item3),
                            () => OnSendParameters(13, list.GetRange((process * 12), process), item1, item2, item3),
                            () => OnSendParameters(14, list.GetRange((process * 13), process), item1, item2, item3),
                            () => OnSendParameters(15, list.GetRange((process * 14), process), item1, item2, item3),
                            () => OnSendParameters(16, list.GetRange((process * 15), process), item1, item2, item3),
                            () => OnSendParameters(17, list.GetRange((process * 16), process), item1, item2, item3),
                            () => OnSendParameters(18, list.GetRange((process * 17), process), item1, item2, item3),
                            () => OnSendParameters(19, list.GetRange((process * 18), process), item1, item2, item3),
                            () => OnSendParameters(20, list.GetRange((process * 19), list.Count - (process * 19)), item1, item2, item3)
                        );
                    }
                    break;
            }
        }
        private void OnSendParameters(int process, IEnumerable<T> list, T1 item1, T2 item2, T3 item3)
        {
            if (_dynamicEventHandler != null)
                _dynamicEventHandler(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));

            switch ((Processors)process)
            {
                case Processors.One:
                    if (_dynamicEventHandlerOne != null)
                        _dynamicEventHandlerOne(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Two:
                    if (_dynamicEventHandlerTwo != null)
                        _dynamicEventHandlerTwo(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Three:
                    if (_dynamicEventHandlerThree != null)
                        _dynamicEventHandlerThree(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Four:
                    if (_dynamicEventHandlerFour != null)
                        _dynamicEventHandlerFour(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Five:
                    if (_dynamicEventHandlerFive != null)
                        _dynamicEventHandlerFive(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Six:
                    if (_dynamicEventHandlerSix != null)
                        _dynamicEventHandlerSix(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Seven:
                    if (_dynamicEventHandlerSeven != null)
                        _dynamicEventHandlerSeven(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Eight:
                    if (_dynamicEventHandlerEight != null)
                        _dynamicEventHandlerEight(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Nine:
                    if (_dynamicEventHandlerNine != null)
                        _dynamicEventHandlerNine(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Ten:
                    if (_dynamicEventHandlerTen != null)
                        _dynamicEventHandlerTen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Eleven:
                    if (_dynamicEventHandlerEleven != null)
                        _dynamicEventHandlerEleven(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Twelve:
                    if (_dynamicEventHandlerTwelve != null)
                        _dynamicEventHandlerTwelve(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Thirteen:
                    if (_dynamicEventHandlerThirteen != null)
                        _dynamicEventHandlerThirteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Fourteen:
                    if (_dynamicEventHandlerFourteen != null)
                        _dynamicEventHandlerFourteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Fifteen:
                    if (_dynamicEventHandlerFifteen != null)
                        _dynamicEventHandlerFifteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Sixteen:
                    if (_dynamicEventHandlerSixteen != null)
                        _dynamicEventHandlerSixteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Seventeen:
                    if (_dynamicEventHandlerSeventeen != null)
                        _dynamicEventHandlerSeventeen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Eighteen:
                    if (_dynamicEventHandlerEighteen != null)
                        _dynamicEventHandlerEighteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Nineteen:
                    if (_dynamicEventHandlerNineteen != null)
                        _dynamicEventHandlerNineteen(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
                case Processors.Twenty:
                    if (_dynamicEventHandlerTwenty != null)
                        _dynamicEventHandlerTwenty(this, new DynamicEventArgs<IEnumerable<T>, T1, T2, T3>(list, item1, item2, item3));
                    break;
            }
        }
    }
}