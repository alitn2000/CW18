using App.Domain.Core.Bank.CardAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.CardAggrigate.Contracts.AppService
{
    public interface ICardAppService 
    {
        bool UserExist(string userName, string CartNo, string pass);
        bool CardExist(string CartNo);
        Card? GetCard(string cardNo);
        void Update(string cardNo);
        void ChangePass(string cardNo, string oldPass, string newPass);
    }
}
