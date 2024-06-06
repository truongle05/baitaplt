using System;

// Ngoại lệ tùy chỉnh cho số tiền âm
public class NegativeAmountException : Exception
{
    public NegativeAmountException(string message) : base(message)
    {
    }
}

// Ngoại lệ tùy chỉnh cho số dư không đủ
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

public class BankAccount
{
    private double balance;

    public double Balance
    {
        get { return balance; }
    }

    public void Deposit(double amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Không thể gửi số tiền âm.");
        }
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Không thể rút số tiền âm.");
        }
        if (amount > balance)
        {
            throw new InsufficientFundsException("Số dư trong tài khoản không đủ.");
        }
        balance -= amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        try
        {
            account.Deposit(1000);
            account.Withdraw(500);
            Console.WriteLine($"Số dư tài khoản: {account.Balance}");

            account.Withdraw(600);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NegativeAmountException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Đã xảy ra lỗi không mong muốn: " + ex.Message);
        }
    }
}