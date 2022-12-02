using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult.Events;
using Xunit;

namespace Vaetech.Threading.Tasks.Test
{
    public class UnitTest1
    {
        #region ListEventTest
        [Fact]
        public async Task SplitAsync1()
        {
            int[] values = Enumerable.Range(0, 10).ToArray();

            // It splits the List between the number of batches and sends them to new instances of the instantiated event.
            await Parallel.SplitAsync(ProcessType.RunInOrder, values.ToList(), lots: 3, (s, e) =>
            {
                (int container, int lot) = e.Pack;
                Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                switch (lot)
                {
                    case 1:
                        Assert.Equal(3, e.List.Count());
                        break;
                    case 2:
                        Assert.Equal(3, e.List.Count());
                        break;
                    case 3:
                        Assert.Equal(4, e.List.Count());
                        break;
                }                
            });

            /* Output:                 
                container 1 lot 1:
                0
                1
                2
                container 1 lot 2:
                3
                4
                5
                container 1 lot 3:
                6
                7
                8
                9
             */
        }

        [Fact]
        public async Task SplitAsync2()
        {
            InitEvents();
            int[] values = Enumerable.Range(0, 11).ToArray();

            // 1. It splits the list by the number of instantiated events down (Horizontal).
            // 2. It splits the sublist by the number of instantiated events on the right (Vertical).
            await Parallel.SplitAsync(ProcessType.RunInOrder, values.ToList(),
            (rq) => rq.EventAsync(() => listEventHandlerGroupA_1, () => listEventHandlerGroupA_1_1),
            (rq) => rq.EventAsync(() => listEventHandlerGroupA_2),
            (rq) => rq.EventAsync(() => listEventHandlerGroupA_3),
            (rq) => rq.EventAsync(() => listEventHandlerGroupA_4),
            (rq) => rq.EventAsync(() => listEventHandlerGroupA_5)
            );

            /* Output:            
                container 1 lot 1:
                0
                container 1 lot 2:
                1
                container 2 lot 1:
                2
                3
                container 3 lot 1:
                4
                5
                container 4 lot 1:
                6
                7
                container 5 lot 1:
                8
                9
                10
            */
        }
        private void InitEvents()
        {
            listEventHandlerGroupA_1 += (s, e) =>
            {                
                Assert.Equal((0,0), e.Pack);
                Assert.True(e.List.Count() == 1);
            };
            listEventHandlerGroupA_1_1 += (s, e) =>
            {
                Assert.Equal((0, 1), e.Pack);
                Assert.True(e.List.Count() == 1);
            };
            listEventHandlerGroupA_2 += (s, e) =>
            {
                Assert.Equal((1, 0), e.Pack);
                Assert.True(e.List.Count() == 2);
            };
            listEventHandlerGroupA_3 += (s, e) =>
            {
                Assert.Equal((2, 0), e.Pack);
                Assert.True(e.List.Count() == 2);
            };
            listEventHandlerGroupA_4 += (s, e) =>
            {
                Assert.Equal((3, 0), e.Pack);
                Assert.True(e.List.Count() == 2);
            };
            listEventHandlerGroupA_5 += (s, e) =>
            {
                Assert.Equal((4, 0), e.Pack);
                Assert.True(e.List.Count() == 3);
            };
        }

        public ListEventHandler<int> listEventHandlerGroupA_1;
        public ListEventHandler<int> listEventHandlerGroupA_1_1;
        public ListEventHandler<int> listEventHandlerGroupA_2;
        public ListEventHandler<int> listEventHandlerGroupA_3;
        public ListEventHandler<int> listEventHandlerGroupA_4;
        public ListEventHandler<int> listEventHandlerGroupA_5;
        #endregion
    }
}
