using System;
namespace InheritanceApp;

public class CreditCard
{
    public string CardNumber { get; set; }
    public int CVC { get; set; }
    public double Balance { get; set; }

    public CreditCard(string cardNumber, int cvc, double balance)
    {
        CardNumber = cardNumber;
        CVC = cvc;
        Balance = balance;
    }

    public static CreditCard operator +(CreditCard card, double amount)
    {
        return new CreditCard(card.CardNumber, card.CVC, card.Balance + amount);
    }

    public static CreditCard operator -(CreditCard card, double amount)
    {
        return new CreditCard(card.CardNumber, card.CVC, card.Balance - amount);
    }

    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        return card1.CVC == card2.CVC;
    }

    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        return card1.Balance < card2.Balance;
    }

    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        return card1.Balance > card2.Balance;
    }

    public override bool Equals(object obj)
    {
        if (obj is CreditCard otherCard)
        {
            return this.CardNumber == otherCard.CardNumber &&
                   this.CVC == otherCard.CVC &&
                   this.Balance == otherCard.Balance;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var card1 = new CreditCard("1234 5678 9012 3456", 123, 3000);
            var card2 = new CreditCard("9876 5432 1098 7654", 123, 4000);

            CreditCard increasedCard = card1 + 400;
            Console.WriteLine($"Balance after deposit: {increasedCard.Balance}");

            CreditCard decreasedCard = card2 - 700;
            Console.WriteLine($"Balance after withdrawal: {decreasedCard.Balance}");

            Console.WriteLine($"card1 == card2? {card1 == card2}");
            Console.WriteLine($"card1 != card2? {card1 != card2}");

            Console.WriteLine($"card1 < card2? {card1 < card2}");
            Console.WriteLine($"card1 > card2? {card1 > card2}");

            CreditCard card3 = new CreditCard("1234 5678 9012 3456", 123, 1500.0);
            Console.WriteLine($"card1.Equals(card3)? {card1.Equals(card3)}");
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


/*
Balance after deposit: 3400
Balance after withdrawal: 3300
card1 == card2? True
card1 != card2? False
card1 < card2? True
card1 > card2? False
card1.Equals(card3)? False

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 17764) exited with code 0 (0x0).
Press any key to close this window . . .
 
*/
