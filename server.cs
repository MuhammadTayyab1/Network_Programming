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


            Console.WriteLine("Main Server is Listening.....");
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(myip), 13000);


            Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ipe);
            s.Listen(1);
            Socket c = s.Accept();

            // Receive data from original client 
            byte[] buffer2 = new byte[300];
            c.Receive(buffer2);
            string msg = "";
            msg = Encoding.ASCII.GetString(buffer2);


            if (msg == "")
            {
                IPEndPoint ipe2 = new IPEndPoint(IPAddress.Parse("172.30.176.1"), 14000);
                Socket s2 = new Socket(ipe2.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                s2.Bind(ipe2);
                s2.Listen(1);
                Socket c2 = s2.Accept();

                // Receive data from original client 
                byte[] buffer3 = new byte[300];
                c2.Receive(buffer3);
                string msg1 = "";
                msg1 = Encoding.ASCII.GetString(buffer2);
                Console.WriteLine(msg1+"   "+c.RemoteEndPoint.ToString());
            }
            else
            {
                Console.WriteLine(msg+"  "+c.RemoteEndPoint.ToString());
            }


            s.Close();
            Console.ReadLine();




        }
    }
}
