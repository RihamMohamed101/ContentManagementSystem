using BLL.Interfaces;
using ContentManagementSystem.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ContentManagementSystem.Areas.Admin.Controllers
{


    [Area("Admin")]

    public class MessageController : Controller
    {


        private readonly IUnitOfWork _unit;

        public MessageController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index(string search)
        {

            var msgs = string.IsNullOrEmpty(search)
             ? _unit.ContactRepo.GetAll()
             : _unit.ContactRepo.Find(m => m.Name.Contains(search));

            var msgVm = msgs.Select(c => new MessageViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                TimeAgo = (DateTime.Now - c.CreatedAt).TotalHours < 24
                           ? $"{(DateTime.Now - c.CreatedAt).Hours} hours ago"
                           : c.CreatedAt.ToString("MMM dd, yyyy"),
              IsRead = c.IsRead ?? false

            }).ToList();
            return View(msgVm);
        }


        public ActionResult Delete(int id)
        {
            var msg = _unit.ContactRepo.Get(id);

            if (msg != null)
            {
                _unit.ContactRepo.Delete(msg);
                _unit.Complete();
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult ToggleReadStatus(int id)
        {
            var msg = _unit.ContactRepo.Get(id);

            if (msg != null)
            {
                msg.IsRead = (msg.IsRead == true) ? false : true;
                _unit.ContactRepo.Update(msg);
                _unit.Complete();
            }

            return RedirectToAction(nameof(Index)); 
        }
    }
}
