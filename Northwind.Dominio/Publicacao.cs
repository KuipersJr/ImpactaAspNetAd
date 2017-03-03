namespace Northwind.Dominio
{
    public class Publicacao
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }

        public string Titulo { get; set; }
        public string Isbn { get; set; }
    }
}