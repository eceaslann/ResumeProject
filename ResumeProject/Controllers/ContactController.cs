﻿using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class ContactController : Controller
    {
        DbResumeEntities db = new  DbResumeEntities();

        // GET: Contact
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }
    }
}