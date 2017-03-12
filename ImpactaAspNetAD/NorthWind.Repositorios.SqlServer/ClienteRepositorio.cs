using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NorthWind.Repositorios.SqlServer.Ado
{
    public class ClienteRepositorio : RepositorioListaBase
    {
        public List<Cliente> SelecionarPorPais(string nomePais)
        {
            return base.ExecuteReader<Cliente>("ClienteSelecionarPorPais", Mapear, new SqlParameter("@country", nomePais));
        }

        private Cliente Mapear(SqlDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Nome = Convert.ToString(reader["ContactName"]);
            cliente.Codigo = reader["CustomerId"].ToString();
            cliente.Cidade = Convert.ToString(reader["City"]);
            cliente.Telefone = Convert.ToString(reader["Phone"]);

            return cliente;
        }
    }
}