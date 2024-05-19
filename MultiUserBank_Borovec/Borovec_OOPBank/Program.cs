//Written by Jonathan Borovec
namespace Borovec_OOPBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank Bank = new Bank(10000);
            bool isRunning = true;
            bool loggedIn = false;

            while (isRunning) {
                int currentUser;
                Console.WriteLine("------ Login Menu -----");
                Console.WriteLine("Bank Balance: $" + Bank.BankBalance());
                Console.WriteLine("1. Login");
                Console.WriteLine("0. Exit");
                int choice1 = Convert.ToInt32(Console.ReadLine());

                switch (choice1) 
                {
                    case 1:
                        Console.WriteLine("Please enter your username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Please enter your password:");
                        string password = Console.ReadLine();

                        if (Bank.Login(username, password) == false)
                        {
                            Console.WriteLine("Login attempt failed, please check your login information.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Login successful!");
                            loggedIn = true;
                            break;
                        }
                    case 0:
                        Console.WriteLine("Exiting...");
                        isRunning = false;
                        break;
                }
                
                while (loggedIn)
                {
                Console.WriteLine("----- Main Menu -----");
                Console.WriteLine("1. Make a Deposit");
                Console.WriteLine("2. Make a Withdrawal");
                Console.WriteLine("3. Check Current Balance");
                Console.WriteLine("0. Exit");
                int choice2 = Convert.ToInt32(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("How much would you like to deposit?");
                            int deposit = Convert.ToInt32(Console.ReadLine());
                            Bank.Deposit(deposit);
                            break;
                        case 2:
                            Console.WriteLine("How much would you like to withdraw?");
                            int withdrawal = Convert.ToInt32(Console.ReadLine());
                            Bank.Withdrawal(withdrawal);
                            break;
                        case 3:
                            Bank.CheckBalance();
                            break;
                        case 0:
                            Console.WriteLine("Logging out...");
                            loggedIn = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;


                    }
                }
            }
        }
    }
}
