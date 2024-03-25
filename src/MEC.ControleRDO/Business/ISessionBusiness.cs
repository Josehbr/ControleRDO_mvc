using MEC.ControleRDO.Data.VO;

namespace MEC.ControleRDO.Business
{
    public interface ISessionBusiness
    {
        void CreateSessaoUser(UsuarioVO usuario);
        UsuarioVO GetSessaoUser();
        void RemoveSessaoUser();

    }
}
