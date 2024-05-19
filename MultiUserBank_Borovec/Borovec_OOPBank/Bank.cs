using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borovec_OOPBank
{
    public class Bank
    {
        private int _bankbalance;
        private string[] username = { "jlennon", "pmccartney", "gharrison", "rstarr" };
        private string[] password = { "johnny", "pauly", "georgy", "ringoy" };
        private int[] _acctbalance = { 1250, 2500, 3000, 1001 };
        private int currentUser;


        public Bank(int balance)
        {
            _bankbalance = balance;
        }

        public int BankBalance() { return _bankbalance; }
        public string Username(int index) { return username[index]; }
        public string Password(int index) { return password[index]; }
        public int Balance(int index) { return _acctbalance[index]; }

        public bool Login(string _username, string _password)
        {
            for (int i = 0; i < username.Length; i++)
            {
                if (username[i] == _username) 
                { 
                    if (password[i] == _password)
                    {
                        currentUser = i;
                        return true;
                    }
                }
            }
            return false;
        }

        //deposit
        public void Deposit(int deposit)
        {
            _bankbalance += deposit;
            _acctbalance[currentUser] += deposit;
            Console.WriteLine("Deposit of $" + deposit + " successful...\n");
            CheckBalance();
        }
        //withdrawal
        public void Withdrawal(int withdrawal)
        {
            if (withdrawal > 500)
            {
                Console.WriteLine("Withdrawals are limited to $500 or less, your withdrawal will be adjusted.");
                withdrawal = 500;            
            }
            if (withdrawal <= _acctbalance[currentUser])
            {
                Console.WriteLine("Withdrawal of $" + withdrawal + " successful...\n");
                _acctbalance[currentUser] -= withdrawal;
                _bankbalance -= withdrawal;
            }
            else
            {
                Console.WriteLine("Account Overdraw. $" + _acctbalance[currentUser] + " has been withdrawn instead.\n");
                _bankbalance -= _acctbalance[currentUser];
                _acctbalance[currentUser] = 0;

            }
            CheckBalance();
        }

        //check balance
        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: $" + _acctbalance[currentUser] + "\n");
        }
    }

}
