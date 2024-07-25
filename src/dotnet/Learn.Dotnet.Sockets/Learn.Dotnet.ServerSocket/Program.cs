using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Learn.Dotnet.ServerSocket
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GetServerSocketReady();
        }

        public static async Task GetServerSocketReady()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = await Dns.GetHostAddressesAsync(hostName);
            IPAddress localhost = ipAddresses[0];
            int port = 11011;
            IPEndPoint endpoint = new(localhost, port);
            Socket serverSocket = new(localhost.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(endpoint);
            serverSocket.Listen();
            Console.WriteLine("Server is Listening");
            Socket handler = await serverSocket.AcceptAsync();
            Console.WriteLine("Accepted Connection");
            while (true)
            {
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = await handler.ReceiveAsync(buffer);
                string response = Encoding.ASCII.GetString(buffer, 0, numberOfBytesReceived);
                if(response.IndexOf("|EOM|") > -1) // indicates end of message.
                {
                    Console.WriteLine($"Data Received from client : {response}");
                    Console.WriteLine("Press enter to send acknowledgement to client");
                    Console.ReadKey();
                    await handler.SendAsync(Encoding.ASCII.GetBytes($"|ACK| from Server : Received data of bytes{numberOfBytesReceived}"));
                }
               
            }


        }
    }
}
