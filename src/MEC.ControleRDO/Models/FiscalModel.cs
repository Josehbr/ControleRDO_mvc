using MEC.ControleRDO.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEC.ControleRDO.Models
{
    [Table("Fiscais")]
    public class FiscalModel : BaseModel
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }


        // Relacionamento: Um Fiscal pode ter várias Obras
        public virtual ICollection<ObraModel> Obras { get; set; }
    }
}
