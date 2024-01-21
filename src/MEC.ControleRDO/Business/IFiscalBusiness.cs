using MEC.ControleRDO.Data.VO;

namespace MEC.ControleRDO.Business
{
    public interface IFiscalBusiness
    {
        FiscalVO Create(FiscalVO fiscal);
        FiscalVO Update(FiscalVO fiscal);
        List<FiscalVO> FindAll();
        FiscalVO FindById(long Id);
        void Delete(long Id);
    }
}
