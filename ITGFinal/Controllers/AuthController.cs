using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITGFinal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITGFinal.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserContext db;
        public AuthController(UserContext context)
        {
            db = context;
        }

        public string Index()
        {
            return "noOK";
        }

        [HttpPost]
        public async Task<string> Index(string token)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Token == token);
            if (user != null)
            {
                return "OK";
            }
            else return "NoOK";
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Login(LoginModel model)
        {

            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                return user.Token;
            }
            return "Некорректные логин и(или) пароль";
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Register(RegisterModel model)
        {

                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.Users.Add(new User { Email = model.Email, Password = model.Password, Token = "" });

                    

                    return user.Token;
                }
                else
                return "Некорректные логин и(или) пароль";

        }
    }
}
