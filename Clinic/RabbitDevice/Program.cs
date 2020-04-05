using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RabbitDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueManager = (ConfigurationManager.AppSettings["QueueManagerHostName"]);
            var rabbitSender = new RabbitSender(queueManager);
            rabbitSender.SendMessage("hello","hello world");
            var rabbitReciever = new RabbitReciever(queueManager,"hello");
        }
    }
}
