using MEC.ControleRDO.Data.Convert.Contract;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using System.Collections.Generic;
using System.Linq;

namespace MEC.ControleRDO.Data.Convert.Implementaions
{
    public class ObraConvert : IParser<ObraVO, ObraModel>
    {
        public ObraModel Parser(ObraVO origin)
        {
            return origin == null ? null : new ObraModel
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
            return origin == null ? null : new ObraVO
            {
                Id = origin.Id,
                NumeroOrcamento = origin.NumeroOrcamento,
                Nome = origin.Nome,
                SE = origin.SE,
                FiscalId = origin.FiscalId
            };
        }

        public List<ObraModel> Parser(List<ObraVO> originList)
        {
            return originList?.Select(Parser).ToList();
        }

        public List<ObraVO> Parser(List<ObraModel> originList)
        {
            return originList?.Select(Parser).ToList();
        }
    }
}
