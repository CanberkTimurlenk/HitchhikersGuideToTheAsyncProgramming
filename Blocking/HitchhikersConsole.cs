namespace Blocking;

public static class HitchhikersConsole
{
    public static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Hitchhiker’s Menu");
            Console.WriteLine("1) Ask Super Computer to Compute the Ultimate Answer");
            Console.WriteLine("2) Check Super Computer's Progress");
            Console.WriteLine("3) Print Current Date and Time");
            Console.WriteLine("0) Exit");
            Console.Write("Selection: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SuperCalculator.ActivateSuperComputer(); // Starts the operation
                    break;

                case "2":
                    SuperCalculator.CheckSuperComputerStatus(); // Checks the operation status
                    break;

                case "3":
                    Console.WriteLine($"\tCurrent Date and Time: {DateTime.Now}");
                    break;

                case "0":
                    Console.WriteLine("\tFarewell...");
                    return;

                default:
                    Console.WriteLine("\tInvalid choice.");
                    break;
            }
        }
    }
}
