using MEC.ControleRDO.Data.Convert.Contract;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;

namespace MEC.ControleRDO.Data.Convert.Implementaions
{
    public class RdoConvert : IParser<RdoVO, RdoModel>, IParser<RdoModel, RdoVO>
    {
        public RdoModel Parser(RdoVO origin)
        {
            if (origin == null) return null;
            return new RdoModel
            {
                Id = origin.Id,
                DataRdo = origin.DataRdo,
                DataEnvio = origin.DataEnvio,
                DataAssinatura = origin.DataAssinatura,
                Assinatura = origin.Assinatura,
                Observacao = origin.Observacao,
                ObraId = origin.ObraId
            };
        }

        public RdoVO Parser(RdoModel origin)
        {
            if (origin == null) return null;
            return new RdoVO
            {
                Id = origin.Id,
                DataRdo = origin.DataRdo,
                DataEnvio = origin.DataEnvio,
                DataAssinatura = origin.DataAssinatura,
                Assinatura = origin.Assinatura,
                Observacao = origin.Observacao,
                ObraId = origin.ObraId
            };
        }

        public List<RdoModel> Parser(List<RdoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<RdoVO> Parser(List<RdoModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
