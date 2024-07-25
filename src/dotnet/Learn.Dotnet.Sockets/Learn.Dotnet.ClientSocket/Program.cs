using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Learn.Dotnet.ClientSocket
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            IPAddress[] iPAddresses = Dns.GetHostAddresses(hostName);
            IPAddress localhost = iPAddresses[0];
            IPEndPoint serverEndPoint = new(localhost,11011);
            Socket clientSocket = new(localhost.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            await clientSocket.ConnectAsync(serverEndPoint);
            Console.WriteLine("Connection Request Sent");
            while (true)
            {
                Console.WriteLine("Press enter to send data to server");
                Console.ReadKey();
                int bytesSent = await clientSocket.SendAsync(Encoding.ASCII.GetBytes("Hi, This is message from client <|EOM|>"));
                Console.WriteLine("Data is sent from client");
                byte[] buffer = new byte[1024];
                int bytesReceived = await clientSocket.ReceiveAsync(buffer);
                Console.WriteLine($"Ack message {Encoding.ASCII.GetString(buffer,0,bytesReceived)}");
            }
        }
    }
}
