using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MEC.ControleRDO.ViewComponets
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string SessionUser = HttpContext.Session.GetString("sessaoUsuaioLogado");

            if (String.IsNullOrEmpty(SessionUser)) return null;
            UsuarioVO usuario = JsonConvert.DeserializeObject<UsuarioVO>(SessionUser);

            return View(usuario);
        }
    }
}
