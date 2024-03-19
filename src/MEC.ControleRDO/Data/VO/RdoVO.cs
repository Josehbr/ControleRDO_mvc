using System;
using System.Collections.Generic;
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
        //PerfilEnumValidation(ErrorMessage = "O perfil selecionado não é válido.")]
        public bool Assinatura { get; set; }

        public string? Observacao { get; set; }

        [Display(Name = "Nome do Fiscal")]
        public string NomeFiscal { get; set; }

        [Display(Name = "Numero do orçamento")]
        public string NumeroOrcamento { get; set; }

        [Display(Name = "Nome da obra")]
        [Required(ErrorMessage = "O local da obra é obrigatório")]
        public string NomeObra { get; set; }

        [Display(Name = "Nome da obra")]
        public long ObraId { get; set; }
        public virtual ObraVO Obra { get; set; }

        public List<ObraVO> ListaObra { get; set; }
    }
}
