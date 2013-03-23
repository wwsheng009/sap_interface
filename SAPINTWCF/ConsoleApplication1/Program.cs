using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SapFunctionServiceClient client = new SapFunctionServiceClient();


           string S =  client.ReadSAPTable("RET","T100");
           Console.WriteLine(S);
           System.Console.WriteLine(S);
            client.Close();
            Console.ReadLine();
        }
    }
}
