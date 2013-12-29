using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfCodeManager
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MessageHello”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MessageHello.svc 或 MessageHello.svc.cs，然后开始调试。
    public class MessageHello : IMessageHello
    {
        public HelloResponseMessage Hello(HelloGreetingMessage msg)
        {
            Console.WriteLine("Caller Sent"+ msg.Greeting);
            HelloResponseMessage responseMsg = new HelloResponseMessage();
            responseMsg.Response = "Service received: " + msg.Greeting;
            responseMsg.ExtraValues = string.Format("Served by Object {0}",this.GetHashCode().ToString());
            Console.WriteLine("Returned Response Message.");
            return responseMsg;
        }
    }
}
