using MEC.ControleRDO.Data.VO;

namespace MEC.ControleRDO.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioVO Create(UsuarioVO usuario);
        UsuarioVO Update(UsuarioVO fiusuarioscal);
        List<UsuarioVO> FindAll();
        UsuarioVO FindById(long Id);
        void Delete(long Id);
    }
}
