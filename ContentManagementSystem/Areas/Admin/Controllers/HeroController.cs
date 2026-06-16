using BLL.Interfaces;
using BLL.Repository;
using ContentManagementSystem.Areas.Admin.ViewModels;
using ContentManagementSystem.Helper;
using DAL.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HeroController : Controller
    {
        private readonly IUnitOfWork _unit;

        public HeroController(IUnitOfWork unit)
        {
            _unit = unit;
        }


        public IActionResult Index()
        {
            HeroSection hero = _unit.HeroRepo.GetAll().FirstOrDefault();
            HeroViewModel vm = new HeroViewModel();

            if (hero!=null)
            {
                vm.Title = hero.Title;
                vm.Description = hero.Description;
                vm.ImageUrl = hero.ImageUrl;

            }
            return View(vm);

        }


        public IActionResult AddHero(HeroViewModel vm)
        {
          if (ModelState.IsValid)
          {
           HeroSection hero = _unit.HeroRepo.GetAll().FirstOrDefault();


           if (vm.ImageFile != null)
             {
                    vm.ImageUrl = DocumentSettings.uploadFile(vm.ImageFile, "images");
              }

           if (hero!=null)
             {
                    //updat
                hero.Title = vm.Title;
                hero.Description = vm.Description;
                hero.ImageUrl = vm.ImageUrl;
                _unit.HeroRepo.Update(hero);
             }

           else
             {
                    //Add
                    _unit.HeroRepo.Add(new HeroSection()
                    {
                        Title = vm.Title,
                        Description = vm.Description,
                        ImageUrl = vm.ImageUrl
                    });
                 
             }

                _unit.Complete();

            }

            return View("index", vm);
        }
    }
}
