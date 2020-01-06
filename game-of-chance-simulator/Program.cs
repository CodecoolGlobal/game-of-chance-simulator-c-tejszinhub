namespace GameOfChanceSimulator
{
    class Program
    {
        static void Main()
        {
            var geralt = new Fighter("Geralt", 80, 75, 60, 4);
            var manhattan = new Fighter("Dr_Manhattan", 100, 1000, 10, 1);

            global::System.Console.WriteLine(geralt.Fight(geralt, manhattan));
        }
    }
}
