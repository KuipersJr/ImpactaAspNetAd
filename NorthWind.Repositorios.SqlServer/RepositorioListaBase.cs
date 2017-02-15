using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer
{
    public class RepositorioListaBase
    {
        protected string _stringConexao = ConfigurationManager.ConnectionStrings["northWindConnectionString"].ConnectionString;

        // params - apresentar depois.
        protected void ExecuteNonQuery(string nomeProcedure, params SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }

        protected List<Transportadora> ExecuteReader(string nomeProcedure, params SqlParameter[] parametros)
        {
            var tranportadoras = new List<Transportadora>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

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

        //protected IEnumerable<T> ExecuteReader<T>(string nomeProcedure, Func<SqlDataReader, T> metodoDeMapeamento, params SqlParameter[] parametros)
        protected List<T> ExecuteReader<T>(string nomeProcedure, Func<SqlDataReader, T> metodoDeMapeamento, params SqlParameter[] parametros)
        {
            var lista = new List<T>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = nomeProcedure;

                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros); 
                    }

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            // yield - acumular.
                            //yield return metodoDeMapeamento(registro);
                            lista.Add(metodoDeMapeamento(registro));
                        }
                    }
                }
            }

            return lista;
        }

        private Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();

            transportadora.Id = Convert.ToInt32(registro["ShipperId"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = registro["Phone"].ToString();

            return transportadora;
        }
    }
}