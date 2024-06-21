namespace Learn.Dotnet.ClassVsRecord
{
    public class Program
    {
        static void Main(string[] args)
        {
            Differentiate();
        }

        static void Differentiate()
        {
            Point point = new(1, 2);
            PointRecord pointRecord = new(1, 2);

            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine(pointRecord.X);
            Console.WriteLine(pointRecord.Y);


            //Mutablility
            //Class Properties are mutable, while Record Properties are immutable.
            point.Y = 3;
            Console.WriteLine(point.Y);
            //pointRecord.Y = 3; // Error: Property or indexer 'PointRecord.Y' cannot be assigned to -- it is read only

            //with expression creates a new instance of the record with the specified properties changed.
            pointRecord = pointRecord with { Y = 6 };
            Console.WriteLine(pointRecord.Y);

        }
    }

    public class Point(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }

    public record PointRecord(int X, int Y);


}
