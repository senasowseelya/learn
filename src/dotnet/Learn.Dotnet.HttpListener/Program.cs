using System.Net;
using System.Text;
namespace Learn.Dotnet.HttpListener
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Net.HttpListener  listener= new System.Net.HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            System.Console.WriteLine("Listening...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            Console.WriteLine("Request Url"+ request.Url);
            HttpListenerResponse response = context.Response;
            Console.WriteLine(response.OutputStream + "Output Stream");
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] bytes = Encoding.ASCII.GetBytes(responseString);
            response.ContentLength64 = bytes.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(bytes, 0, bytes.Length);
            listener.Stop();
            Console.Read();
        }
    }
}