using App.Domain.AppServices.CardAggrigate;
using App.Domain.AppServices.TransactionAggrigate;
using App.Domain.Core.Bank.CardAggrigate.Contracts.AppService;
using App.Domain.Core.Bank.CardAggrigate.Entites;
using Microsoft.AspNetCore.Mvc;
using MVCApp.EndPoint.Models;

namespace MVCApp.EndPoint.Controllers;

public class CardController : Controller
{
    TransactionAppService transactionAppService = new TransactionAppService();
    CardAppService _cardAppService = new CardAppService();
    [HttpGet]
    public IActionResult Transfer()
    {
        transactionAppService.PassCreate();
        return View();
    }


    [HttpPost]
    public IActionResult TransferPost(string DcardNumber, int amount, string tPass)
    {
        if (DcardNumber.Length != 16 || DcardNumber is null)
        {
            ViewBag.DCardNumber = "DCard number's length error!!!";
            return View("Transfer");
        }

        var cardExist = _cardAppService.GetCard(DcardNumber);

        if(cardExist == null)
        {
            ViewBag.DCardFound = "Destination card is not found!!!";
            return View("Transfer");
        }

        if ( amount <= 0)
        {
            ViewBag.amount = "Invalid input for amount. Please enter a positive number.";
            return View("Transfer");

        }

        if (!transactionAppService.CheckFilePass(tPass))
        {
            ViewBag.tPass = "Temporary password is incorrect!!!";
           
        }
        bool transferStatus = transactionAppService.Transfer(OnlineCrad.card.CardNumber, DcardNumber, amount);

        if (transferStatus)
        {
            ViewBag.successfully= "Transfer completed successfully.";
            return View("Transfer");
        }
        return View();
    }

    [HttpGet]
    public IActionResult ShowTransactions()
    {
        var Transactions = transactionAppService.GetTransactions(OnlineCrad.card.CardNumber);

       
        return View(Transactions);


    }

    [HttpGet]
    public IActionResult ShowBalance()
    {

        var Card = _cardAppService.GetCard(OnlineCrad.card.CardNumber);

        return View(Card);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {

        return View();
    }

    [HttpPost]
    public IActionResult ChangePasswordPost(string oldPass, string newPass)
    {

         bool result = _cardAppService.ChangePass(OnlineCrad.card.CardNumber, oldPass, newPass);
        if (result)
        {
            ViewBag.Success = "Password changed successfully";
            return View("ChangePassword");
        }

        ViewBag.Faild = "old pass or new pass is incorrect!!!";
        return View("ChangePassword");
        

    }
}
