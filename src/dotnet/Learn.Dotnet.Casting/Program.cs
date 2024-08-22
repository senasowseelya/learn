namespace Learn.Dotnet.Casting
{
    internal class Program
    {

        /*
         * When we assign a derived class object to a base class reference  as " Base obj = new Child()" 
         * then we can only access the members of the base class using the reference variable.
         * but if we want to access the members of the derived class then we need to cast the reference variable to the derived class.
         * (child)obj.childProperty.
         * If the object is not of the derived class then it will throw an InvalidCastException.
         * Base obj = new Base(); (Child)obj.childProperty will throw InvalidCastException
         */
        static void Main(string[] args)
        {

            Car car = new()
            {
                Id = 2,
                NumberOfWheels = 4,
                Make = "Toyota",
                Model = "Corolla"
            };

            Cycle cycle = new()
            {
                Id = 3,
                NumberOfWheels = 2,
                Type = "Gear"
            };

            Vehicle vehicle1 = new()
            {
                Id = 4,
                NumberOfWheels = 4
            };

            //Console.WriteLine(vehicle1.Make); // Compile-time error as Vehicle class does not have Make property
            Vehicle vehicle = car;
            // Console.WriteLine(vehicle.Make); // Compile-time error as Vehicle class does not have Make property
            Console.WriteLine(((Car)vehicle).Make); // works fine. Cast the vehicle object to Car class to access Make property

            // Car c = new Vehicle();  // Compile-time error as Vehicle class cannot be assigned to Car class
            //Car c = (Car)vehicle1;// Run-time error as vehicle1 is of type Vehicle and it cannot be cast to Car class
            // Car c  = vehicle1 as Car; // c will be null as vehicle1 is of type Vehicle and it cannot be cast to Car class
            
            //Car c = vehicle; // compile-time error as vehicle is of type Vehicle and it cannot be assigned to Car class
            Car c = (Car)vehicle; // works fine. Cast the vehicle object to Car class because vehicle object is actually refering car object
            Car c1 = vehicle as Car; // works fine. Cast the vehicle object to Car class because vehicle object is actually refering car object
            Console.WriteLine(c.Make);
            Console.WriteLine(c1.Make);
        }
    }

    public class Vehicle
    {
        public int Id { get; set; }
        public int NumberOfWheels { get; set; }
    }

    public class Car : Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }

    public class Cycle : Vehicle
    {
        public string Type { get; set; }
    }
}
