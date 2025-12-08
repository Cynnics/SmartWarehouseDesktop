
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace SmartWarehouseDesktop
{
    public static class FontManager
    {
        private static PrivateFontCollection fuentes = new PrivateFontCollection();

        public static FontFamily CargarFuente(string nombreArchivo)
        {
            string ruta = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Resources",
                nombreArchivo);

            if (File.Exists(ruta))
            {
                fuentes.AddFontFile(ruta);
                return fuentes.Families[fuentes.Families.Length - 1];
            }
            else
            {
                throw new FileNotFoundException($"No se encontró la fuente: {ruta}");
            }
        }

        public static Font ObtenerFuente(string nombreArchivo, float tamaño, FontStyle estilo = FontStyle.Regular)
        {
            var familia = CargarFuente(nombreArchivo);
            return new Font(familia, tamaño, estilo);
        }
    }
}
