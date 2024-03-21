using System.ComponentModel.DataAnnotations.Schema;

namespace MEC.ControleRDO.Models.Base
{
    public class BaseModel
    {

        [Column("id")]
        public long Id { get; set; }
    }
}
