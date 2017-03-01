namespace Northwind.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        //public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
}