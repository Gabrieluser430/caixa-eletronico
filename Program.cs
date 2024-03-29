﻿using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
  String cardNum;
  int pin;
  String firstName;
  String lastName;
  double balance;

  public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
  {
    this.cardNum = cardNum;
    this.pin = pin;
    this.firstName = firstName;
    this.lastName = lastName;
    this.balance = balance;
  }

  public String Num
  {
    get => cardNum;
    set => cardNum = value;
  }

  public int Pin
  {
    get => pin;
    set => pin = value;
  }

  public String FirstName
  {
    get => firstName;
    set => firstName = value;
  }

  public String LastName
  {
    get => lastName;
    set => lastName = value;
  }

  public double Balance
  {
    get => balance;
    set => balance = value;
  }

  public static void Main(String[] args)
  {
    void printOptions()
    {
      Console.WriteLine("Please choose from one of the following options...");
      Console.WriteLine("1. Deposit");
      Console.WriteLine("2. Withdraw");
      Console.WriteLine("3. Show Balance");
      Console.WriteLine("4. Exit");
    }

    void deposit(cardHolder currentUser)
    {
      Console.WriteLine("How much $$ would you like to deposit");
      double deposit = Double.Parse(Console.ReadLine());
      currentUser.Balance += deposit;
      Console.WriteLine($"Thank you for you $$ your new balance is: {currentUser.Balance}");
    }

    void withdraw(cardHolder currentUser)
    {
      Console.WriteLine("How much $$ would you like to withdraw: ");
      double withdrawal = Double.Parse(Console.ReadLine());
      if (currentUser.Balance < withdrawal)
      {
        Console.WriteLine("Insufficient balance :(");
      }
      else
      {
        currentUser.Balance = currentUser.Balance - withdrawal;
        Console.WriteLine("You're good to go! Thank you :)");
      }
    }

    void balance(cardHolder currentUser)
    {
      Console.WriteLine($"Current balance: {currentUser.Balance}");
    }

    List<cardHolder> cardHolders = new List<cardHolder>();
    cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
    cardHolders.Add(new cardHolder("4532761841325802", 4321, "Ashley", "Jones", 321.13));
    cardHolders.Add(new cardHolder("5128381368581872", 9999, "Frida", "Dickerson", 105.59));
    cardHolders.Add(new cardHolder("6011188364697109", 2468, "Muneeb", "Harding", 851.84));
    cardHolders.Add(new cardHolder("3490693153147110", 4826, "Dawn", "Smith", 54.27));

    Console.WriteLine("Welcome to SimpleATM");
    Console.WriteLine("Please insert your debit card: ");
    String debitCardNum = "";
    cardHolder currentUser;

    while (true)
    {
      try
      {
        debitCardNum = Console.ReadLine();
        currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
        if (currentUser != null) { break; }
        else { Console.WriteLine("Card not recognized. Please try again"); }

      }
      catch
      { Console.WriteLine("Card not recognized. Please try again"); }
    }

    Console.WriteLine("Please enter your pin: ");
    int userPin = 0;

    while (true)
    {
      try
      {
        userPin = int.Parse(Console.ReadLine());
        if (currentUser.Pin == userPin) { break; }
        else { Console.WriteLine("Incorrect Pin. Please try again"); }

      }
      catch
      { Console.WriteLine("Incorrect Pin. Please try again"); }
    }

    Console.WriteLine($"Welcome {currentUser.FirstName}");
    int option = 0;

    do
    {
      printOptions();
      try
      {
        option = int.Parse(Console.ReadLine());
      }
      catch { }
      if (option == 1) { deposit(currentUser); }
      else if (option == 2) { withdraw(currentUser); }
      else if (option == 3) { balance(currentUser); }
      else if (option == 4) { break; }
      else { option = 0; }
    }
    while (option != 4);
    Console.WriteLine("Thank you! Have a nice day :)");
  }
}

