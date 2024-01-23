using MEC.ControleRDO.Data.VO;

namespace MEC.ControleRDO.Business
{
    public interface IRdoBusiness
    {
        RdoVO Create(RdoVO rdo);
        RdoVO Update(RdoVO rdo);
        List<RdoVO> FindAll();
        RdoVO FindById(long Id);
        void Delete(long Id);
    }
}
