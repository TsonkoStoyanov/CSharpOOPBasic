using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        
        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                this.balance = value;
            }

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public override string ToString()
        {
            return $"Account ID{Id}, balance {Balance:f2}";
        }
    }
}