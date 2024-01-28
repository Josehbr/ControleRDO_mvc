using System.ComponentModel.DataAnnotations;

namespace MEC.ControleRDO.Data.VO
{
    public class RdoVO
    {
        public long Id { get; set; }

        [Display(Name = "Data do Rdo")]
        public DateTime DataRdo { get; set; }
        [Display(Name = "Data do envio")]
        public DateTime DataEnvio { get; set; }
        [Display(Name = "Data do assinatura")]
        public DateTime? DataAssinatura { get; set; }
        
        public bool Assinatura { get; set; }

        public string? Observacao { get; set; }
        [Display(Name = "Nome do Fiscal")]
        public string NomeFiscal { get; set; }
        [Display(Name = "Numero do orçamento")]
        public string NumeroOrcamento { get; set; }
        [Display(Name = "Nome da obra")]
        public string NomeObra { get; set; }
        public long ObraId { get; set; }
        public virtual ObraVO Obra { get; set; }

        public List<ObraVO> ListaObra { get; set; }



    }
}
