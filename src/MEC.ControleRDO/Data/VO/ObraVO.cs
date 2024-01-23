﻿namespace MEC.ControleRDO.Data.VO
{
    public class ObraVO
    {
        public long Id { get; set; }
        public string NumeroOrcamento { get; set; }

        public string Nome { get; set; }

        public string SE { get; set; }

        // Relacionamento: Uma Obra pertence a um único Fiscal
        public long FiscalId { get; set; }
        public virtual FiscalVO Fiscal { get; set; }


        // Relacionamento: Uma Obra pode ter vários Rdos
        public virtual ICollection<RdoVO> Rdos { get; set; }

        public List<FiscalVO> ListaDeFiscais { get; set; }
    }
}
