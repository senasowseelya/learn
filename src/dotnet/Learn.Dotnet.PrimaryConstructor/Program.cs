namespace Learn.Dotnet.PrimaryConstructor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new (10, 20);
            rectangle.Area();
            Square square = new (10);
            square.Area();
            SquareWithDefault squareWithDefault = new();
            squareWithDefault.Area();
            Parallelogram parallelogram = new(12,10,10);
            parallelogram.Area();
        }
    }


    /// <summary>
    /// Class without primary constructor
    /// </summary>
    public class Rectangle
    {
        public int Length{ get; set; }
        public int Width { get; set; }
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public void Area()
        {
            Console.WriteLine($"Area of rectangle is {Length * Width}");
        }
    }

    /// <summary>
    /// Class with primary constructor
    /// </summary>
    public class Square(int side)
    {
        public void Area()
        {
            //side is accessible in entire class
            //But primary constructor creates a mutable backing property, if you need readonly  declare it explicitly.
            side = 20;
            Console.WriteLine($"Area of square is {side * side}");
        }

    }
    /// <summary>
    /// Class with primary constructor and default values
    /// </summary>
    public class SquareWithDefault(int side = 15)
    {
        public void Area()
        {
            Console.WriteLine($"Area of square is {side * side}");
        }

    }
    /// <summary>
    /// Class  with primary constructor when overloaded constructor is present
    /// </summary>
    public class Parallelogram(int dimension1, int dimension2)
    {
        public int Diagonal { get; set; }
        //If there is an overloaded constructor, primary constructor should call primary constructor
        public Parallelogram(int dimension1, int dimension2,int diagonal):this(dimension1,dimension2)
        {
            Diagonal = diagonal;
        }
        public void Area()
        {
            Console.WriteLine($"Area of parallelogram is { Diagonal * dimension1 * dimension2}");
        }

    }
}
