using Dz7tum.enums;
using System;
namespace Dz7tum.classes
{
    public class Bankacc
    {
        private static  uint _accountCounter;
        private readonly uint _accountNumber;
        private decimal balance;
        private AccountType type;

        public Bankacc(decimal initialBalance, AccountType accountType)
        {
            balance = initialBalance;
            type = accountType;
            _accountNumber = _accountCounter++;
        }
        public uint accountNumber
            {
                get { return _accountNumber+1; }
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
        public bool DepositFromOther(ref Bankacc sourceAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше нуля.");
                return false;
            }

            if (sourceAccount.balance < amount)
            {
                Console.WriteLine($"Ошибка: На счете №{sourceAccount.accountNumber} недостаточно средств.");
                return false;
            }

            sourceAccount.balance -= amount;
            this.balance += amount;

            Console.WriteLine($"Успешно списано {amount} со счета №{sourceAccount.accountNumber}");
            return true;
        }

        public void PrintInfo()
            {
                Console.WriteLine("\nТип счета:" + type + "\nБаланс:" + balance);
            }
        }
    }
