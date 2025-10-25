namespace WebApplication2.Models
{
    public class InformacoesXml
    {
        public int NumeroNota { get; set; }
        public string CnpjPrestador { get; set; } = string.Empty;
        public string CnpjTomador { get; set; } = string.Empty;
        public string DataEmissao { get; set; } = string.Empty;
        public string DescricaoServico { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
    }
}
