using Microsoft.AspNetCore.Mvc;

namespace MailMessage.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
