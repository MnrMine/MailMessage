using Microsoft.AspNetCore.Mvc;

namespace MailMessage.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
