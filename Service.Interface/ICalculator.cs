using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Service.Interface
{

    /*
     *                                          一、(创建)服务契约（也可以叫契约接口）
     *  
     *                  1、一般将服务契约定义成接口，即服务契约一般以接口的形式呈现
     *                  2、功能上看：服务契约是对服务提供的所有操作的抽象
     *                  3、从消息交换的角度看：定义了基于服务调用的消息交换过程中请求消息和回复消息的结构，以及采用的消息交换模式
     *                  4、程序集：System.ServiceModel.dll。
     *                  5、使用到的特性类：ServiceContractAttribute特性和OperationContractAttribute特性：ServiceContract、OperationContract
     *                  6、使用ServiceContract特性同时，还可以给服务契约指定Name和Namespace
     *                  7、思想：通过ServiceContractAttribute特性将接口定义成了服务契约
     * 
     * **/


    /// <summary>
    /// 创建服务契约
    /// </summary>
    [ServiceContract(Name ="CalculatorService", Namespace = "http://wwww.artech.com/")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);
        [OperationContract]
        double Subtract(double x, double y);
        [OperationContract]
        double Multiply(double x, double y);
        [OperationContract]
        double Divide(double x, double y);
    }
}
