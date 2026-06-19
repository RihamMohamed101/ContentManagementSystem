using BLL.Interfaces;
using ContentManagementSystem.Areas.Admin.ViewModels;
using ContentManagementSystem.ViewModels;
using DAL.DomainModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContentManagementSystem.Controllers
{
    public class HomeController : Controller
    {


        private readonly IUnitOfWork _unit;

        public HomeController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var heroData = _unit.HeroRepo.GetAll().FirstOrDefault();
            var aboutData = _unit.AboutRepo.GetAll().FirstOrDefault();
            var servicesData = _unit.serviceRepo.GetAll().ToList();

            var vm = new HomeViewModel
            {
                HeroSection = new HeroSection
                {
                    Title = heroData?.Title,
                    Description = heroData?.Description,
                    ImageUrl = heroData?.ImageUrl

                },

                AboutSection = new AboutSection
                {
                    Title = aboutData?.Title,
                    Description = aboutData?.Description,
                    ImageUrl = aboutData?.ImageUrl
                },

                ServicesList = servicesData.Select(s => new Service
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Icon = s.Icon
                }).ToList()
            };

            return View(vm);
        }


        public IActionResult saveMessage(ContactMessage msg)
        {

            if(ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Thank you! Your message has been sent successfully.";

                _unit.ContactRepo.Add(msg);

                _unit.Complete();
                return RedirectToAction(nameof(Index));

            }

            TempData["ErrorMessage"] = "Please check your inputs and try again.";

            return RedirectToAction(nameof(Index));

        }
    }
}
