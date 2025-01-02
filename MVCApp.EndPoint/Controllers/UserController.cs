using App.Domain.AppServices.CardAggrigate;
using App.Domain.Core.Bank.CardAggrigate.Entites;
using App.Domain.Core.Bank.UserAggrigate.Entite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVCApp.EndPoint.Models;

namespace MVCApp.EndPoint.Controllers;

public class UserController : Controller
{

    CardAppService _cardAppService = new CardAppService();
    public User OnlineUser { get; set; }

    [HttpGet]
    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LogInUser(string cardNumber, string pass, string userName)
    {
        if ((cardNumber.Length  != 16 && !cardNumber.IsNullOrEmpty()) || cardNumber.IsNullOrEmpty())
        {
           
            ViewBag.CardNumber = "Card number's length error!!!";
            return View("LogIn");
        }

        bool isValidUser = _cardAppService.UserExist(userName, cardNumber, pass);

        if (isValidUser == false)
        {
            ViewBag.ValidUser = "User not found!!!";
            return View("LogIn");
        }

        OnlineCrad.card = _cardAppService.GetCard(cardNumber);
        if (OnlineCrad.card.IsActive == false)
        {
            ViewBag.ActiveStatus = "your card is not active!!!";
            return View("LogIn");
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult LogOut()
    {
        OnlineCrad.card = null;

        return RedirectToAction("User", "LogIn");
    }
}
