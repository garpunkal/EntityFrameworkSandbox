using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using garpunkal.EntityFrameworkSandbox.Business.Interfaces;
using garpunkal.EntityFrameworkSandbox.Data.Entities;
using garpunkal.EntityFrameworkSandbox.Web.Models;

namespace garpunkal.EntityFrameworkSandbox.Web.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;
        private readonly MapperConfiguration _mapperConfiguration;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Developer, DeveloperViewModel>());
        }

        public ActionResult Index()
        {
            var developers = _developerService.GetAll().OrderBy(c => c.Name);
            
            var mapper = _mapperConfiguration.CreateMapper();

            var viewModels = mapper.Map<IEnumerable<DeveloperViewModel>>(developers);

            return View(viewModels);
        }
    }
}