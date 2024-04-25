using Microsoft.AspNetCore.Mvc;

namespace MailMessage.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
