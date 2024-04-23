using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    // Properties
    public string CardNum { get; set; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }

    // Constructor
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    // Deposit money
    public void Deposit(double depositAmount)
    {
        Balance += depositAmount;
        Console.WriteLine($"Thank you for your deposit, your new balance is: {Balance}");
    }

    // Withdraw money
    public void Withdraw(double withdrawalAmount)
    {
        if (Balance < withdrawalAmount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            Balance -= withdrawalAmount;
            Console.WriteLine("You're good to go thank you!");
        }
    }

    // Check balance
    public void CheckBalance()
    {
        Console.WriteLine($"Current balance: {Balance}");
    }

    // Print ATM options
    public static void PrintOptions()
    {
        Console.WriteLine("Please choose from one of the following options...");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show balance");
        Console.WriteLine("4. Exit");
    }

    // Authenticate user
    public static CardHolder AuthenticateUser(string debitCardNum, List<CardHolder> cardHolderList)
    {
        return cardHolderList.FirstOrDefault(a => a.CardNum == debitCardNum);
    }
}
