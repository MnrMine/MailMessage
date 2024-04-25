using Microsoft.AspNetCore.Mvc;

namespace MailMessage.ViewComponents
{
    public class _ScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
