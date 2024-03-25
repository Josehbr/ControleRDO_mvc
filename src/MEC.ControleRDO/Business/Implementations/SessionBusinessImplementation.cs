using MEC.ControleRDO.Data.VO;
using Newtonsoft.Json;

namespace MEC.ControleRDO.Business.Implementations
{
    public class SessionBusinessImplementation : ISessionBusiness
    {
        private readonly IHttpContextAccessor _httpContext;

        public SessionBusinessImplementation(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateSessaoUser(UsuarioVO usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuaioLogado", valor);
        }

        public UsuarioVO GetSessaoUser()
        {
            string SessionUser = _httpContext.HttpContext.Session.GetString("sessaoUsuaioLogado");

            if(string.IsNullOrEmpty(SessionUser)) return null;

            return JsonConvert.DeserializeObject<UsuarioVO>(SessionUser);
        }

        public void RemoveSessaoUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuaioLogado");
        }
    }
}
