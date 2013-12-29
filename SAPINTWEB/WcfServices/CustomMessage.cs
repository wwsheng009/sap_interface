using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WcfCodeManager
{
    [MessageContract]
    public class HelloResponseMessage
    {
        private string localResponse = string.Empty;
        private string extra = string.Empty;

        [MessageBodyMember(Name = "ResponseToGreeting",
            Namespace = "http://localhostl")]
        public String Response
        {
            get { return localResponse; }
            set { localResponse = value; }
        }

        [MessageHeader(Name = "OutOfBandData", Namespace = "http://localhost", MustUnderstand = true)]
        public String ExtraValues
        {
            get { return extra; }
            set { extra = value; }
        }

    }

    [MessageContract]
    public class HelloGreetingMessage
    {
        private string localGreeting = string.Empty;

        [MessageBodyMember(Name="Salutations",Namespace="http://localhost")]
        public String Greeting
        {
            set { localGreeting = value; }
            get { return localGreeting; }
        }
    }
}