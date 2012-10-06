using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEW_BANKING_FINAL
{
    class Account
    {
        private int _userId, _number, _type;
        private string _dateCreated;
        private decimal _balance, _interest;

        public Account(int id, int number, int type, string dateCreated,
                       decimal balance, decimal interest)
        {
            _userId = id;
            _number = number;
            _type = type;
            _dateCreated = dateCreated;
            _balance = balance;
            _interest = interest;
        }

        public int UserId
        { 
            get { return _userId; } 
            set { _userId = value; }
        }
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public decimal Interest
        {
            get { return _interest; }
            set { _interest = value; }
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdrawal(decimal amount)
        {
            Balance -= amount;
        }        

        public override string ToString()
        {
            return UserId.ToString() + ',' + Number.ToString() + ',' + Type.ToString() +
                ',' + DateCreated.ToString() + ',' + Balance.ToString() + ',' + Interest.ToString();
        }
    }
}
