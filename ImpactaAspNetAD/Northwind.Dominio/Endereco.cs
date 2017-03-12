namespace Northwind.Dominio
{
    public class Endereco
    {
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Logradouro { get; set; }
    }
}