using Dz7tum.classes;
using Dz7tum.enums;
using System;

namespace Dz7tum
{
   
    internal class Program
    {
        static void Ex1()
        {
            Bankacc acc1 = new Bankacc(1000, AccountType.Current); 
            Bankacc acc2 = new Bankacc(100, AccountType.Savings);  
            acc2.DepositFromOther(ref acc1, 400);
            Console.WriteLine(acc2.Balance);
        }
        static void Main(string[] args)
        {
            Ex1();
        }
    }
}