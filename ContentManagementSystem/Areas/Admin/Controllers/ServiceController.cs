using BLL.Interfaces;
using ContentManagementSystem.Areas.Admin.ViewModels;
using DAL.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class ServiceController : Controller
    {


        private readonly IUnitOfWork _unit;

        public ServiceController(IUnitOfWork unit)
        {
            _unit = unit;
        }


        public IActionResult Index()
        {
            var AllService = _unit.serviceRepo.GetAll();

            var vm = AllService.Select(s => new ServiceViewModel()
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Icon = s.Icon,
            }).ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ServiceViewModel vm)
        {

            if (ModelState.IsValid)
            {
                _unit.serviceRepo.Add(new Service()
                { 

                    Title = vm.Title,
                    Description = vm.Description,
                    Icon = vm.Icon

                });


                _unit.Complete();

                return RedirectToAction(nameof(Index));
                
            }
            return View(vm);
        }


        [HttpGet]
        public IActionResult update(int id )
        {
            var service = _unit.serviceRepo.Get(id);
            var vm =  new ServiceViewModel()
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon
            } ;
            return View(vm);
        }


        [HttpPost]
        public IActionResult update(ServiceViewModel vm)
        {
            if (ModelState.IsValid)
            {

                _unit.serviceRepo.Update(new Service()
                {
                    Id = vm.Id,
                    Title = vm.Title,
                    Description= vm.Description,
                    Icon = vm.Icon
                });

                _unit.Complete(); 
                return RedirectToAction(nameof(Index));

            }

            return View(vm);
        }
         
        public IActionResult Delete(int id)
        {
            var service = _unit.serviceRepo.Get(id);

            if (service != null)
            {
                _unit.serviceRepo.Delete(service);
                _unit.Complete();
                
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
