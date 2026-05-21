using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Simulator
{
    public class BankAccount
    {
        // 存儲帳戶餘額的私有欄位
        private decimal balance;

        // 建構函式，接受初始餘額參數
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        // 存入方法：增加帳戶餘額
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                return;
            balance += amount;
        }

        // 提取方法：減少帳戶餘額（若餘額足夠）
        // 傳回值：成功提取返回 true，提取金額不足返回 false
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        // 取得目前餘額的方法
        public decimal GetBalance()
        {
            return balance;
        }
    }
}

