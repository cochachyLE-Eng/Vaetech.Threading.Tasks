﻿# Vaetech.Threading.Tasks

[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](code_of_conduct.md)

[![Join the chat at (https://badges.gitter.im/Vaetech-Threading-Tasks)](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Vaetech-Threading-Tasks/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

|    Package    |Latest Release|
|:--------------|:------------:|
|**Vaetech.Threading.Tasks**    |[![NuGet Badge Vaetech.Threading.Tasks](https://buildstats.info/nuget/Vaetech.Threading.Tasks)](https://www.nuget.org/packages/Vaetech.Threading.Tasks)

|   Platform   |Build Status|
|:-------------|:----------:|
|**Windows**   |[![dotnet](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-windows.yml/badge.svg)](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-windows.yml)|
|**MacOS**     |[![dotnet](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-macOS.yml/badge.svg)](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-macOS.yml)|
|**Linux**     |[![dotnet](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-ubuntu.yml/badge.svg)](https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks/actions/workflows/dotnet-ubuntu.yml)|


## What is Vaetech.Threading.Tasks?

Vaetech.Threading.Tasks is a C# library that can be used to execute Parallel.Async actions and retrieve the immediate response, before the task queue execution completes, in .Net Framework, .Net Standard and .Net Core

## License Information

```
MIT License

Copyright (C) 2021-2023 .NET Foundation and Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```

## Installing via NuGet

The easiest way to install Vaetech.Threading.Tasks is via [NuGet](https://www.nuget.org/packages/Vaetech.Threading.Tasks/).

In Visual Studio's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console),
enter the following command:

    Install-Package Vaetech.Threading.Tasks

## Getting the Source Code

First, you'll need to clone Vaetech.Threading.Tasks from my GitHub repository. To do this using the command-line version of Git,
you'll need to issue the following command in your terminal:

    git clone --recursive https://github.com/cochachyLE-Eng/Vaetech.Threading.Tasks.git

## Updating the Source Code

Occasionally you might want to update your local copy of the source code if I have made changes to Vaetech.Threading.Tasks since you
downloaded the source code in the step above. To do this using the command-line version fo Git, you'll need to issue
the following commands in your terminal within the Vaetech.Threading.Tasks directory:

    git pull
    git submodule update

## Building

In the top-level Vaetech.Threading.Tasks directory, there are a number of solution files; they are:

* **Vaetech.Threading.Tasks.sln** - includes projects for .NET 4.5/4.5.1/4.6.1/4.8, .NETStandard 2.1 as well as the unit tests.

Once you've opened the appropriate Vaetech.Threading.Tasks solution file in [Visual Studio](https://www.visualstudio.com/downloads/),
you can choose the **Debug** or **Release** build configuration and then build.

Both Visual Studio 2017 and Visual Studio 2019 should be able to build Vaetech.Threading.Tasks without any issues, but older versions such as
Visual Studio 2015 will require modifications to the projects in order to build correctly. It has been reported that adding
NuGet package references to 

[System.ValueTuple](https://www.nuget.org/packages/System.ValueTuple/) (>= 4.5.0) <br/>
[Vaetech.Data.ContentResult](https://www.nuget.org/packages/Vaetech.Data.ContentResult/) (>= 1.6.7) <br/>

will allow Vaetech.Threading.Tasks to build successfully.

## Using Vaetech.Threading.Tasks

### How can it be used?

There are two types of processes <code>RunAll</code> and <code>RunInOrder</code>. The default Process Type is <code>RunAll</code>.

| Type | Behavior |
| :---: | :--- |
|`RunAll`| Executes all the processes at the same time without respecting the order. This allows each terminated thread to work on the data without waiting for all tasks to complete.| 
|`RunInOrder`| Executes the process one by one in the order of input. This allows threads to be debugged in order of entry.|

### SplitAsync

It splits the List between the number of batches and sends them to new instances of the instantiated event.

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

public static async Task SplitAsync1()
{
    int[] values = Enumerable.Range(0, 10).ToArray();                       

    // It splits the List between the number of batches and sends them to new instances of the instantiated event.
    await Parallel.SplitAsync(ProcessType.RunInOrder, values.ToList(), lots: 3, (s, e) =>
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
```

1. It splits the list by the number of instantiated events down (Horizontal).
2. It splits the sublist by the number of instantiated events on the right (Vertical).

```csharp
public static async Task SplitAsync2()
{
    InitEvents();
    int[] values = Enumerable.Range(0, 11).ToArray();

    // 1. It splits the list by the number of instantiated events down (Horizontal).
    // 2. It splits the sublist by the number of instantiated events on the right (Vertical).
    await Parallel.SplitAsync(ProcessType.RunInOrder,values.ToList(),
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

public static async Task SplitAsync3()
{
    InitEvents();
    int[] values = Enumerable.Range(0, 16).ToArray();

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
        2
        container 2 lot 1:
        3
        4
        5
        container 3 lot 1:
        6
        7
        8
        container 4 lot 1:
        9
        10
        11
        container 5 lot 1:
        12
        13
        14
        15
    */
}
public static async Task SplitAsync4()
{
    InitEvents();
    int[] values = Enumerable.Range(0, 4).ToArray();

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
        container 2 lot 1:
        1
        container 3 lot 1:
        2
        container 4 lot 1:
        3
    */
}

public static void InitEvents() 
{
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
```

### Invoke and InvokeAsync

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

// Run all processes at the same time.
public static void InvokeAndRunAll()
{    
    Parallel.Invoke(ProcessType.RunAll,
        () => SampleMethod("[1] Process 1"),
        () => SampleMethod("[1] Process 2"),
        () => SampleMethod("[1] Process 3"),
        () => SampleMethod("[1] Process 4"),
        () => SampleMethod("[1] Process 5")
        );
    
    System.Console.WriteLine("[1] successful process!");
}

// Example method
public static void SampleMethod(string processName, int sleep = 3000)
{
    System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
    Thread.Sleep(sleep);
    System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
}
```

Run all processes in order of entry.

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

// Run all processes in order of entry.
public static void InvokeAndRunInOrder()
{    
    Parallel.Invoke(ProcessType.RunInOrder,
        () => SampleMethod("[2] Process 5"),
        () => SampleMethod("[2] Process 4"),
        () => SampleMethod("[2] Process 3"),
        () => SampleMethod("[2] Process 2"),
        () => SampleMethod("[2] Process 1")
        );

    System.Console.WriteLine("[2] successful process!");
}

// Example method
public static void SampleMethod(string processName, int sleep = 3000)
{
    System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
    Thread.Sleep(sleep);
    System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
}
```

Run all methods at the same time (Async)

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

// Run all methods at the same time (Async)
public static async Task InvokeAndRunAllAsync()
{    
    await Parallel.InvokeAsync(ProcessType.RunAll,
        () => SampleMethodAsync("[1] Process 1"),
        () => SampleMethodAsync("[1] Process 2"),
        () => SampleMethodAsync("[1] Process 3"),
        () => SampleMethodAsync("[1] Process 4"),
        () => SampleMethodAsync("[1] Process 5")
        );      
}

// Example method
public static async Task SampleMethodAsync(string processName, int sleep = 3000)
{
    await Task.Run(() => 
    {
        System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
        Thread.Sleep(sleep);
        System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));                
    });
}
```

Run all methods in order of entry (Async)

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

// Run all methods in order of entry (Async)
public static async Task InvokeAndRunInOrderAsync()
{    
    await Parallel.InvokeAsync(ProcessType.RunInOrder,
        () => SampleMethodAsync("[2] Process 5"),
        () => SampleMethodAsync("[2] Process 4"),
        () => SampleMethodAsync("[2] Process 3"),
        () => SampleMethodAsync("[2] Process 2"),
        () => SampleMethodAsync("[2] Process 1")
        );
}

// Example method
public static async Task SampleMethodAsync(string processName, int sleep = 3000)
{
    await Task.Run(() => 
    {
        System.Console.WriteLine("begin {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));
        Thread.Sleep(sleep);
        System.Console.WriteLine("end {0} {1}", processName, DateTime.Now.ToString("hh:mm:ss fff"));                
    });
}
```

Execute all methods with different result at the same time (Async) (Option 1 and 2)

```csharp
using Vaetech.Threading.Tasks;
using Parallel = Vaetech.Threading.Tasks.Parallel;

// Execute all methods with different result at the same time. (Option 1)
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
```
