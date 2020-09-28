
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogPostApi.Repository;
using Microsoft.Extensions.Options;
using BlogPostApi.Code;

namespace BlogPostApi.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryBase _repository;

        public IRepositoryBase Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = ServiceLocator.Find<IRepositoryBase>();
                }

                return _repository;
            }
        }

        public HomeController()
        {
            _repository = ServiceLocator.Find<IRepositoryBase>();
        }

        public IActionResult Cidades()
        {
            var cidades = _repository.SearchCidades(string.Empty);

            return new OkObjectResult(cidades);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
