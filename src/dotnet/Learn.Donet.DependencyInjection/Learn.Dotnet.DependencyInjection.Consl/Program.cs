using Microsoft.Extensions.DependencyInjection;

namespace Learn.Dotnet.DependencyInjection.Cnsl
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Install Dependency Injection Nuget Package
            //Create Service Collection
            ServiceCollection serviceCollection = new();
            //Register Service to Service Collection
            serviceCollection.AddTransient<IGreet, GreetService>();
            //Build Service Provider
            ServiceProvider sp = serviceCollection.BuildServiceProvider();
            //Resolve Service
            IGreet? service = sp.GetService<IGreet>();
            if (service != null)
            {
                service.Greet();
            }
            else
            {
                Console.WriteLine("Service resolution failed. Service is null.");
            }
        }
    }


    public interface IGreet
    {
        public void Greet();
    }
    public class GreetService : IGreet
    {
        public void Greet()
        {
            Console.WriteLine("Hello, World! from Greeting Service");
        }
    }


}
