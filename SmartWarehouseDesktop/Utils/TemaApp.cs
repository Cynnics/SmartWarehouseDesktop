using System.Drawing;

namespace SmartWarehouseDesktop
{
    public static class TemaApp
    {
        public static Color AzulOscuro = ColorTranslator.FromHtml("#142747");
        public static Color AzulIntermedio= ColorTranslator.FromHtml("#248094");
        public static Color AzulClaro = ColorTranslator.FromHtml("#33d8e1");
        public static Color Naranja = ColorTranslator.FromHtml("#ed7f42");
        public static Color FondoClaro = ColorTranslator.FromHtml("#F4F4F4");
        public static Color TextoOscuro = Color.Black;

       
        public static Font FuenteTitulo =>
            FontManager.ObtenerFuente("Poppins-Bold.ttf", 14f, FontStyle.Bold);

        public static Font FuenteGeneral =>
            FontManager.ObtenerFuente("Poppins-Regular.ttf", 10f, FontStyle.Regular);

        public static Font FuenteBoton =>
            FontManager.ObtenerFuente("Roboto-Bold.ttf", 11f, FontStyle.Bold);
    }
}
