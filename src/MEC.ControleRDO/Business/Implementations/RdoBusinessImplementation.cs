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

        public List<RdoVO> FindAll(string filterType, DateTime? startDate, DateTime? endDate, string numeroOrcamento)
        {
            List<RdoModel> rdos = _repository.FindAll();

            // Aplicar filtro por datas, se fornecido
            if (!string.IsNullOrEmpty(filterType) && startDate != null && endDate != null)
            {
                switch (filterType)
                {
                    case "DataEnvio":
                        rdos = rdos.Where(rdo => rdo.DataEnvio >= startDate && rdo.DataEnvio <= endDate).ToList();
                        break;
                    case "DataRdo":
                        rdos = rdos.Where(rdo => rdo.DataRdo >= startDate && rdo.DataRdo <= endDate).ToList();
                        break;
                    case "DataAssinatura":
                        rdos = rdos.Where(rdo => rdo.DataAssinatura >= startDate && rdo.DataAssinatura <= endDate).ToList();
                        break;
                    default:
                        break;
                }
            }

            // Aplicar filtro por número de orçamento associado à Obra, se fornecido
            if (!string.IsNullOrEmpty(numeroOrcamento))
            {
                rdos = rdos.Where(rdo => rdo.Obra.NumeroOrcamento == numeroOrcamento).ToList();
            }

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
            var rdoModel = _repository.FindById(Id);

            if (rdoModel == null)
            {
                // Lidar com o caso em que a entidade não é encontrada
                return null;
            }

            var obra = _obraRepository.FindById(rdoModel.ObraId);
            var fiscal = _fiscalRepository.FindById(obra.FiscalId);

            var rdoVO = _convert.Parser(rdoModel);

            rdoVO.NumeroOrcamento = obra?.NumeroOrcamento;
            rdoVO.NomeObra = obra?.Nome;
            rdoVO.NomeFiscal = fiscal?.Nome;

            return rdoVO;
        }


        public RdoVO Update(RdoVO rdo)
        {
            var rdoEntity = _convert.Parser(rdo);
            rdoEntity = _repository.Update(rdoEntity);
            return _convert.Parser(rdoEntity);
        }

        
    }
}
