using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Session6.Assessment1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Session6
{
    //Design a Stopwatch
    //Design a class called Stopwatch.The job of this class is to simulate a stopwatch.
    //It should provide two methods: Start and Stop.We call the start method first, and the stop method next.
    //Then we ask the stopwatch about the duration between start and stop.
    //Duration should be a value in TimeSpan.
    //Display the duration on the console.
    //Weshould also be able to use a stopwatch multiple times.
    //So we may start and stop it and then start and stop it again. Make sure the duration value each time is calculatedproperly.
    //We should not be able to start a stopwatch twice in a row (because that may overwrite the initial start time).
    //So the class should throw an InvalidOperationException if its started twice.
    //1 Educational tip: The aim of this
    //exercise is to make you understand that a class should be always in a valid state.
    //we use encapsulation and information hiding to achieve that.
    //The class should not revealits implementation detail.It only reveals a little bit, like a blackbox.From the outside,
    //you should not be able to misuse a class because you shouldn’t be able to see the implementation detail.
    //Don’t forget to handle edge cases.
    //The user may attempt to stop the stopwatch without starting it.
    //The user may attempt to start the stopwatch when it is already running.
    //The user may want to check the
    //elapsed interval while the stopwatch is running.

    public class Assessment1
    {
        public Assessment1()
        {
            StopWatch stopWatch = new StopWatch();

            ShowMainMenu(ref stopWatch);
        }


        void ShowMainMenu(ref StopWatch stopWatch)
        {
            Console.WriteLine("1. Start");
            Console.WriteLine("2. Stop");
            Console.WriteLine("3. Get Duration");
            Console.WriteLine("4. Get Last Duration");
            Console.WriteLine("5. Exit");

            AskForOperation(ref stopWatch);
        }

        void AskForOperation(ref StopWatch stopWatch)
        {
            while (true)
            {
                Console.Write("Enter operation number : ");
                var line = Console.ReadLine();
                if (int.TryParse(line, out int operationNumber))
                {
                    switch (operationNumber)
                    {
                        case (int)Operations.Start:
                            stopWatch.Start();
                            ShowMainMenu(ref stopWatch);
                            break;

                        case (int)Operations.Stop:
                            stopWatch.Stop();
                            ShowMainMenu(ref stopWatch);
                            break;

                        case (int)Operations.GetDuration:
                            stopWatch.GetDuration();
                            ShowMainMenu(ref stopWatch);
                            break;

                        case (int)Operations.GetLastDuration:
                            stopWatch.GetLastDuration();
                            ShowMainMenu(ref stopWatch);
                            break;

                        case (int)Operations.Exit:
                            Environment.Exit(0);
                            break;

                        default:
                            continue;
                    }
                }
            }
        }


        public enum Operations
        {
            Start = 1,
            Stop = 2,
            GetDuration = 3,
            GetLastDuration = 4,
            Exit = 5
        }




        public class StopWatch
        {
            DateTime? startedOn = null;
            DateTime? stoppedOn = null;
            TimeSpan lastDuration = TimeSpan.Zero;

            public void Start()
            {
                try
                {
                    if (startedOn != null)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        lastDuration = TimeSpan.Zero;
                        stoppedOn = null;

                        startedOn = DateTime.Now;
                        Console.WriteLine("Started");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public void Stop()
            {
                try
                {
                    if (startedOn == null)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        stoppedOn = DateTime.Now;
                        lastDuration = stoppedOn.Value - startedOn.Value;
                        startedOn = null;
                        Console.WriteLine("Stopped");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public void GetDuration()
            {
                try
                {
                    if (startedOn == null)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now - startedOn.Value);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public void GetLastDuration()
            {
                Console.WriteLine( lastDuration);
            }
        }
    }
}
