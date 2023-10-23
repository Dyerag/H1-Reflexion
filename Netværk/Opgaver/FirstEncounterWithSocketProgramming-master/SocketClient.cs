using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SocketProgramming
{
    internal class SocketClient
    {
        public void ExecuteClient()
        {
            //string ip = "127.0.0.1";
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName(), AddressFamily.Unspecified);
            IPAddress iPAddress = Program.GetIPAddress(ipHost.AddressList);
            IPEndPoint iPEndPoint = new(iPAddress, 11111);

            //We create a socket, that is used to connect to our server socket.
            //todo input IP address of server manually
            Socket sender = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(iPEndPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Client connected to : {sender.RemoteEndPoint}");

            //Creates messages and sends it to server
            string message = "This is the message<EOM>";
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            sender.Send(bytes);

            //Receives answer from server
            byte[] bytesReceived = new byte[4042];
            sender.Receive(bytesReceived);

            string messageReceived = Encoding.ASCII.GetString(bytesReceived);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messageReceived);
        }
    }
}