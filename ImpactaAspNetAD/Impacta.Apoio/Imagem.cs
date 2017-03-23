using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Impacta.Apoio
{
    public static class Imagem
    {
        public static byte[] ObterMiniatura(byte[] imagem, int largura, int altura)
        {
            using (var stream = new MemoryStream())
            {
                using (var miniatura = Image.FromStream(new MemoryStream(imagem)).GetThumbnailImage(largura, altura, null, new IntPtr()))
                {
                    miniatura.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }
}