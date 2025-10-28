using Microsoft.Data.SqlClient;
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
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand("INSERT INTO dados_xml (NumeroNota, CnpjPrestador, CnpjTomador, DataEmissao, DescricaoServico, ValorTotal) VALUES (@NumeroNota, @CnpjPrestador, @CnpjTomador, @DataEmissao, @DescricaoServico, @ValorTotal)", conn))
            {
                cmd.Parameters.AddWithValue("@NumeroNota", dados.NumeroNota);
                cmd.Parameters.AddWithValue("@CnpjPrestador", dados.CnpjPrestador);
                cmd.Parameters.AddWithValue("@CnpjTomador", dados.CnpjTomador);
                cmd.Parameters.AddWithValue("@DataEmissao", DateTime.Parse(dados.DataEmissao));
                cmd.Parameters.AddWithValue("@DescricaoServico", dados.DescricaoServico);
                cmd.Parameters.AddWithValue("@ValorTotal", dados.ValorTotal);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
