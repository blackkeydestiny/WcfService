using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Service.Interface;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            // 寄宿服务
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                // 在App.Config配置了，就无需在此配置，真正开发也是在配置文件中配置

                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:3721/calculatorservice");
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //    behavior.HttpGetEnabled = true;
                //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:3721/calculatorservice/metadata");
                //    host.Description.Behaviors.Add(behavior);

                //    host.Opened += delegate
                //    {
                //        Console.WriteLine("CalculatorService already start up!");
                //    };
                //    host.Open();
                //    Console.Read();
                //}

                host.Opened += delegate
                    {
                        Console.WriteLine("CalculatorService already start up!");
                    };
                host.Open();
                Console.Read();

            }
        }
    }
}
