using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vaetech.Data.ContentResult;
using Vaetech.Data.ContentResult.Events;
using Parallel = Vaetech.Threading.Tasks.Parallel;

namespace Vaetech.Threading.Tasks.Console
{
    using ListEventT = Func<Parallel.ListEvent<byte>, Task>;
    class Program
    {

        static void Main(string[] args)
        {            
            System.Console.WriteLine("Hello World!");
            SplitEventAsync1().Wait();
            //Method5();
            //SampleMethodDynamicResultOption2Async().Wait();
            System.Console.ReadKey();             
        }                
        public static void Invoke()
        {
            ActionResult actionResult = Parallel.Invoke(() => SampleMethod("Process 0"));           

            if(actionResult.IbException)
                System.Console.WriteLine("[0] Error: {0}", actionResult.Message);
            else
                System.Console.WriteLine("[0] successful process!");
        }
        public static void InvokeAndRunAll()
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run All [1]");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Parallel.Invoke(ProcessType.RunAll,
                () => SampleMethod("[1] Process 1"),
                () => SampleMethod("[1] Process 2"),
                () => SampleMethod("[1] Process 3"),
                () => SampleMethod("[1] Process 4"),
                () => SampleMethod("[1] Process 5")
                );
            
            System.Console.WriteLine("[1] successful process!");
        }
        public static void InvokeAndRunInOrder()
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run RunInOrder [2] - Asynchronous");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Parallel.Invoke(ProcessType.Enqueue,
                () => SampleMethod("[2] Process 5"),
                () => SampleMethod("[2] Process 4"),
                () => SampleMethod("[2] Process 3"), 
                () => SampleMethod("[2] Process 2"),
                () => SampleMethod("[2] Process 1")
                );

            System.Console.WriteLine("[2] successful process!");
        }
        public static async Task InvokeAsync()
        {
            await Parallel.InvokeAsync(() => SampleMethodAsync("Async Process 0"));
            System.Console.WriteLine("[0] successful async process!");
        }        
        public static async Task InvokeAndRunAllAsync()
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run All [1] - Asynchronous");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            await Parallel.InvokeAsync(ProcessType.RunAll,
                () => SampleMethodAsync("[1] Process 1"),
                () => SampleMethodAsync("[1] Process 2"),
                () => SampleMethodAsync("[1] Process 3"),
                () => SampleMethodAsync("[1] Process 4"),
                () => SampleMethodAsync("[1] Process 5")
                );      
        }
        public static async Task InvokeAndRunInOrderAsync()
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run RunInOrder [2] - Asynchronous");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            await Parallel.InvokeAsync(ProcessType.Enqueue,
                () => SampleMethodAsync("[2] Process 5"),
                () => SampleMethodAsync("[2] Process 4"),
                () => SampleMethodAsync("[2] Process 3"),
                () => SampleMethodAsync("[2] Process 2"),
                () => SampleMethodAsync("[2] Process 1")
                );
        }
        public static void SampleMethod(string processName, int sleep= 3000)
        {
            System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
            Thread.Sleep(sleep);
            System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
        }
        public static DateTime[] SampleMethodWithResult(string processName, int sleep = 3000)
        {
            DateTime[] dateTimes = new DateTime[2];
            
            System.Console.WriteLine("begin {0} {1}", processName, (dateTimes[0] = DateTime.Now).ToString("hh:mm:ss fff"));
            Thread.Sleep(sleep);
            System.Console.WriteLine("end {0} {1}", processName, (dateTimes[1] = DateTime.Now).ToString("hh:mm:ss fff"));

            return dateTimes;
        }
        public static IEnumerable<DateTime> SampleMethodWithResult2(string processName, int sleep = 3000)
        {
            DateTime[] dateTimes = new DateTime[2];
            int nro = 0;
            int nro2 = 2 / nro;
            System.Console.WriteLine("begin {0} {1}", processName, (dateTimes[0] = DateTime.Now).ToString("hh:mm:ss fff"));
            Thread.Sleep(sleep);
            System.Console.WriteLine("end {0} {1}", processName, (dateTimes[1] = DateTime.Now).ToString("hh:mm:ss fff"));

            return dateTimes;
        }
        public static async Task SampleMethodAsync(string processName, int sleep = 3000)
        {
            await Task.Run(() => 
            {
                System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
                Thread.Sleep(sleep);
                System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));                
            });
        }
        public static async Task<DateTime[]> SampleMethodWithResultAsync(string processName, int sleep = 3000)
        {
            return await Task.Run(() => 
            {
                DateTime[] dateTimes = new DateTime[2];

                System.Console.WriteLine("begin {0} {1}", processName, (dateTimes[0] = DateTime.Now).ToString("hh:mm:ss fff"));
                Thread.Sleep(sleep);
                System.Console.WriteLine("end {0} {1}", processName, (dateTimes[1] = DateTime.Now).ToString("hh:mm:ss fff"));

                return dateTimes;
            }); 
        }
        // Execute all methods with different result at the same time.
        public static async Task SampleMethodDynamicResultAsync()
        {   
            await Parallel.InvokeAsync(ProcessType.RunAll,
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 1", 200), (ActionResult<DateTime[]> a) => { var value = a.Value; }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 2", 500), (ActionResult a) => { var value = (string[])a.Data; }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 3", 400), (ActionResult a) => { var value = (DateTime[])a.Data; }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 4", 300), (ActionResult a) => { var value = (string[])a.Data; })
            );
        }

        // Example method 1
        public static async Task<DateTime[]> SampleMethodWithResult1Async(string processName, int sleep = 3000)
        {
            return await Task.Run(() =>
            {
                DateTime[] dateTimes = new DateTime[2];

                System.Console.WriteLine("begin {0} {1}", processName, (dateTimes[0] = DateTime.Now).ToString("hh:mm:ss fff"));
                Thread.Sleep(sleep);
                System.Console.WriteLine("end {0} {1}", processName, (dateTimes[1] = DateTime.Now).ToString("hh:mm:ss fff"));

                return dateTimes;
            });
        }

        // Example method 2
        public static async Task<string[]> SampleMethodWithResult2Async(string processName, int sleep = 3000)
        {
            return await Task.Run(() =>
            {
                string[] dateTimes = new string[2];

                System.Console.WriteLine("begin {0} {1}", processName, dateTimes[0] = DateTime.Now.ToString("hh:mm:ss fff"));
                Thread.Sleep(sleep);
                System.Console.WriteLine("end {0} {1}", processName, dateTimes[1] = DateTime.Now.ToString("hh:mm:ss fff"));

                return dateTimes;
            });
        }
        public static void Method4()
        {            
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run All [3]");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Parallel.Invoke(ProcessType.RunAll,
                () => SampleMethod("[3] method1"),
                () => SampleMethod("[3] method2"),
                () => SampleMethod("[3] method3"),
                () => SampleMethod("[3] method4"),
                () => SampleMethod("[3] method5")
                );

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run RunInOrder [4]");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Parallel.Invoke(ProcessType.Enqueue,
                () => SampleMethod("[4] method5"),
                () => SampleMethod("[4] method4"),
                () => SampleMethod("[4] method3"),
                () => SampleMethod("[4] method2"),
                () => SampleMethod("[4] method1")
                );
        }

        public static async void Method5() {
            List<Task> tasks = new List<Task>();

            string data1 = null;
            string data2 = null;
            string data3 = null;
            string data4 = null;

            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("Run All [1] - Asynchronous");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            await Parallel.InvokeAsync(
                () => Method6("123", 200),
                () => Method7("123", 200),
                () => Method6("123", 200)
                );

            await Parallel.InvokeAsync(
                (rq) => rq.RunAsync(() => SampleMethodWithResultAsync("1", 200), (ActionResult a) => { var value = (DateTime[])a.Data; }),
                (rq) => rq.RunAsync(() => SampleMethodWithResultAsync("2", 200), (ActionResult a) => { var value = (DateTime[])a.Data; }),
                (rq) => rq.RunAsync(() => SampleMethodWithResultAsync("3", 200), (ActionResult a) => { var value = (DateTime[])a.Data; }),
                (rq) => rq.RunAsync(() => SampleMethodWithResultAsync("4", 200), (ActionResult a) => { var value = (DateTime[])a.Data; })
                );
            
            await Parallel.InvokeAsync(ProcessType.Enqueue,
               (rq) => rq.RunAsync(() => Method6("123", 2000), async (ActionResult a) =>
               {
                   System.Console.WriteLine("-> end [1] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
                   await Task.Delay(2000);
                   System.Console.WriteLine("-> end [2] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
               }),
               (rq) => rq.RunAsync(() => Method8("123", 200), async (ActionResult a) => 
               {
                   System.Console.WriteLine("-> end [1] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
                   await Task.Delay(2000);
                   System.Console.WriteLine("-> end [2] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
               }),
               (rq) => rq.RunAsync(() => Method6("123", 200), async (ActionResult a) =>
               {
                   System.Console.WriteLine("-> end [1] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
                   await Task.Delay(2000);
                   System.Console.WriteLine("-> end [2] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
               }),
               (rq) => rq.RunAsync(() => Method7("123", 200), async (ActionResult a) => 
               {
                   System.Console.WriteLine("-> end [1] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
                   await Task.Delay(2000);
                   System.Console.WriteLine("-> end [2] {0} {1}", a.Data, DateTime.Now.ToString("hh:mm:ss ffff"));
               })
               );

            System.Console.WriteLine("data1: {0}", data1);
            System.Console.WriteLine("data2: {0}", data2);
            System.Console.WriteLine("data3: {0}", data3);
            System.Console.WriteLine("data4: {0}", data4);
        }
        // Execute all methods with different result at the same time.
        public static async Task SampleMethodDynamicResultOption1Async()
        {
            await Parallel.InvokeAsync(ProcessType.RunAll,
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 1", 200), (ActionResult<DateTime[]> a) => 
            {
                DateTime[] value = a.Value;
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 2", 500), (ActionResult<string[]> b) =>
            {
                string[] value = b.Value;
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 3", 400), (ActionResult c) =>
            {
                DateTime[] value = c.Data;
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 4", 300), (ActionResult<string[]> d) =>
            {
                if (d.IbException)
                    System.Console.WriteLine("Error: {0}", d.Message);
                else
                {
                    string[] value = d.Data;
                }
            })
            );
        }
        // Execute all methods with different result at the same time.        
        public static async Task SampleMethodDynamicResultOption2Async()
        {            
            await Parallel.InvokeAsync(ProcessType.RunAll,
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 1", 200), (ActionResult a) => 
            { 
                var value = (DateTime[])a.Data; 
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 2", 500), (ActionResult a) => 
            { 
                var value = (string[])a.Data; 
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult1Async("[1] Process 3", 400), (ActionResult a) => 
            { 
                var value = (DateTime[])a.Data; 
            }),
            (rq) => rq.RunAsync(() => SampleMethodWithResult2Async("[2] Process 4", 300), (ActionResult a) => 
            { 
                var value = (string[])a.Data; 
            })
            );
        }

        public static async Task<ActionResult<string>> Method6(string processName, int sleep = 3000)
        {
            System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss ffff"));
            await Task.Delay(sleep);
            return await Task.Run(() => new ActionResult<string>(processName));
        }
        public static async Task<ActionResult<DateTime[]>> Method7(string processName, int sleep = 3000)
        {
            DateTime[] dateTimes = new DateTime[2];
            dateTimes[0] = DateTime.Now;

            System.Console.WriteLine("begin {0} {1}", processName, dateTimes[0].ToString("hh:mm:ss ffff"));
            await Task.Delay(sleep);
            dateTimes[1] = DateTime.Now;
            System.Console.WriteLine("end {0} {1}", processName, dateTimes[1].ToString("hh:mm:ss ffff"));

            return await Task.Run(() => new ActionResult<DateTime[]>(dateTimes));
        }
        public static async Task<DateTime[]> Method8(string processName, int sleep = 3000)
        {
            DateTime[] dateTimes = new DateTime[2];
            dateTimes[0] = DateTime.Now;

            System.Console.WriteLine("begin {0} {1}", processName, dateTimes[0].ToString("hh:mm:ss ffff"));
            await Task.Delay(sleep);
            dateTimes[1] = DateTime.Now;
            System.Console.WriteLine("end {0} {1}", processName, dateTimes[1].ToString("hh:mm:ss ffff"));

            return dateTimes;
        }
        public async Task<ActionResult<string>> MethodTestString1(int sleep)
        {
            return await Task.Run(() => new ActionResult<string>("1"));
        }
        public async Task<ActionResult<int>> MethodTest4_1(int sleep)
        {
            return await Task.Run(() => new ActionResult<int>(sleep));
        }
        public async Task<string> MethodTestString(int sleep)
        {
            return await Task.Run(() => "1");
        }
        public async Task<int> MethodTest4(int sleep)
        {
            return await Task.Run(() => 1);
        }
        public async Task<ActionResult<DemoClass>> MethodTest4_2(int sleep)
        {
            return await Task.Run(() => new ActionResult<DemoClass>(sleep));
        }
        public async Task<IEnumerable<DemoClass>> MethodTest4_3(int sleep)
        {
            return await Task.Run(() => new List<DemoClass>());
        }
        public async Task<IEnumerable<string>> MethodTest4_4(int sleep)
        {
            return await Task.Run(() => new List<string>());
        }
        public async Task<IList<string>> MethodTest4_5(int sleep)
        {
            return await Task.Run(() => new List<string>());
        }
        public async Task<ICollection<string>> MethodTest4_6(int sleep)
        {
            return await Task.Run(() => new List<string>());
        }
        public async Task MethodTestEx()
        {            
            await Parallel.InvokeAsync(ProcessType.Enqueue,
                (rq) => rq.RunAsync(() => MethodTestString(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTestString1(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_1(3), (ActionResult<int> rs) => { })
                );
        }
        public async Task MethodTest()
        {
            await Parallel.InvokeAsync(ProcessType.Enqueue,
                (rq) => rq.RunAsync(() => MethodTestString(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTestString1(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_1(3), (ActionResult<int> rs) => { })
                );

            await Parallel.InvokeAsync(ProcessType.Enqueue,
                (rq) => rq.RunAsync(() => MethodTestString1(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_1(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_1(3), (ActionResult<int> rs) => { })
                );            

            await Parallel.InvokeAsync(ProcessType.Enqueue, (rq) => rq.RunAsync<DemoClass>(() => MethodTest4_2(3), (ActionResult<DemoClass> a) => { }));
            await Parallel.InvokeAsync(ProcessType.Enqueue, (rq) => rq.RunAsync<int>(() => MethodTest4_1(3), (ActionResult<int> a) => { }));
            await Parallel.InvokeAsync(ProcessType.Enqueue, (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> a) => { }));                       

            await Parallel.InvokeAsync(ProcessType.Enqueue,
                (rq) => rq.RunAsync<DemoClass>(() => MethodTest4_2(3), (ActionResult<DemoClass> rs) => { }),
                (rq) => rq.RunAsync<int>(() => MethodTest4_1(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4(3), (ActionResult<int> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_3(3), (ActionResult<DemoClass> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_4(3), (ActionResult<string> rs) => { }),
                (rq) => rq.RunAsync(() => MethodTest4_5(3), (ActionResult<string> rs) => { })
                );
        }

        #region ListEventTest
        
        public static async Task SplitEventAsync1()
        {
            int[] values = Enumerable.Range(0, 10).ToArray();                       

            // It splits the List between the number of batches and sends them to new instances of the instantiated event.
            await Parallel.SplitEventAsync(ProcessType.Enqueue, values.ToList(), lots: 3, (s, e) =>
            {
                (int container, int lot) = e.Pack;
                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
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
        public static async Task SplitEventAsync2()
        {
            InitEvents();
            int[] values = Enumerable.Range(0, 10).ToArray();

            // 1. It splits the list by the number of instantiated events down (Horizontal).
            // 2. It splits the sublist by the number of instantiated events on the right (Vertical).
            await Parallel.SplitEventAsync(ProcessType.Enqueue,values.ToList(),
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
            */
        }
        public static void InitEvents() {
            listEventHandlerGroupA_1 += (s, e) => {                
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
            listEventHandlerGroupA_1_1 += (s, e) => {
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
            listEventHandlerGroupA_2 += (s, e) => {
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
            listEventHandlerGroupA_3 += (s, e) => {
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
            listEventHandlerGroupA_4 += (s, e) => {
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
            listEventHandlerGroupA_5 += (s, e) => {
                (int container, int lot) = e.Pack;

                System.Console.WriteLine("container {0} lot {1}:", ++container, ++lot);

                foreach (var i in e.List)
                {
                    Thread.Sleep(100);
                    System.Console.WriteLine(i);
                }
            };
        }
        
        public static ListEventHandler<int> listEventHandlerGroupA_1;
        public static ListEventHandler<int> listEventHandlerGroupA_1_1;
        public static ListEventHandler<int> listEventHandlerGroupA_2;
        public static ListEventHandler<int> listEventHandlerGroupA_3;
        public static ListEventHandler<int> listEventHandlerGroupA_4;
        public static ListEventHandler<int> listEventHandlerGroupA_5;
        #endregion

        #region TupleEventTest
        public async Task TupleEventTest()
        {
            int[] values1 = Enumerable.Range(0, 1024).ToArray();
            int[] values2 = Enumerable.Range(0, 1024).ToArray();

            await Parallel.WorkerAsync(values1.ToList(), values2.ToList(),
                (rq) => rq.TupleEventAsync(() => (tupleEventHandlerGroupA_1, tupleEventHandlerGroupA_2), () => (tupleEventHandlerGroupA_1, tupleEventHandlerGroupA_2))
                );

            await Parallel.WorkerAsync(values1.ToList(), values2.ToList(),
                (rq) => rq.TupleEventAsync2((() => tupleEventHandlerGroupA_1, () => tupleEventHandlerGroupA_2), (() => tupleEventHandlerGroupA_1, () => tupleEventHandlerGroupA_2)),
                (rq) => rq.TupleEventAsync2((() => tupleEventHandlerGroupB_1, () => tupleEventHandlerGroupB_2))
                );
        }
        public TupleEventHandler<List<int>> tupleEventHandlerGroupA_1;
        public TupleEventHandler<List<int>> tupleEventHandlerGroupA_2;
        public TupleEventHandler<List<int>> tupleEventHandlerGroupB_1;
        public TupleEventHandler<List<int>> tupleEventHandlerGroupB_2;
        #endregion
        public class DemoClass
        {
            public string data { get; set; }
        }
    }
}
