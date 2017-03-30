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
        static void Main(string[] args)
        {
            // 方法1 通过创建自动生成的、继承自ClientBase<TChannel>的类型对象进行服务调用
            //using (CalculatorServiceClient proxy = new CalculatorServiceClient())
            //{
            //    Console.WriteLine("X + Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            //    Console.WriteLine("X - Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
            //    Console.WriteLine("X * Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
            //    Console.WriteLine("X / Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
            //    Console.ReadKey();
            //}

            // 方法2 通过Syystrm.ServiceModel.ChannelFactory<TChannel>直接创建服务代理对象
            // 此处也可配置在配置文件中
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator proxy = channelFactory.CreateChannel();
                Console.WriteLine("X + Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
                Console.WriteLine("X - Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
                Console.WriteLine("X * Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
                Console.WriteLine("X / Y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
                Console.ReadKey();
            }
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
