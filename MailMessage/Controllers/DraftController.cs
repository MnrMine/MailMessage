using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MailMessage.Controllers
{
    public class DraftController : Controller
    {
        Draft_Manager draftManager = new Draft_Manager(new EfDraft_Dal());
        private readonly UserManager<AppUser> _userManager;

        public DraftController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult DraftMessageList()
        {
            var values = draftManager.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult DraftMessageSave()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> DraftMessageSave(Draft p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.SenderMail = mail;
            p.SenderName = name;
            p.Status = true;
            MailMessageContext c = new MailMessageContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            draftManager.TInsert(p);
            return RedirectToAction("DraftMessageList");

        }
        public IActionResult DraftOut(int id)
        {
            draftManager.TDelete(id);
            return RedirectToAction("DraftMessageList");
        }
    }
}
