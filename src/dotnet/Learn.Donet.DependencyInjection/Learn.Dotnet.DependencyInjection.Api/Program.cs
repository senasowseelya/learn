
namespace Learn.Dotnet.DependencyInjection.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //InWeb Api projcet we have built in DI container, so we do not need to add any nuget package
            //1. Create an Interface
            //2. Create a class that implements the interface
            //3. Register the service in the DI container
            //4. Inject the service in the class where you want to use it

           
            //Registering the services to container
            builder.Services.AddTransient<IGreet, GreetingService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
