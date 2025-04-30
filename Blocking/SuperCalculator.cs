namespace Blocking;

public static class SuperCalculator
{
    private static Task<int>? task = null;    

    public static void ActivateSuperComputer()
    {
        Console.WriteLine($"Current thread ID: {Environment.CurrentManagedThreadId}");
        if (task == null)
        {
            Console.WriteLine("\tSuper computer is now processing the Ultimate Question...");

            task = Task.Run(() =>
            {
                Task.Delay(15000).Wait();

                // The answer to life, the universe, and everything
                return 42;
            });

            Console.WriteLine("\tSuper computer started thinking in the background; you can continue to do other things...");
        }
        else
        {
            if (!task.IsCompleted)
                Console.WriteLine("\tSuper computer is already working on the question...");
            else
                Console.WriteLine("\tSuper computer has already provided an answer.");
        }
    }

    public static void CheckSuperComputerStatus()
    {        
        if (task == null)
        {
            Console.WriteLine("\tSuper computer hasn't started thinking yet.");
            return;
        }

        if (task.IsCompleted)
        {
            var result = task.Result;
            Console.WriteLine($"\tSuper computer has finished. The answer is: {result}");
        }

        else
        {
            Console.WriteLine("\tSuper computer is still thinking about the Question...");
            Console.Write("\tWould you like to wait for the answer ? (Y/N): ");
            var choice = Console.ReadLine();

            if (choice?.ToUpper() == "Y") // Kullanıcı cevabı beklemek istedi, Y girdi
            {
                Console.WriteLine("\tWaiting for Super computer to finish...");
                task.Wait();
                var result = task.Result;
                Console.WriteLine($"\tSuper computer is done! The answer is: {result}");
            }
            else
            {
                Console.WriteLine("\tReturning to the menu. Super computer continues to think in the background...");
            }
        }
    }
}