using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult.Events;

namespace Vaetech.Threading.Tasks
{
    public class Parallel<T>
    {
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandler;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerOne;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerTwo;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerThree;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerFour;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerFive;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerSix;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerSeven;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerEight;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerNine;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerTen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerEleven;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerTwelve;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerThirteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerFourteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerFifteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerSixteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerSeventeen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerEighteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerNineteen;
        public event DynamicEventHandler<IEnumerable<T>> _dynamicEventHandlerTwenty;
        public void InitParallel(Processors processors, List<T> list)
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
                        Parallel.Invoke(() => OnSendParameters(1, list));                       
                    }
                    break;
                case Processors.Two:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), list.Count - (process * 1)))
                        );
                    }
                    break;
                case Processors.Three:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), list.Count - (process * 2)))
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), list.Count - (process * 3)))
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), list.Count - (process * 4)))
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), list.Count - (process * 5)))
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), list.Count - (process * 6)))
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), list.Count - (process * 7)))
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), list.Count - (process * 8)))
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), list.Count - (process * 9)))
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), list.Count - (process * 10)))
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), list.Count - (process * 11)))
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), list.Count - (process * 12)))
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), list.Count - (process * 13)))
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), list.Count - (process * 14)))
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), process)),
                            () => OnSendParameters(16, list.GetRange((process * 15), list.Count - (process * 15)))
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), process)),
                            () => OnSendParameters(16, list.GetRange((process * 15), process)),
                            () => OnSendParameters(17, list.GetRange((process * 16), list.Count - (process * 16)))
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), process)),
                            () => OnSendParameters(16, list.GetRange((process * 15), process)),
                            () => OnSendParameters(17, list.GetRange((process * 16), process)),
                            () => OnSendParameters(18, list.GetRange((process * 17), list.Count - (process * 17)))
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), process)),
                            () => OnSendParameters(16, list.GetRange((process * 15), process)),
                            () => OnSendParameters(17, list.GetRange((process * 16), process)),
                            () => OnSendParameters(18, list.GetRange((process * 17), process)),
                            () => OnSendParameters(19, list.GetRange((process * 18), list.Count - (process * 18)))
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        Parallel.Invoke(
                            () => OnSendParameters(1, list.GetRange((process * 0), process)),
                            () => OnSendParameters(2, list.GetRange((process * 1), process)),
                            () => OnSendParameters(3, list.GetRange((process * 2), process)),
                            () => OnSendParameters(4, list.GetRange((process * 3), process)),
                            () => OnSendParameters(5, list.GetRange((process * 4), process)),
                            () => OnSendParameters(6, list.GetRange((process * 5), process)),
                            () => OnSendParameters(7, list.GetRange((process * 6), process)),
                            () => OnSendParameters(8, list.GetRange((process * 7), process)),
                            () => OnSendParameters(9, list.GetRange((process * 8), process)),
                            () => OnSendParameters(10, list.GetRange((process * 9), process)),
                            () => OnSendParameters(11, list.GetRange((process * 10), process)),
                            () => OnSendParameters(12, list.GetRange((process * 11), process)),
                            () => OnSendParameters(13, list.GetRange((process * 12), process)),
                            () => OnSendParameters(14, list.GetRange((process * 13), process)),
                            () => OnSendParameters(15, list.GetRange((process * 14), process)),
                            () => OnSendParameters(16, list.GetRange((process * 15), process)),
                            () => OnSendParameters(17, list.GetRange((process * 16), process)),
                            () => OnSendParameters(18, list.GetRange((process * 17), process)),
                            () => OnSendParameters(19, list.GetRange((process * 18), process)),
                            () => OnSendParameters(20, list.GetRange((process * 19), list.Count - (process * 19)))
                        );
                    }
                    break;
            }
        }        
        private void OnSendParameters(int process, IEnumerable<T> list)
        {
            if (_dynamicEventHandler != null)
                _dynamicEventHandler(this, new DynamicEventArgs<IEnumerable<T>>(list));

            switch ((Processors)process)
            {
                case Processors.One:
                    if (_dynamicEventHandlerOne != null)
                        _dynamicEventHandlerOne(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Two:
                    if (_dynamicEventHandlerTwo != null)
                        _dynamicEventHandlerTwo(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Three:
                    if (_dynamicEventHandlerThree != null)
                        _dynamicEventHandlerThree(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Four:
                    if (_dynamicEventHandlerFour != null)
                        _dynamicEventHandlerFour(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Five:
                    if (_dynamicEventHandlerFive != null)
                        _dynamicEventHandlerFive(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Six:
                    if (_dynamicEventHandlerSix != null)
                        _dynamicEventHandlerSix(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Seven:
                    if (_dynamicEventHandlerSeven != null)
                        _dynamicEventHandlerSeven(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Eight:
                    if (_dynamicEventHandlerEight != null)
                        _dynamicEventHandlerEight(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Nine:
                    if (_dynamicEventHandlerNine != null)
                        _dynamicEventHandlerNine(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Ten:
                    if (_dynamicEventHandlerTen != null)
                        _dynamicEventHandlerTen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Eleven:
                    if (_dynamicEventHandlerEleven != null)
                        _dynamicEventHandlerEleven(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Twelve:
                    if (_dynamicEventHandlerTwelve != null)
                        _dynamicEventHandlerTwelve(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Thirteen:
                    if (_dynamicEventHandlerThirteen != null)
                        _dynamicEventHandlerThirteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Fourteen:
                    if (_dynamicEventHandlerFourteen != null)
                        _dynamicEventHandlerFourteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Fifteen:
                    if (_dynamicEventHandlerFifteen != null)
                        _dynamicEventHandlerFifteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Sixteen:
                    if (_dynamicEventHandlerSixteen != null)
                        _dynamicEventHandlerSixteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Seventeen:
                    if (_dynamicEventHandlerSeventeen != null)
                        _dynamicEventHandlerSeventeen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Eighteen:
                    if (_dynamicEventHandlerEighteen != null)
                        _dynamicEventHandlerEighteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Nineteen:
                    if (_dynamicEventHandlerNineteen != null)
                        _dynamicEventHandlerNineteen(this, new DynamicEventArgs<IEnumerable<T>>(list));
                    break;
                case Processors.Twenty:
                    _dynamicEventHandlerTwenty?.Invoke(null, new DynamicEventArgs<IEnumerable<T>>(list));                    
                    break;
            }            
        }
    }
}
