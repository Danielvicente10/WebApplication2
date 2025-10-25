using System.Xml;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Services
{
    public class AppLeituraXmlService
    {
        private readonly DataXml _dataXml;

        public AppLeituraXmlService(DataXml dataXml)
        {
            _dataXml = dataXml;
        }

        public InformacoesXml LerXml(IFormFile arquivoXml)
        {
            XmlDocument doc = new XmlDocument();

            var dados = new InformacoesXml();

            using (var stream = arquivoXml.OpenReadStream())
            {
                doc.Load(stream);
            }

            dados.NumeroNota = int.Parse(doc.SelectSingleNode("//Numero")?.InnerText ?? "0");
            dados.CnpjPrestador = doc.SelectSingleNode("//Prestador/Cnpj")?.InnerText ?? string.Empty;
            dados.CnpjTomador = doc.SelectSingleNode("//Tomador/Cnpj")?.InnerText ?? string.Empty;
            dados.DataEmissao = doc.SelectSingleNode("//DataEmissao")?.InnerText ?? string.Empty;
            dados.DescricaoServico = doc.SelectSingleNode("//Servico/Descricao")?.InnerText ?? string.Empty;
            dados.ValorTotal = decimal.Parse(doc.SelectSingleNode("//Servico/ValorTotal")?.InnerText ?? "0", System.Globalization.CultureInfo.InvariantCulture);


            return dados;

        }

        public void Insert(InformacoesXml dados)
        {
            _dataXml.Insert(dados);
        }
    }
}
