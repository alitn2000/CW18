using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Bank.CardAggrigate.Entites;

namespace App.Domain.Core.Bank.CardAggrigate.Contracts.Repository;

public interface ICardRepository
{
    bool MinusMoney(string cartNo, float money);

    bool PlusMoney(string cartNo, float money);
    bool Check(string cartNo);
    Card? GetCardByCardNo(string cardNo);
    bool LogIn(string userName, string cardNo, string pass);
    void UpdateCardStatus(string cardNo);
    void UpdateCardLimits(Card updatedCard);
    List<Card> GetUsersCards(string holderName);
    bool UpdatePass(string cardNo, string oldPass, string newPass);
}
