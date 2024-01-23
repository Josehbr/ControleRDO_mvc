namespace MEC.ControleRDO.Data.VO
{
    public class RdoVO
    {
        public long Id { get; set; }

        public DateTime DataRdo { get; set; }

        public DateTime DataEnvio { get; set; }

        public DateTime DataAssinatura { get; set; }

        public int Assinatura { get; set; }

        public string Observacao { get; set; }

        public string NomeFiscal { get; set; }

        public string NumeroOrcamento { get; set; }
        public string NomeObra { get; set; }
        public long ObraId { get; set; }
        public virtual ObraVO Obra { get; set; }

    }
}
