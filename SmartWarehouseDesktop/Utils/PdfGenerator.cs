using iTextSharp.text;
using iTextSharp.text.pdf;
using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.Utils
{
    /// <summary>
    /// Clase para generar PDFs de facturas usando iTextSharp
    /// </summary>
    public class PdfGenerator
    {
        private readonly DetallePedidoService _detalleService = new DetallePedidoService();
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly UserService _userService = new UserService();

        // Colores corporativos
        private static readonly BaseColor ColorPrimario = new BaseColor(25, 118, 210); // #1976D2
        private static readonly BaseColor ColorSecundario = new BaseColor(33, 33, 33);
        private static readonly BaseColor ColorFondo = new BaseColor(245, 245, 245);
        private static readonly BaseColor ColorExito = new BaseColor(76, 175, 80);

        /// <summary>
        /// Genera un PDF de factura y lo guarda en el directorio especificado
        /// </summary>
        public async Task<string> GenerarFacturaPdf(
            FacturaApiModel factura,
            PedidoApiModel pedido,
            string rutaDestino = null)
        {
            try
            {
                // Determinar ruta de guardado
                if (string.IsNullOrEmpty(rutaDestino))
                {
                    string carpetaFacturas = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "SmartWarehouse",
                        "Facturas"
                    );
                    Directory.CreateDirectory(carpetaFacturas);
                    rutaDestino = Path.Combine(
                        carpetaFacturas,
                        $"Factura_{factura.IdFactura}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                    );
                }

                // Crear documento PDF
                Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaDestino, FileMode.Create));

                documento.Open();

                // Agregar contenido
                AgregarEncabezado(documento, factura);
                AgregarSeparador(documento);
                await AgregarDatosCliente(documento, pedido);
                AgregarSeparador(documento);
                await AgregarDetallesPedido(documento, pedido.IdPedido);
                AgregarSeparador(documento);
                AgregarTotales(documento, factura);
                AgregarPiePagina(documento, factura);

                documento.Close();

                return rutaDestino;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar PDF: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Encabezado con logo y datos de la empresa
        /// </summary>
        private void AgregarEncabezado(Document doc, FacturaApiModel factura)
        {
            // Tabla para encabezado (2 columnas)
            PdfPTable tabla = new PdfPTable(2)
            {
                WidthPercentage = 100
            };
            tabla.SetWidths(new float[] { 60f, 40f });

            // Columna izquierda: Datos de la empresa
            PdfPCell celdaEmpresa = new PdfPCell();
            celdaEmpresa.Border = Rectangle.NO_BORDER;
            celdaEmpresa.PaddingBottom = 10;

            // Logo/Nombre de empresa (puedes añadir una imagen aquí)
            Font fuenteLogo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, ColorPrimario);
            Paragraph nombreEmpresa = new Paragraph("SmartWarehouse", fuenteLogo);
            celdaEmpresa.AddElement(nombreEmpresa);

            Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
            celdaEmpresa.AddElement(new Paragraph("Sistema de Gestión de Entregas", fuenteSubtitulo));
            celdaEmpresa.AddElement(new Paragraph("CIF: B-12345678", fuenteSubtitulo));
            celdaEmpresa.AddElement(new Paragraph("C/ de Abizanda, 70, Hortaleza,", fuenteSubtitulo));
            celdaEmpresa.AddElement(new Paragraph("Tel: 913 82 19 05", fuenteSubtitulo));
            celdaEmpresa.AddElement(new Paragraph("info@smartwarehouse.com", fuenteSubtitulo));

            tabla.AddCell(celdaEmpresa);

            // Columna derecha: Datos de la factura
            PdfPCell celdaFactura = new PdfPCell();
            celdaFactura.Border = Rectangle.NO_BORDER;
            celdaFactura.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaFactura.BackgroundColor = ColorPrimario;
            celdaFactura.Padding = 10;

            Font fuenteFacturaTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.WHITE);
            Paragraph tituloFactura = new Paragraph("FACTURA", fuenteFacturaTitulo);
            tituloFactura.Alignment = Element.ALIGN_RIGHT;
            celdaFactura.AddElement(tituloFactura);

            Font fuenteFacturaDetalle = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.WHITE);
            celdaFactura.AddElement(new Paragraph($"Nº {factura.IdFactura:D6}", fuenteFacturaDetalle)
            { Alignment = Element.ALIGN_RIGHT });
            celdaFactura.AddElement(new Paragraph($"Fecha: {factura.FechaEmision:dd/MM/yyyy}", fuenteFacturaDetalle)
            { Alignment = Element.ALIGN_RIGHT });

            tabla.AddCell(celdaFactura);

            doc.Add(tabla);
            doc.Add(new Paragraph(" ")); // Espaciado
        }

        /// <summary>
        /// Datos del cliente
        /// </summary>
        private async Task AgregarDatosCliente(Document doc, PedidoApiModel pedido)
        {
            // Obtener datos del cliente
            
            var cliente = await _userService.GetById(pedido.IdCliente);
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DATOS DEL CLIENTE", fuenteTitulo);
            titulo.SpacingBefore = 10;
            titulo.SpacingAfter = 10;
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(2)
            {
                WidthPercentage = 100
            };
            tabla.SetWidths(new float[] { 30f, 70f });

            Font fuenteLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.GRAY);
            Font fuenteValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);

            // Nombre
            AgregarFilaDatos(tabla, "Cliente:", cliente?.Nombre ?? "N/A", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Email:", cliente?.Email ?? "N/A", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Pedido:", $"#{pedido.IdPedido}", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Fecha Pedido:", pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm"), fuenteLabel, fuenteValor);
            
            if (pedido.FechaEntrega.HasValue)
            {
                AgregarFilaDatos(tabla, "Fecha Entrega:", pedido.FechaEntrega.Value.ToString("dd/MM/yyyy HH:mm"), fuenteLabel, fuenteValor);
            }

            doc.Add(tabla);
        }

        /// <summary>
        /// Detalles del pedido (productos)
        /// </summary>
        private async Task AgregarDetallesPedido(Document doc, int idPedido)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DETALLE DE PRODUCTOS", fuenteTitulo);
            titulo.SpacingBefore = 10;
            titulo.SpacingAfter = 10;
            doc.Add(titulo);

            // Obtener detalles del pedido
            var detalles = await _detalleService.GetByPedido(idPedido);

            // Tabla de productos
            PdfPTable tabla = new PdfPTable(5)
            {
                WidthPercentage = 100
            };
            tabla.SetWidths(new float[] { 10f, 40f, 15f, 15f, 20f });

            // Encabezados
            Font fuenteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            string[] headers = { "Nº", "Producto", "Cantidad", "Precio Ud.", "Subtotal" };

            foreach (var header in headers)
            {
                PdfPCell celda = new PdfPCell(new Phrase(header, fuenteHeader))
                {
                    BackgroundColor = ColorPrimario,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Padding = 8
                };
                tabla.AddCell(celda);
            }

            // Filas de productos
            Font fuenteContenido = FontFactory.GetFont(FontFactory.HELVETICA, 9, ColorSecundario);
            int contador = 1;

            foreach (var detalle in detalles)
            {
                decimal precioUnitario = detalle.Cantidad > 0 ? detalle.Subtotal / detalle.Cantidad : 0;

                // Número
                AgregarCeldaProducto(tabla, contador.ToString(), fuenteContenido, Element.ALIGN_CENTER);

                // Producto (usamos IdProducto ya que no tenemos el nombre)
                AgregarCeldaProducto(tabla, $"Producto #{detalle.IdProducto}", fuenteContenido, Element.ALIGN_LEFT);

                // Cantidad
                AgregarCeldaProducto(tabla, detalle.Cantidad.ToString(), fuenteContenido, Element.ALIGN_CENTER);

                // Precio unitario
                AgregarCeldaProducto(tabla, $"{precioUnitario:C2}", fuenteContenido, Element.ALIGN_RIGHT);

                // Subtotal
                AgregarCeldaProducto(tabla, $"{detalle.Subtotal:C2}", fuenteContenido, Element.ALIGN_RIGHT);

                contador++;
            }

            doc.Add(tabla);
        }

        /// <summary>
        /// Totales de la factura
        /// </summary>
        private void AgregarTotales(Document doc, FacturaApiModel factura)
        {
            // Espaciado
            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(2)
            {
                WidthPercentage = 50,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            tabla.SetWidths(new float[] { 60f, 40f });

            Font fuenteLabel = FontFactory.GetFont(FontFactory.HELVETICA, 11, ColorSecundario);
            Font fuenteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, ColorPrimario);

            // Subtotal
            AgregarFilaTotales(tabla, "Subtotal:", $"{factura.Subtotal:C2}", fuenteLabel, fuenteLabel);

            // IVA
            decimal porcentajeIva = factura.Subtotal > 0 
                ? (factura.IVA / factura.Subtotal) * 100 
                : 21;
            AgregarFilaTotales(tabla, $"IVA ({porcentajeIva:F0}%):", $"{factura.IVA:C2}", fuenteLabel, fuenteLabel);

            // Total (destacado)
            PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("TOTAL:", fuenteTotal))
            {
                Border = Rectangle.TOP_BORDER,
                BorderColor = ColorPrimario,
                BorderWidth = 2,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 8,
                PaddingTop = 12
            };
            tabla.AddCell(celdaTotalLabel);

            PdfPCell celdaTotalValor = new PdfPCell(new Phrase($"{factura.Total:C2}", fuenteTotal))
            {
                Border = Rectangle.TOP_BORDER,
                BorderColor = ColorPrimario,
                BorderWidth = 2,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 8,
                PaddingTop = 12,
                BackgroundColor = new BaseColor(245, 245, 245)
            };
            tabla.AddCell(celdaTotalValor);

            doc.Add(tabla);
        }

        /// <summary>
        /// Pie de página con información adicional
        /// </summary>
        private void AgregarPiePagina(Document doc, FacturaApiModel factura)
        {
            // Espaciado
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Font fuentePie = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);

            doc.Add(new Paragraph(" "));

            // Sello/Firma
            PdfPTable tablaSello = new PdfPTable(1)
            {
                WidthPercentage = 40,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };

            PdfPCell celdaSello = new PdfPCell(new Phrase("Sello de la empresa", fuentePie))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                MinimumHeight = 60,
                Padding = 10,
                BorderColor = BaseColor.GRAY
            };
            tablaSello.AddCell(celdaSello);

            doc.Add(tablaSello);

            // Pie de página final
            Paragraph gracias = new Paragraph(
                "¡Gracias por confiar en SmartWarehouse!",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, ColorPrimario)
            );
            gracias.Alignment = Element.ALIGN_CENTER;
            gracias.SpacingBefore = 20;
            doc.Add(gracias);
        }

        #region Métodos auxiliares

        private void AgregarSeparador(Document doc)
        {
            Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                1f, 100f, ColorPrimario, Element.ALIGN_CENTER, -2
            )));
            linea.SpacingBefore = 5;
            linea.SpacingAfter = 5;
            doc.Add(linea);
        }

        private void AgregarFilaDatos(PdfPTable tabla, string label, string valor, Font fuenteLabel, Font fuenteValor)
        {
            PdfPCell celdaLabel = new PdfPCell(new Phrase(label, fuenteLabel))
            {
                Border = Rectangle.NO_BORDER,
                PaddingBottom = 5
            };
            tabla.AddCell(celdaLabel);

            PdfPCell celdaValor = new PdfPCell(new Phrase(valor, fuenteValor))
            {
                Border = Rectangle.NO_BORDER,
                PaddingBottom = 5
            };
            tabla.AddCell(celdaValor);
        }

        private void AgregarCeldaProducto(PdfPTable tabla, string texto, Font fuente, int alineacion)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente))
            {
                HorizontalAlignment = alineacion,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Padding = 6,
                BorderColor = new BaseColor(220, 220, 220)
            };
            tabla.AddCell(celda);
        }

        private void AgregarFilaTotales(PdfPTable tabla, string label, string valor, Font fuenteLabel, Font fuenteValor)
        {
            PdfPCell celdaLabel = new PdfPCell(new Phrase(label, fuenteLabel))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 5
            };
            tabla.AddCell(celdaLabel);

            PdfPCell celdaValor = new PdfPCell(new Phrase(valor, fuenteValor))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 5
            };
            tabla.AddCell(celdaValor);
        }

        #endregion

        /// <summary>
        /// Abre el PDF generado con el visor predeterminado
        /// </summary>
        public static void AbrirPdf(string rutaPdf)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al abrir el PDF: {ex.Message}", ex);
            }
        }
    }
}