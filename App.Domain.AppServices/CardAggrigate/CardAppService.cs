using App.Domain.Core.Bank.CardAggrigate.Contracts.AppService;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Repository;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Service;
using App.Domain.Core.Bank.CardAggrigate.Entites;
using App.Domain.Services.Bank.CardServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CardAggrigate
{
    public class CardAppService : ICardAppService
    {
        private readonly ICardService _cardService;
        public CardAppService()
        {
            _cardService = new CardService();
        }
        public bool CardExist(string CartNo)
        {
        return _cardService.CardExist(CartNo);
        }

        public bool ChangePass(string cardNo, string oldPass, string newPass)
        {
           return  _cardService.ChangePass( cardNo,  oldPass,  newPass);
        }

        public Card? GetCard(string cardNo)
        {
           return _cardService.GetCard(cardNo);
        }

        public void Update(string cardNo)
        {
            _cardService.Update(cardNo);
        }

        public bool UserExist(string userName, string CartNo, string pass)
        {
            return _cardService.UserExist( userName, CartNo, pass);
        }
    }
}
