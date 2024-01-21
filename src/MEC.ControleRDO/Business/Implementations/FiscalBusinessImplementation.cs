using MEC.ControleRDO.Data.Convert.Implementaions;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using MEC.ControleRDO.Repository.Generic;

namespace MEC.ControleRDO.Business.Implementations
{
    public class FiscalBusinessImplementation : IFiscalBusiness
    {
        private readonly IRepository<FiscalModel> _repository;
        private readonly FiscalConvert _convert;

        public FiscalBusinessImplementation(IRepository<FiscalModel> repository)
        {
            _repository = repository;
            _convert = new FiscalConvert();
        }

        public FiscalVO Create(FiscalVO fiscal)
        {
            var fiscalEntity = _convert.Parser(fiscal);
            fiscalEntity = _repository.Create(fiscalEntity);
            return _convert.Parser(fiscalEntity);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<FiscalVO> FindAll()
        {
            return _convert.Parser(_repository.FindAll());
        }

        public FiscalVO FindById(long Id)
        {
            return _convert.Parser(_repository.FindById(Id));
        }

        public FiscalVO Update(FiscalVO fiscal)
        {
            var fiscalEntity = _convert.Parser(fiscal);
            fiscalEntity = _repository.Update(fiscalEntity);
            return _convert.Parser(fiscalEntity);
        }
    }
}
