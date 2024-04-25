using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MailMessage.ViewComponents
{
    public class _SidebarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MailMessageContext _context;

        public _SidebarComponentPartial(UserManager<AppUser> userManager, MailMessageContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Inbox = _context.Messages.Where(x => x.ReceiverMail == values.Email).Count();
            ViewBag.Sendbox = _context.Messages.Where(x => x.SenderMail == values.Email && x.Status == true && x.IsDraft == false).Count();
            ViewBag.Draft = _context.Drafts.Count();
            ViewBag.Delete = _context.Messages.Where(x => x.Status == false).Count();
            return View(values);
        }
    }
}
