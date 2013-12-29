using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = string.Empty;

            ServiceReference1.IMessageHello sm = new MessageHelloClient();
            HelloGreetingMessage greetingMsg = new HelloGreetingMessage("Vincent Wang");
            HelloResponseMessage response = sm.Hello(greetingMsg);



            MessageBox.Show(response.ResponseToGreeting);
            MessageBox.Show(response.OutOfBandData);
            

        }
    }
}
