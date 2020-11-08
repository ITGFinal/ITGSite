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
    public class SoundController : Controller
    {
        private readonly SoundContext db;
        public SoundController(SoundContext context)
        {
            db = context;
        }

    }
}
