using MEC.ControleRDO.Data.Convert.Contract;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;

namespace MEC.ControleRDO.Data.Convert.Implementaions
{
    public class FiscalConvert : IParser<FiscalVO, FiscalModel>, IParser<FiscalModel, FiscalVO>
    {
        public FiscalModel Parser(FiscalVO origin)
        {
            if (origin == null) return null;
            return new FiscalModel
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email
            };
        }

        public FiscalVO Parser(FiscalModel origin)
        {
            if (origin == null) return null;
            return new FiscalVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Email = origin.Email
            };
        }

        public List<FiscalModel> Parser(List<FiscalVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<FiscalVO> Parser(List<FiscalModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
