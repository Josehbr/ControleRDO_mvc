﻿using MEC.ControleRDO.Enum;
using MEC.ControleRDO.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEC.ControleRDO.Models
{
    [Table("Rdos")]
    public class RdoModel : BaseModel
    {
        [Column("data_rdo")]
        public DateTime DataRdo { get; set; }

        [Column("data_envio")]
        public DateTime DataEnvio { get; set; }

        [Column("data_assinatura")]
        public DateTime? DataAssinatura { get; set; }

        [Column("assinatura")]
        public AssEnum Assinatura { get; set; }

        [Column("observacao")]
        public string? Observacao { get; set; }

        // Relacionamento: Um Rdo pertence a uma única Obra
        public long ObraId { get; set; }
        public virtual ObraModel Obra { get; set; }
    }
}
