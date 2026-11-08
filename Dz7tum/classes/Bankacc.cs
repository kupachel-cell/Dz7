using dz7tum.enums
using System;
namespace dz7tum.classes
{
    public class Bankacc
    {
        private readonly Guid id; // id у аккаунта всегда один, поэтому логично сделать его объявляемым один раз
        private decimal balance;
        private AccountType type;

        public class BankAccount
        {
            private Guid id;
            private decimal balance;
            private AccountType type;
            public BankAccount(decimal initialBalance, AccountType accountType)
            {
                id = Guid.NewGuid();
                balance = initialBalance;
                type = accountType;
            }

            public Guid Id
            {
                get { return id; }
            }

            public decimal Balance
            {
                get { return balance; }
            }

            public AccountType Type
            {
                get { return type; }
                set { type = value; }
            }
            public void IsReplenishable(decimal amount)
            {
                if (amount > 0)
                {
                    balance = balance + amount;
                    Console.WriteLine("Счет успешно пополнен.");
                }
                else
                {
                    Console.WriteLine("Сумма пополнения должна быть больше нуля.");
                }
            }

            public bool IsWithdrawable(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма снятия должна быть больше нуля.");
                    return false;
                }

                if (balance >= amount)
                {
                    balance = balance - amount;
                    Console.WriteLine("Деньги успешно сняты.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Ошибка: Недостаточно средств на счете.");
                    return false;
                }
            }
            public void PrintInfo()
            {
                Console.WriteLine("\nТип счета:" + type + "\nБаланс:" + balance);
            }
        }
    }
}