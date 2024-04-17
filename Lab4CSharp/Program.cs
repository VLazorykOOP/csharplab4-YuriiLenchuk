string arg = "0";
while (arg != "4")
{
    Console.WriteLine("1 Task1");
    Console.WriteLine("2 Task2");
    Console.WriteLine("2 Task3");
    Console.WriteLine("4 Exit\n");
    Console.WriteLine("Choose option: ");
    arg = Console.ReadLine() ?? "5";
    switch (arg)
    {
        case "1":
            {
                Task1.task1();
                Console.WriteLine("\n(click enter to continue)");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
        case "2":
            {
                Task2.task2();
                Console.WriteLine("\n(click enter to continue)");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
        case "3":
            {
                Task3.task3();
                Console.WriteLine("\n(click enter to continue)");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
        case "4": break;
        default:
            {
                Console.WriteLine("Enter correct number");
                Console.WriteLine("\n(click enter to continue)");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
    }
}