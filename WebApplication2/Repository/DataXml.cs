using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class DataXml
    {
        private readonly Database _db;

        public DataXml(Database db)
        {
            _db = db;
        }

        public void Insert(InformacoesXml dados)
        {
            var query = $@"
            INSERT INTO dados_xml 
            (Nome, CnpjPrestador, CnpjTomador, DataEmissao, DescricaoServico, ValorTotal) 
            VALUES 
            (
                '{dados.NumeroNota}', 
                '{dados.CnpjPrestador}', 
                '{dados.CnpjTomador}', 
                '{dados.DataEmissao:yyyy-MM-dd}', 
                '{dados.DescricaoServico}', 
                {dados.ValorTotal}
            )";

            _db.ExecuteNonQuery(query);
        }

    }
}
