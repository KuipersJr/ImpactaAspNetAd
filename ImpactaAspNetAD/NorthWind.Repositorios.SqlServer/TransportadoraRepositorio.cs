using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NorthWind.Repositorios.SqlServer
{
    public class TransportadoraRepositorio : RepositorioListaBase
    {
        public List<Transportadora> Selecionar()
        {
            //throw new Exception("Teste");

            const string nomeProcedure = "TransportadoraSelecionar";

            return base.ExecuteReader<Transportadora>(nomeProcedure, Mapear, null);

            //return base.ExecuteReader(nomeProcedure, null);

            //var tranportadoras = new List<Transportadora>();

            //using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            //{
            //    conexao.Open();

            //    const string nomeProcedure = "TransportadoraSelecionar";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            while (registro.Read())
            //            {
            //                tranportadoras.Add(Mapear(registro));
            //            }
            //        }
            //    }
            //}

            //return tranportadoras;
        }

        public Transportadora Selecionar(int id)
        {
            const string nomeProcedure = "TransportadoraSelecionar";

            return base.ExecuteReader<Transportadora>(nomeProcedure, Mapear, new SqlParameter("shipperId", id)).FirstOrDefault();

            //return base.ExecuteReader(nomeProcedure, new SqlParameter("id", id)).FirstOrDefault();

            //var tranportadora = new Transportadora();

            //using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            //{
            //    conexao.Open();

            //    const string nomeProcedure = "TransportadoraSelecionar";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.Add(new SqlParameter("id", id));

            //        using (var registro = comando.ExecuteReader())
            //        {
            //            if (registro.Read())
            //            {
            //                tranportadora = Mapear(registro);
            //            }
            //        }
            //    }
            //}

            //return tranportadora;
        }

        private static Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();

            transportadora.Id = Convert.ToInt32(registro["ShipperId"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = registro["Phone"].ToString();

            return transportadora;
        }

        public void Inserir(Transportadora transportadora)
        {
            transportadora.Id = Convert.ToInt32(base.ExecuteScalar("TransportadoraInserir", Mapear(transportadora).ToArray()));             

            // Começar assim, depois refatorar.
            //using (var conexao = new SqlConnection(_stringConexao))
            //{
            //    conexao.Open();

            //    const string nomeProcedure = "TransportadoraInserir";

            //    using (var comando = new SqlCommand(nomeProcedure, conexao))
            //    {
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.AddRange(Mapear(transportadora).ToArray());
            //        comando.ExecuteNonQuery();
            //    }
            //}
        }

        private List<SqlParameter> Mapear(Transportadora transportadora)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("companyName", transportadora.Nome));
            parametros.Add(new SqlParameter("phone", transportadora.Telefone));

            return parametros;
        }

        public void Atualizar(Transportadora transportadora)
        {
            var parametros = Mapear(transportadora);
            parametros.Add(new SqlParameter("id", transportadora.Id));

            base.ExecuteNonQuery("TransportadoraAtualizar", parametros.ToArray());
        }

        public void Excluir(int id)
        {
            base.ExecuteNonQuery("TransportadoraExcluir", new SqlParameter("ShipperId", id));
        }
    }
}