using MEC.ControleRDO.Data.VO;

namespace MEC.ControleRDO.Business
{
    public interface IObraBusiness
    {
        ObraVO Create(ObraVO obra);
        ObraVO Update(ObraVO obra);
        List<ObraVO> FindAll();
        ObraVO FindById(long Id);
        void Delete(long Id);
    }
}
