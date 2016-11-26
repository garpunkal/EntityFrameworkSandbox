using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using garpunkal.EntityFrameworkSandbox.Business.Interfaces;
using garpunkal.EntityFrameworkSandbox.Data.Entities;
using garpunkal.EntityFrameworkSandbox.Web.AutoMapper;
using garpunkal.EntityFrameworkSandbox.Web.Models;

namespace garpunkal.EntityFrameworkSandbox.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}