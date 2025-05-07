using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1Iogger
{
    public class Worker1 :IWorker
    {

        ILogger Logger { get; }

        public Worker1(ILogger ilogger)
        {
            Logger = ilogger;
        }

        public void Work()
        {
            Logger.Event("Worker one starts his work");

            Thread.Sleep(3000);

            Logger.Event("Worker one stoped his work");
        }
    }

    public class Worker2 : IWorker
    {

        ILogger Logger { get; }

        public Worker2(ILogger ilogger)
        {
            Logger = ilogger;
        }

        public void Work()
        {
            Logger.Event("Worker two starts his work");

            Thread.Sleep(3000);

            Logger.Event("Worker two stoped his work");
        }
    }

    public class Worker3 : IWorker
    {

        ILogger Logger { get; }

        public Worker3(ILogger ilogger)
        {
            Logger = ilogger;
        }

        public void Work()
        {
            Logger.Event("Worker three starts his work");

            Thread.Sleep(3000);

            Logger.Event("Worker three stoped his work");
        }
    }
}
