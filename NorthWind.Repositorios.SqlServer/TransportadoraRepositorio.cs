using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class TransportadoraRepositorio : RepositorioListaBase
    {
        public List<Transportadora> Selecionar()
        {
            var tranportadoras = new List<Transportadora>();

            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            {
                conexao.Open();

                const string nomeProcedure = "TransportadoraSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tranportadoras.Add(Mapear(registro));
                        }
                    }
                }
            }

            return tranportadoras;
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
            // Começar assim, depois refatorar.
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TransportadoraInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(transportadora).ToArray());
                    comando.ExecuteNonQuery();
                }
            }
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
            base.ExecuteNonQuery("TransportadoraExcluir", new SqlParameter("id", id));
        }
    }
}