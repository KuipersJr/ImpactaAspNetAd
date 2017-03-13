using System;

namespace Pubs.Dominio
{
    public class Comentario : EntidadeBase
    {
        public Comentario()
        {
            DataPublicacao = DateTime.Now;
        }

        public string Autor { get; set; }
        public string Texto { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}