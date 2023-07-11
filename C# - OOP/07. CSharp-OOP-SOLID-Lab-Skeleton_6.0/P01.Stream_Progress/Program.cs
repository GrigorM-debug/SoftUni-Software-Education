namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new Music("Pesho", 20, 10, "Golden hammer");

            StreamProgressInfo streamProgressInfo = new(file);


            System.Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}
