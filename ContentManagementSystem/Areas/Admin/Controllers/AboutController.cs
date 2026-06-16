using BLL.Interfaces;
using ContentManagementSystem.Areas.Admin.ViewModels;
using ContentManagementSystem.Helper;
using DAL.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unit;

        public AboutController(IUnitOfWork unit)
        {
            _unit = unit;
        }


        public IActionResult Index()
        {
            AboutSection about = _unit.AboutRepo.GetAll().FirstOrDefault();
            AboutViewModel vm = new AboutViewModel();

            if (about != null)
            {
                vm.Title = about.Title;
                vm.Description = about.Description;
                vm.ImageUrl = about.ImageUrl;
                vm.Subtitle = about.Subtitle;

            }
            return View(vm);

        }

        public IActionResult AddAbout(AboutViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AboutSection about = _unit.AboutRepo.GetAll().FirstOrDefault();


                if (vm.ImageFile != null)
                {
                    vm.ImageUrl = DocumentSettings.uploadFile(vm.ImageFile, "images");
                }

                if (about != null)
                {
                    //updat
                    about.Title = vm.Title;
                    about.Subtitle = vm.Subtitle;
                    about.Description = vm.Description;
                    about.ImageUrl = vm.ImageUrl;
                    _unit.AboutRepo.Update(about);
                }

                else
                {
                    //Add
                    _unit.AboutRepo.Add(new AboutSection()
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
