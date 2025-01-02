using App.Domain.Core.Bank.CardAggrigate.Contracts.Repository;
using App.Domain.Core.Bank.TransactionAggrigate.Contracts;
using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using App.Domain.Services.Bank.CardServices;
using App.Infra.DataAccess.EF.CardAggrigate;
using App.Infra.DataAccess.EF.TransactionAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;

namespace App.Domain.Services.Bank.TranactionServices
{
    public class TransActionService : ITransactionService
    {

        private readonly ICardRepository _cardRepository;
        private readonly ITransactionRepository _transactionRepository;
        public TransActionService()
        {
            _cardRepository = new CardRepository();
            _transactionRepository = new TransactionRepository();
        }

        public bool Transfer(string source, string destination, float money)
            {
                float temp = 0;
                var sourceCard = _cardRepository.GetCardByCardNo(source);

                //if (sourceCard.TodayTransaction == null || sourceCard.TodayTransaction.Value.Date != DateTime.Now.Date)
                //{
                //    sourceCard.DailyTransferAmount = 0;
                //    sourceCard.TodayTransaction = DateTime.Now;
                //}
                //{
                //    sourceCard.DailyTransferAmount = 0;
                //    sourceCard.TodayTransaction = DateTime.Now;
                //}
                //if (money > 250 || sourceCard.DailyTransferAmount + money > 250)
                //{
                //    Console.WriteLine("Transfer amount error (more than 250)!!!");
                //    return false;
                //}

                if (money >= 1000)
                {
                    temp = money * 0.015F + money;
                }
                else
                {
                    temp = money * 0.005F + money;
                }

                bool minus = _cardRepository.MinusMoney(source, temp);
                if (!minus)
                {
                    var failedTransaction = new TransAction
                    { Amount = money, SourceCardNumber = source, DestinationCardNumber = destination, IsSuccessful = false, TransactionDate = DateTime.Now };
                    _transactionRepository.AddTransaction(failedTransaction);
                    return false;
                }

                bool plus = _cardRepository.PlusMoney(destination, money);
                if (!plus)
                {
                    _cardRepository.PlusMoney(source, money);
                    var failedTransaction = new TransAction
                    { Amount = money, SourceCardNumber = source, IsSuccessful = false, DestinationCardNumber = destination, TransactionDate = DateTime.Now };
                    _transactionRepository.AddTransaction(failedTransaction);
                    return false;
                }

                var transaction = new TransAction
                { Amount = money, SourceCardNumber = source, DestinationCardNumber = destination, IsSuccessful = true, TransactionDate = DateTime.Now };
                _transactionRepository.AddTransaction(transaction);

                sourceCard.DailyTransferAmount += money;
                _cardRepository.UpdateCardLimits(sourceCard);
                return true;
            }
            public List<TransAction>? GetTransactions(string cardNo)
            {
                return _transactionRepository.ShowAll(cardNo);
                
               
            }

            public bool CheckFilePass(string userPass)
            {
                string filePass = File.ReadAllText(@"C:\Users\Ali\Desktop\pass.txt");

                if (userPass == filePass)
                {
                    return true;
                }
                return false;

            }

            public void PassCreate()
            {

                System.Timers.Timer timer;
                string FilePath = @"C:\Users\Ali\Desktop\pass.txt";

                timer = new System.Timers.Timer(20000);
                timer.Elapsed += FilePass;
                timer.AutoReset = true;
                timer.Enabled = true;
                FilePass(null, null);


            }
            public  void FilePass(object sender, ElapsedEventArgs e)
            {
                Random rnd = new Random();
                string FilePath = @"C:\Users\Ali\Desktop\pass.txt";
                int randomPassword = rnd.Next(10000, 100000);

                File.WriteAllText(FilePath, randomPassword.ToString());
            }
        
    }
}
