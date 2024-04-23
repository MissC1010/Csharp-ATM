using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<CardHolder> cardHolderList = new List<CardHolder>
        {
            new CardHolder("434542", 1234, "John", "Griffin", 150.32),
            new CardHolder("176834", 2222, "Jane", "Buck", 2378.21)
        };

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = Console.ReadLine();

        CardHolder currentUser = CardHolder.AuthenticateUser(debitCardNum, cardHolderList);
        if (currentUser == null)
        {
            Console.WriteLine("Card not recognized. Exiting.");
            return;
        }

        Console.WriteLine("Please enter pin: ");
        int userPin = int.Parse(Console.ReadLine());
        if (userPin != currentUser.Pin)
        {
            Console.WriteLine("Incorrect pin. Exiting.");
            return;
        }

        Console.WriteLine($"Welcome {currentUser.FirstName}");

        int option;
        do
        {
            CardHolder.PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine("How much money would you like to deposit: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    currentUser.Deposit(depositAmount);
                    break;
                case 2:
                    Console.WriteLine("How much money would you like to withdraw: ");
                    double withdrawalAmount = double.Parse(Console.ReadLine());
                    currentUser.Withdraw(withdrawalAmount);
                    break;
                case 3:
                    currentUser.CheckBalance();
                    break;
                case 4:
                    Console.WriteLine("Thank you. Have a nice day!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (option != 4);
    }
}
