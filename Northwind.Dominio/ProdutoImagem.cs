﻿namespace Northwind.Dominio
{
    public class ProdutoImagem
    {
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public byte[] Bytes { get; set; }
    }
}