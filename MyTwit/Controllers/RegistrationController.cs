﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwit.Interfaces;
using MyTwit.Models;

namespace MyTwit.Controllers
{
    public class RegistrationController : Controller
    {
        private IUserRepository rep;
        public RegistrationController(IUserRepository repo)
        {
            rep = repo;
        }
        // GET: Registration
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string regUsername, string regPass)
        {
            if (rep.GetUser(regUsername) == null)
            {
                string hashPass = Hash.CreateMd5(regPass);
                rep.SignUp(regUsername, hashPass);
                return Redirect("/Auth/Auth");
            }
            return View();
        }
    }
}