using MEC.ControleRDO.Data.Convert.Contract;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;

namespace MEC.ControleRDO.Data.Convert.Implementaions
{
    public class ObraConvert : IParser<ObraVO, ObraModel>
    {
        public ObraModel Parser(ObraVO origin)
        {
            if (origin == null) return null;
            return new ObraModel
            {
                Id = origin.Id,
                NumeroOrcamento = origin.NumeroOrcamento,
                Nome = origin.Nome,
                SE = origin.SE,
                FiscalId = origin.FiscalId
            };
        }

        public ObraVO Parser(ObraModel origin)
        {
            if (origin == null) return null;
            return new ObraVO
            {
                Id = origin.Id,
                NumeroOrcamento = origin.NumeroOrcamento,
                Nome = origin.Nome,
                SE = origin.SE,
                FiscalId = origin.FiscalId
            };
        }

        public List<ObraModel> Parser(List<ObraVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<ObraVO> Parser(List<ObraModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
