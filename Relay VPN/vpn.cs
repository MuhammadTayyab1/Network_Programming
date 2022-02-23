using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            string myip = Dns.GetHostByName(hostName).AddressList[0].ToString();

            Console.WriteLine("Act VPN Server is Listening.....");
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(myip), 12000);
            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ipe);
            s.Listen(1);
            Socket c = s.Accept();


            byte[] buffer2 = new byte[300];
            c.Receive(buffer2);
            string msg = Encoding.ASCII.GetString(buffer2);
            Console.WriteLine(msg);


            Random r = new Random();
            int num = r.Next(0, 2);
            Console.WriteLine(num);

            if (num == 0)
            {
                IPEndPoint ipe1 = new IPEndPoint(IPAddress.Parse(myip), 13000);
                Socket s1 = new Socket(ipe1.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                s1.Connect(ipe1);
                // Send request over VPN
                string datavpn = msg;
                byte[] buffer11 = Encoding.ASCII.GetBytes(datavpn);
                s1.Send(buffer11);

            }
            else if (num == 1)
            {

                IPEndPoint ipe2 = new IPEndPoint(IPAddress.Parse(myip), 14000);
                Socket s2 = new Socket(ipe2.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                s2.Connect(ipe2);
                // Send request over VPN
                string datavpn2 = msg;
                byte[] buffer12 = Encoding.ASCII.GetBytes(datavpn2);
                s2.Send(buffer12);
            }
        }







    }
}
