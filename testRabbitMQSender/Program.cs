using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Threading;
using RabbitMQ.Client.Events;

namespace testRabbitMQSender
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "Hello World!"
            //var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{

            //    for (int i=0; i < 10; i++)
            //    {
            //        channel.QueueDeclare(queue: "hello",
            //                                durable: false,
            //                                exclusive: false,
            //                                autoDelete: false,
            //                                arguments: null);
            //        string message = "Hello World!";
            //        var body = Encoding.UTF8.GetBytes(message);
            //        channel.BasicPublish(exchange: "",
            //                             routingKey: "hello",
            //                             basicProperties: null,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent {0}", message);

            //        Thread.Sleep(1000);
            //    }
            //}

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
            #endregion

            #region Work queues
            //var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    args = new string[2];
            //    for (int i = 0; i < 50; i++)
            //    {
            //        channel.QueueDeclare(queue: "task_queue",
            //                         durable: true,
            //                         exclusive: false,
            //                         autoDelete: false,
            //                         arguments: null);
            //        args[0] = string.Format("this my test time: {0} ",i+1);
            //        var message = GetMessage(args);
            //        var body = Encoding.UTF8.GetBytes(message);

            //        var properties = channel.CreateBasicProperties();
            //        properties.SetPersistent(true);

            //        channel.BasicPublish(exchange: "",
            //                             routingKey: "task_queue",
            //                             basicProperties: properties,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent {0}", message);
            //        Thread.Sleep(1000);
            //    }
            //}
            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
            #endregion

            #region Publish/Subscribe
            //var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    for (int i=0; i < 20; i++)
            //    {
            //        channel.ExchangeDeclare(exchange: "logs", type: "fanout");

            //        var message = GetMessage(args);
            //        var body = Encoding.UTF8.GetBytes(message);
            //        channel.BasicPublish(exchange: "logs",
            //                             routingKey: "",
            //                             basicProperties: null,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent {0}", message);
            //        Thread.Sleep(1000);
            //    }

            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();
            //}
            #endregion

            #region Routing
            //var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    for (int i=0; i < 30; i++)
            //    {
            //        var a = new Random();
            //        var severity="";
            //        var message =""; 
            //        if (a.Next(9) % 2 == 0)
            //        {
            //            severity = "warning";
            //            message = string.Format("this is warning ,time :{0}", i);
            //        }
            //        else if (a.Next(10) % 3 == 0)
            //        {
            //             severity = "info";
            //             message = string.Format("this is warning ,time :{0}", i);
            //        }
            //        else
            //        {
            //            severity = "error";
            //            message = string.Format("this is error ,time :{0}", i);
            //        }
            //        channel.ExchangeDeclare(exchange: "direct_logs",
            //                                type: "direct");

            //        //var severity = (args.Length > 0) ? args[0] : "info";
            //        //var message = (args.Length > 1)
            //        //              ? string.Join(" ", args.Skip(1).ToArray())
            //        //              : "Hello World!";
            //        var body = Encoding.UTF8.GetBytes(message);
            //        channel.BasicPublish(exchange: "direct_logs",
            //                             routingKey: severity,
            //                             basicProperties: null,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
            //    }

            //}

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
            #endregion

            #region Topics
            //var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    for (int i=0; i < 8; i++)
            //    {

            //        var a = new Random();
            //        var severity="";
            //        var message ="";
            //        var serverityList = new string[] { "quick.orange.rabbit", "lazy.orange.elephant", "lazy.brown.fox", "lazy.pink.rabbit", "quick.brown.fox", "quick.orange.fox", "quick.orange.male.rabbit", "lazy.orange.male.rabbit" };
            //        if (i <= 7) severity = serverityList[i];
            //        else severity = serverityList[a.Next(7)];
            //        message = string.Format(" time {0}", i);
            //        channel.ExchangeDeclare(exchange: "topic_logs",
            //                                type: "topic");
            //        var body = Encoding.UTF8.GetBytes(message);
            //        channel.BasicPublish(exchange: "topic_logs",
            //                             routingKey: severity,
            //                             basicProperties: null,
            //                             body: body);
            //        Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
            //        Thread.Sleep(2000);
            //    }
            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();
            //} 
            #endregion

            #region RPC
            var rpcClient = new RPCClient();

            Console.WriteLine(" [x] Requesting fib(30)");
            var response = rpcClient.Call("30");
            Console.WriteLine(" [.] Got '{0}'", response);

            rpcClient.Close();
            Console.ReadLine();
            #endregion
        }
        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
        
    }
    public class RPCClient
    {
        private IConnection connection;
        private IModel channel;
        private string replyQueueName;
        private QueueingBasicConsumer consumer;

        public RPCClient()
        {
            var factory = new ConnectionFactory() { HostName = "192.168.100.37", Password = "Git123!@#", UserName = "GitAdmin", Port = 5672 };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(queue: replyQueueName,
                                 noAck: true,
                                 consumer: consumer);
        }

        public string Call(string message)
        {
            var corrId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.ReplyTo = replyQueueName;
            props.CorrelationId = corrId;

            var messageBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "rpc_queue",
                                 basicProperties: props,
                                 body: messageBytes);

            while (true)
            {
                var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                if (ea.BasicProperties.CorrelationId == corrId)
                {
                    return Encoding.UTF8.GetString(ea.Body);
                }
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
