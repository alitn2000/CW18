using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Repository;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Service;
using App.Domain.Core.Bank.CardAggrigate.Entites;
using App.Infra.DataAccess.EF.CardAggrigate;
namespace App.Domain.Services.Bank.CardServices;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    public CardService()
    {
         _cardRepository = new CardRepository();
    }

    public bool UserExist(string userName, string CartNo, string pass)
    {
        var flag = _cardRepository.LogIn(userName, CartNo, pass);
        if (flag)
        {
            return true;
        }
        return false;
    }
    public bool CardExist(string CartNo)
    {
        var flag = _cardRepository.Check(CartNo);
        if (flag)
        {
            return true;
        }
        return false;
    }
    public Card? GetCard(string cardNo)
    {
        return _cardRepository.GetCardByCardNo(cardNo);
    }
    public void Update(string cardNo)
    {
        _cardRepository.UpdateCardStatus(cardNo);
    }

    public void ChangePass(string cardNo, string oldPass, string newPass)
    {
        if (oldPass == newPass)
        {
            Console.WriteLine("the passwords you enetred is the same!!!");
            return;
        }
        if (!_cardRepository.UpdatePass(cardNo, oldPass, newPass))
        {
            Console.WriteLine("your old password is incorrect!!!");
            return;
        }
        Console.WriteLine("your password changed successfully.");
    }


}
