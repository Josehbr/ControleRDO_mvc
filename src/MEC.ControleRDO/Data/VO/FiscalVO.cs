using System.ComponentModel.DataAnnotations;

namespace MEC.ControleRDO.Data.VO
{
    public class FiscalVO
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O email fornecido não é válido")]
        public string Email { get; set; }

        public virtual ICollection<ObraVO> obra { get; set; }
    }
}
