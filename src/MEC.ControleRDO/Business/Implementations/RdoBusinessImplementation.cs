using MEC.ControleRDO.Data.Convert.Implementaions;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using MEC.ControleRDO.Repository.Generic;

namespace MEC.ControleRDO.Business.Implementations
{
    public class RdoBusinessImplementation : IRdoBusiness
    {
        private readonly IRepository<RdoModel> _repository;

        private readonly IRepository<ObraModel> _obraRepository;

        private readonly IRepository<FiscalModel> _fiscalRepository;

        private readonly RdoConvert _convert;

        public RdoBusinessImplementation(IRepository<RdoModel> repository, IRepository<ObraModel> obraRepository, IRepository<FiscalModel> fiscalRepository)
        {
            _repository = repository;
            _convert = new RdoConvert();
            _obraRepository = obraRepository;
            _fiscalRepository = fiscalRepository;
        }
        public RdoVO Create(RdoVO rdo)
        {
            var rdoEntity = _convert.Parser(rdo);
            rdoEntity = _repository.Create(rdoEntity);
            return _convert.Parser(rdoEntity);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<RdoVO> FindAll()
        {
            List<RdoModel> rdos = _repository.FindAll();

            var JoinRdo = rdos.Select(rdo =>
            {
                var obra = _obraRepository.FindById(rdo.ObraId);
                var fiscal = _fiscalRepository.FindById(obra.FiscalId);

                var rdoVO = _convert.Parser(rdo);


                rdoVO.NumeroOrcamento = obra?.NumeroOrcamento;
                rdoVO.NomeObra = obra?.Nome;

                rdoVO.NomeFiscal = fiscal?.Nome;

                return rdoVO;
            }).ToList();

            return JoinRdo;
        }

        public RdoVO FindById(long Id)
        {
            return _convert.Parser(_repository.FindById(Id));
        }

        public RdoVO Update(RdoVO rdo)
        {
            var rdoEntity = _convert.Parser(rdo);
            rdoEntity = _repository.Update(rdoEntity);
            return _convert.Parser(rdoEntity);
        }
    }
}
