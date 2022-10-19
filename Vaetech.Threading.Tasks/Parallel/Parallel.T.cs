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
    public class Parallel<T>
    {        
        public void Run(Processors processors, List<T> list)
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
                        Parallel.InvokeEvent<T>(() => (OnSendParameters(1, list), (e) => DynamicEventHandlerOne?.Invoke(null,e)));
                    }
                    break;
                case Processors.Two:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, list.Count - process * 1)), (e) => DynamicEventHandlerTwo?.Invoke(null, e))
                        );                        
                    }
                    break;
                case Processors.Three:
                    {                        
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, list.Count - process * 2)), (e) => DynamicEventHandlerThree?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, list.Count - process * 3)), (e) => DynamicEventHandlerFour?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, list.Count - process * 4)), (e) => DynamicEventHandlerFive?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, list.Count - process * 5)), (e) => DynamicEventHandlerSix?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, list.Count - process * 6)), (e) => DynamicEventHandlerSeven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, list.Count - process * 7)), (e) => DynamicEventHandlerEight?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, list.Count - process * 8)), (e) => DynamicEventHandlerNine?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, list.Count - process * 9)), (e) => DynamicEventHandlerTen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, list.Count - process * 10)), (e) => DynamicEventHandlerEleven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, list.Count - process * 11)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, list.Count - process * 12)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, list.Count - process * 13)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, list.Count - process * 14)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, list.Count - process * 15)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, list.Count - process * 16)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, list.Count - process * 17)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, process)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParameters(19, list.GetRange(process * 18, list.Count - process * 18)), (e) => DynamicEventHandlerNineteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        Parallel.InvokeEvent<T>(
                            () => (OnSendParameters(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParameters(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParameters(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParameters(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParameters(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParameters(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParameters(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParameters(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParameters(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParameters(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParameters(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParameters(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParameters(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParameters(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParameters(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParameters(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParameters(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParameters(18, list.GetRange(process * 17, process)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParameters(19, list.GetRange(process * 18, process)), (e) => DynamicEventHandlerNineteen?.Invoke(null, e)),
                            () => (OnSendParameters(20, list.GetRange(process * 19, list.Count - process * 19)), (e) => DynamicEventHandlerTwenty?.Invoke(null, e))
                        );
                    }
                    break;
            }
        }
        public async Task RunAsync(Processors processors, List<T> list)
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
                        await Parallel.InvokeEventAsync<T>(() => (OnSendParametersAsync(1, list), (e) => DynamicEventHandlerOne?.Invoke(null, e)));
                    }
                    break;
                case Processors.Two:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, list.Count - process * 1)), (e) => DynamicEventHandlerTwo?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Three:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, list.Count - process * 2)), (e) => DynamicEventHandlerThree?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Four:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, list.Count - process * 3)), (e) => DynamicEventHandlerFour?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Five:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, list.Count - process * 4)), (e) => DynamicEventHandlerFive?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Six:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, list.Count - process * 5)), (e) => DynamicEventHandlerSix?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seven:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, list.Count - process * 6)), (e) => DynamicEventHandlerSeven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eight:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, list.Count - process * 7)), (e) => DynamicEventHandlerEight?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nine:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, list.Count - process * 8)), (e) => DynamicEventHandlerNine?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Ten:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, list.Count - process * 9)), (e) => DynamicEventHandlerTen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eleven:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, list.Count - process * 10)), (e) => DynamicEventHandlerEleven?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twelve:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, list.Count - process * 11)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Thirteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, list.Count - process * 12)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fourteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, list.Count - process * 13)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Fifteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, list.Count - process * 14)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Sixteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, list.Count - process * 15)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Seventeen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, list.Count - process * 16)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Eighteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, list.Count - process * 17)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Nineteen:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, process)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(19, list.GetRange(process * 18, list.Count - process * 18)), (e) => DynamicEventHandlerNineteen?.Invoke(null, e))
                        );
                    }
                    break;
                case Processors.Twenty:
                    {
                        await Parallel.InvokeEventAsync<T>(
                            () => (OnSendParametersAsync(1, list.GetRange(0, process)), (e) => DynamicEventHandlerOne?.Invoke(null, e)),
                            () => (OnSendParametersAsync(2, list.GetRange(process * 1, process)), (e) => DynamicEventHandlerTwo?.Invoke(null, e)),
                            () => (OnSendParametersAsync(3, list.GetRange(process * 2, process)), (e) => DynamicEventHandlerThree?.Invoke(null, e)),
                            () => (OnSendParametersAsync(4, list.GetRange(process * 3, process)), (e) => DynamicEventHandlerFour?.Invoke(null, e)),
                            () => (OnSendParametersAsync(5, list.GetRange(process * 4, process)), (e) => DynamicEventHandlerFive?.Invoke(null, e)),
                            () => (OnSendParametersAsync(6, list.GetRange(process * 5, process)), (e) => DynamicEventHandlerSix?.Invoke(null, e)),
                            () => (OnSendParametersAsync(7, list.GetRange(process * 6, process)), (e) => DynamicEventHandlerSeven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(8, list.GetRange(process * 7, process)), (e) => DynamicEventHandlerEight?.Invoke(null, e)),
                            () => (OnSendParametersAsync(9, list.GetRange(process * 8, process)), (e) => DynamicEventHandlerNine?.Invoke(null, e)),
                            () => (OnSendParametersAsync(10, list.GetRange(process * 9, process)), (e) => DynamicEventHandlerTen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(11, list.GetRange(process * 10, process)), (e) => DynamicEventHandlerEleven?.Invoke(null, e)),
                            () => (OnSendParametersAsync(12, list.GetRange(process * 11, process)), (e) => DynamicEventHandlerTwelve?.Invoke(null, e)),
                            () => (OnSendParametersAsync(13, list.GetRange(process * 12, process)), (e) => DynamicEventHandlerThirteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(14, list.GetRange(process * 13, process)), (e) => DynamicEventHandlerFourteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(15, list.GetRange(process * 14, process)), (e) => DynamicEventHandlerFifteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(16, list.GetRange(process * 15, process)), (e) => DynamicEventHandlerSixteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(17, list.GetRange(process * 16, process)), (e) => DynamicEventHandlerSeventeen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(18, list.GetRange(process * 17, process)), (e) => DynamicEventHandlerEighteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(19, list.GetRange(process * 18, process)), (e) => DynamicEventHandlerNineteen?.Invoke(null, e)),
                            () => (OnSendParametersAsync(20, list.GetRange(process * 19, list.Count - process * 19)), (e) => DynamicEventHandlerTwenty?.Invoke(null, e))
                        );
                    }
                    break;
            }
        }
        private IEnumerable<T> OnSendParameters(int process, IEnumerable<T> list)
        {            
            DynamicEventHandler?.Invoke(null, new DynamicEventArgs<IEnumerable<T>>(list));
            return list;
        }
        private async Task<IEnumerable<T>> OnSendParametersAsync(int process, IEnumerable<T> list)
        {
            return await Task.Run(() =>
            {                
                DynamicEventHandler?.Invoke(null, new DynamicEventArgs<IEnumerable<T>>(list));
                return list;
            });
        }

        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandler;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerOne;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerTwo;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerThree;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerFour;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerFive;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerSix;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerSeven;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerEight;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerNine;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerTen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerEleven;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerTwelve;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerThirteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerFourteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerFifteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerSixteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerSeventeen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerEighteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerNineteen;
        public event DynamicEventHandler<IEnumerable<T>> DynamicEventHandlerTwenty;
    }
}
