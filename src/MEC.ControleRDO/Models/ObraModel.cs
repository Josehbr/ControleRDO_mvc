using MEC.ControleRDO.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEC.ControleRDO.Models
{
    [Table("Obras")]
    public class ObraModel : BaseModel
    {
        [Column("numero_do_orcamento")]
        public string NumeroOrcamento { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("SE")]
        public string SE { get; set; }


        // Relacionamento: Uma Obra pertence a um único Fiscal
        public long FiscalId { get; set; }
        public virtual FiscalModel Fiscal { get; set; }


        // Relacionamento: Uma Obra pode ter vários Rdos
        public virtual ICollection<RdoModel> Rdos { get; set; }
    }
}
