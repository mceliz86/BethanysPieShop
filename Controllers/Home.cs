using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class Home : Controller
    {
        private readonly IPieRepository pieRepository;

        public Home(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = pieRepository.PiesOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}
