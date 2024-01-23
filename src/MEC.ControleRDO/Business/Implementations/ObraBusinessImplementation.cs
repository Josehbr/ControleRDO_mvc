using MEC.ControleRDO.Data.Convert.Implementaions;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using MEC.ControleRDO.Repository.Generic;

namespace MEC.ControleRDO.Business.Implementations
{
    public class ObraBusinessImplementation : IObraBusiness
    {
        private readonly IRepository<ObraModel> _repository;
        private readonly ObraConvert _convert;

        public ObraBusinessImplementation(IRepository<ObraModel> repository)
        {
            _repository = repository;
            _convert = new ObraConvert();
        }
        public ObraVO Create(ObraVO obra)
        {
            var obraEntity = _convert.Parser(obra);
            obraEntity = _repository.Create(obraEntity);
            return _convert.Parser(obraEntity);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<ObraVO> FindAll()
        {
            return _convert.Parser(_repository.FindAll());
        }

        public ObraVO FindById(long Id)
        {
            return _convert.Parser(_repository.FindById(Id));
        }

        public ObraVO Update(ObraVO obra)
        {
            var obraEntity = _convert.Parser(obra);
            obraEntity = _repository.Update(obraEntity);
            return _convert.Parser(obraEntity);
        }
    }
}
