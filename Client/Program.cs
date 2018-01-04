using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;
using System.ServiceModel;
using Service.Interface;

namespace Client
{
    class Program
    {

        /*
         *                          四、 创建客户端（进行服务调用）
         *                  1、服务成功寄宿后，服务端就会开始服务调用请求的监听
         *                  2、通过VS添加服务引用
         *                  
         *                  3、Service References > Reference.cs文件
         *                        3.1 这个文件是当vs添加服务引用时，自动生成
         *                        3.2 public interface CalculatorService {}这个接口是客户端进行服务调用的服务契约接口，这里名称为CalculatorService，而不是ICalculator.
         *                            是因为在创建服务契约时，在给契约接口添加ServiceContract特性的Name属性为CalculatorService，而不是ICalculator. 这里的契约接口CalculatorService
         *                            是和服务的契约接口ICalculator是等效的。
         *                  4、真正呗客户端使用的是CalculatorServiceClient的类，继承自System.ServiceModel.ClientBase<Client.ServiceReference1.CalculatorService>, 
         *                     同样实现了接口Client.ServiceReference1.CalculatorService
         *                  5、
         * **/



        static void Main(string[] args)
        {
            /*
             * System.ServiceModel.ClientBase<TChannel>的对象来创建服务代理对象调用服务
             * 
             * **/

            // 方法1 通过创建自动生成的、继承自ClientBase<TChannel>的类型对象CalculatorServiceClient进行服务调用
            // TChannel指向客户端契约接口Client.ServiceReference1.CalculatorService
            //using (CalculatorServiceClient proxy = new CalculatorServiceClient())
            //{
            //    Console.WriteLine("X + Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            //    Console.WriteLine("X - Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
            //    Console.WriteLine("X * Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
            //    Console.WriteLine("X / Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
            //    Console.ReadKey();
            //}


            /*
             * System.ServiceModel.ChannelFactory<TChannel>直接创建服务代理对象调用服务
             * 
             * 
             * **/

            // 方法2 通过System.ServiceModel.ChannelFactory<TChannel>直接创建服务代理对象
            // 此处也可配置在配置文件中，使用App.config的方法1-2配置
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator proxy = channelFactory.CreateChannel();
                Console.WriteLine("X + Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
                Console.WriteLine("X - Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
                Console.WriteLine("X * Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
                Console.WriteLine("X / Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
                Console.ReadKey();
            }

            /*
             * 1、原因：客户端的服务契约Client.ServiceReference1.CalculatorService 和 服务端的服务契约Service.Interface.ICalculator是等效的。
             * 2、这里客户端直接使用了服务端的服务契约Service.Interface.ICalculator，通过泛型的形式体现 Contract. 而Binding和 Address体现在参数中
             *  无需配置
             * **/

            //using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(new WSHttpBinding(), "http://127.0.0.1:3721/calculatorservice"))
            //{
            //    ICalculator proxy = channelFactory.CreateChannel();
            //    Console.WriteLine("X + Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            //    Console.WriteLine("X - Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
            //    Console.WriteLine("X * Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
            //    Console.WriteLine("X / Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
            //    Console.ReadKey();
            //}
        }
    }
}
