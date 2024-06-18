namespace Learn.Dotnet.DependencyInjection.Api
{
    //Injecting service using constructor
    public class GreetUser(IGreet GreetingService)
    {
        public IGreet GreetingService { get; } = GreetingService;

        public void Greet()
        {
            GreetingService.Greet();
        }
    }
}
