namespace Learn.Dotnet.DependencyInjection.Api
{
    public class GreetingService :IGreet
    {
        public void Greet()
        {
            Console.WriteLine("Hello from Greeting Service!");
        }
    }
}
