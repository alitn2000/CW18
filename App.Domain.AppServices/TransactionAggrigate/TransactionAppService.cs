﻿using App.Domain.Core.Bank.TransactionAggrigate.AppService;
using App.Domain.Core.Bank.TransactionAggrigate.Contracts;
using App.Domain.Services.Bank.TranactionServices;
using System.Timers;
namespace App.Domain.AppServices.TransactionAggrigate
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly ITransactionService _TransactionService;

        public TransactionAppService()
        {
            _TransactionService = new TransActionService();
        }
        public bool CheckFilePass(string userPass)
        {
           return _TransactionService.CheckFilePass(userPass);
        }

        public bool GetTransactions(string cardNo)
        {
           return _TransactionService.GetTransactions(cardNo);
        }

        public bool Transfer(string source, string destination, float money)
        {
           return _TransactionService.Transfer(source, destination, money);
        }

        public void PassCreate()
        {
            _TransactionService.PassCreate();

        }
        public  void FilePass(object sender, ElapsedEventArgs e)
        {
            _TransactionService.FilePass(sender, e);
        }
    }
}
