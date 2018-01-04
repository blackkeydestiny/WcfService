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


            /*
             * 
             *                                      三、服务寄宿
             *              1、WCF服务需要依赖一个运行着的宿主进程，服务寄宿就是为服务指定一个宿主进程的过程。
             *              2、WCF采用的是终结点的通信手段：Endpoint = ABC, A = Address, B = Binding, C = Contract. 
             *                 一个终结点包含了服务通信的所有必要信息。
             *                  2-1、Address : 地址决定了服务的位置、解决了服务寻址的问题。
             *                  2-2、Binding : 绑定实现了通信的所有细节，包括网络传输、消息编码，以及其他实现某种功能（比如传输安全、可靠消息传输、事务等）
             *                           对消息进行相应的处理。WCF具有一系列的系统定义绑定：BasicHttpBinding、WSHttpBinding、NetTcpBinding等
             *                  2-3、Contract : 契约是对服务操作的抽象，也是对消息模式、消息结构的定义
             *              3、目的：服务寄宿就是开启一个进程，为WCF服务提供一个运行环境，并为服务添加一个或者多个终结点，使之暴露给潜在的服务消费者。
             *              4、方式： 自我寄宿、IIS寄宿
             * 
             * **/


            /*
             *                                          自我寄宿（这里寄宿到一个控制台应用程序）
             *                                          
             *                  1、实现要求的类： System.ServiceModel.ServiceHost对象来完成、ServiceMetadataBehavior
             *                  2、步骤：一、二、三、四
             *                  3、服务成功寄宿后，服务端就会开始服务调用请求的监听
             * 
             * **/

            // 步骤一：基于服务类型typeof(CalculatorService)创建ServiceHost对象
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                // 步骤二： 为ServiceHost对象添加终结点（ABC）
                //host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:3721/calculatorservice");//在App.Config配置了，就无需在此配置，真正开发也是在配置文件中配置

                /*
                 *  1、SOA的一个主要特征：松耦合。 
                 *  2、WCF服务中客户端和服务端的松耦合体现在 客户端只需了解WCF服务基本描述，而无需知道具体的实现细节，就可以实现正常的服务调用。
                 *  3、WCF的描述是通过元数据（Metadata）的形式发布出来的,而WCF的元数据是通过一个特殊的服务行为ServiceMetadataBehavior来实现的。
                 * 
                 * **/

                // 步骤三：为ServiceHost对象添加ServiceMetadataBehavior服务行为
                //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                //{
                //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();                   // 创建服务行为对象
                //    behavior.HttpGetEnabled = true;                                                     // 采用HTTP-GET方式来获取元数据
                //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:3721/calculatorservice/metadata");  // 指定元数据发布地址：服务寄宿成功后，浏览器可以访问这个发布地址
                //    host.Description.Behaviors.Add(behavior);                                           // 将服务行为添加到ServiceHost对象中
                    
                //    // 步骤四：调用Open方法，开启服务
                //    host.Opened += delegate
                //    {
                //        Console.WriteLine("CalculatorService already start up!");
                //    };
                //    host.Open();
                //    Console.Read();
                //}

                /*
                 *              在进行真正的WCF开发时，终结点的添加和服务行为的定义一般是在配置文件中完成（这里App.config里配置）
                 *              配置具体，参见App.config
                 * 
                 * **/

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
