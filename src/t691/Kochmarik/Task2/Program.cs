using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void TableView()
        {
            Process[] processes = Process.GetProcesses();

            var counters = new List<PerformanceCounter>();

            foreach (Process process in processes)
            {
                var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;
            while (true)
            {
                Console.WriteLine("  Pid  |  uid  |            name            | cpu_usage | ram_usage |");
                Console.WriteLine("-------------------------------------------------------------------");

                foreach (var counter in counters)
                {
                    Console.WriteLine($"{processes[i].Id,6:#} | {processes[i].SessionId,5:#} | {processes[i].ProcessName,26:#} | {counter.NextValue() / Environment.ProcessorCount,9} | {processes[i].WorkingSet64 / 1024d,9} |");
                    ++i;
                }
                i = 0;

                Console.WriteLine();
                Console.WriteLine("Press 'a' to update");
                while (Console.ReadKey().KeyChar != 'a') ;
                Console.Clear();
            }
        }

        static void ProgressBar()
        {
            PerformanceCounter counter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            PerformanceCounter counterCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

            while (true)
            {
                Process[] processes = Process.GetProcesses();

                double ramPersent = 30 * counter.NextValue() / 100;
                Console.Write('[');
                for (int i = 0; i < 30; ++i)
                    if (i >= ramPersent)
                        Console.Write('-');
                    else
                        Console.Write('|');
                Console.WriteLine($"]({counter.NextValue()}) RAM");
                Console.WriteLine();

                double cpuPersent = 30 * counterCPU.NextValue() / 100;
                Console.Write('[');
                for (int i = 0; i < 30; ++i)
                    if (i >= cpuPersent)
                        Console.Write('-');
                    else
                        Console.Write('|');
                Console.WriteLine($"]({cpuPersent}) CPU");

                Thread.Sleep(1000);
                Console.Clear();


            }
        }

        static void Main(string[] args)
        {
            int a = 0;

            Console.WriteLine("1 - Table view");
            Console.WriteLine("2 - Progress bar");
            a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.Clear();
                    TableView();
                    break;
                case 2:
                    Console.Clear();
                    ProgressBar();
                    break;
            }
        }
    }
}
