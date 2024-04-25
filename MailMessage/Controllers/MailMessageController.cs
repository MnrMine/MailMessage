using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MailMessage.Controllers
{
    public class MailMessageController : Controller
    {
        Mesage_Manager mesage_manager = new Mesage_Manager(new EfMessage_Dal());
        private readonly UserManager<AppUser> _userManager;

        public MailMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = mesage_manager.GetListReceiverMessage(p);
            return View(messageList);
        }
        public IActionResult InboxMessageDetails(int id)
        {
            Message message = mesage_manager.TGetById(id);
            return View(message);
        }
        public async Task<IActionResult> Sendbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = mesage_manager.GetListSenderMessage(p);
            return View(messageList);
        }
        public IActionResult SendboxMessageDetails(int id)
        {
            Message message = mesage_manager.TGetById(id);
            return View(message);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.SenderMail = mail;
            p.SenderName = name;
            p.Status = true;
            p.IsDraft = false;
            p.IsRead = false;
            MailMessageContext c = new MailMessageContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            mesage_manager.TInsert(p);
            return RedirectToAction("Inbox");

        }
        public IActionResult TrashMessageList()
        {
            var values = mesage_manager.GetListDeleteMessage();
            return View(values);
        }
        public IActionResult TrashMessages(int id)
        {
            MailMessageContext _context = new MailMessageContext();
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
        public IActionResult TrashOutMessages(int id)
        {
            MailMessageContext _context = new MailMessageContext();
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
    }
}
