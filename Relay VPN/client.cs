using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            string myip = Dns.GetHostByName(hostName).AddressList[0].ToString();

            Console.WriteLine("Client Side Is Running....");
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(myip), 12000);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ipe);

            // Send request over VPN
            string data = "www.youtube.com";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            s.Send(buffer);
            Console.WriteLine("Request Sucess...");




        }
    }
}
