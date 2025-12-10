using iTextSharp.text;
using iTextSharp.text.pdf;
using SmartWarehouseDesktop.ApiModels;
using SmartWarehouseDesktop.ApiServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Utils
{
    public class PdfGenerator
    {
        private readonly DetallePedidoService _detalleService = new DetallePedidoService();
        private readonly PedidoService _pedidoService = new PedidoService();
        private readonly UserService _userService = new UserService();
        private readonly ProductoService _productoService = new ProductoService();

        private static readonly BaseColor ColorPrimario = new BaseColor(25, 118, 210);
        private static readonly BaseColor ColorSecundario = new BaseColor(33, 33, 33);
        private static readonly BaseColor ColorFondo = new BaseColor(245, 245, 245);

        #region FACTURA

        public async Task<string> GenerarFacturaPdf(FacturaApiModel factura, PedidoApiModel pedido, UserApiModel cliente, string rutaDestino = null)
        {
            if (rutaDestino == null)
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

            Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaDestino, FileMode.Create));

            documento.Open();

            AgregarEncabezadoFactura(documento, factura);
            AgregarSeparador(documento);
            await AgregarDatosClienteFactura(documento, pedido);
            AgregarSeparador(documento);
            AgregarDireccionFacturacion(documento, cliente);
            AgregarSeparador(documento);
            await AgregarDetallesPedidoFactura(documento, pedido.IdPedido);
            AgregarSeparador(documento);
            AgregarTotalesFactura(documento, factura);
            AgregarPiePaginaFactura(documento, factura);

            documento.Close();
            return rutaDestino;
        }

        private void AgregarEncabezadoFactura(Document doc, FacturaApiModel factura)
        {
            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 60f, 40f });

            // Empresa
            PdfPCell celdaEmpresa = new PdfPCell() { Border = Rectangle.NO_BORDER, PaddingBottom = 10 };
            celdaEmpresa.AddElement(new Paragraph("SmartWarehouse", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, ColorPrimario)));
            Font fuenteSub = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
            celdaEmpresa.AddElement(new Paragraph("Sistema de Gestión de Entregas", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("CIF: B-12345678", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("C/ de Abizanda, 70, Hortaleza", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("28033 Madrid", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("Tel: 913 82 19 05", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("info@smartwarehouse.com", fuenteSub));
            tabla.AddCell(celdaEmpresa);

            // Factura
            PdfPCell celdaFactura = new PdfPCell() { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = ColorPrimario, Padding = 10 };
            celdaFactura.AddElement(new Paragraph("FACTURA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.WHITE)) { Alignment = Element.ALIGN_RIGHT });
            Font fuenteDetalle = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.WHITE);
            celdaFactura.AddElement(new Paragraph($"Nº {factura.IdFactura:D6}", fuenteDetalle) { Alignment = Element.ALIGN_RIGHT });
            celdaFactura.AddElement(new Paragraph($"Fecha Expedición: {factura.FechaEmision:dd/MM/yyyy}", fuenteDetalle) { Alignment = Element.ALIGN_RIGHT });
            tabla.AddCell(celdaFactura);

            doc.Add(tabla);
            doc.Add(new Paragraph(" "));
        }

        private async Task AgregarDatosClienteFactura(Document doc, PedidoApiModel pedido)
        {
            var cliente = await _userService.GetById(pedido.IdCliente);

            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DATOS DEL CLIENTE", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 30f, 70f });

            Font fuenteLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.GRAY);
            Font fuenteValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);

            AgregarFilaDatos(tabla, "Cliente:", cliente?.Nombre ?? "N/A", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "NIF:", cliente?.Nif ?? "N/A", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Email:", cliente?.Email ?? "N/A", fuenteLabel, fuenteValor);

            if (!string.IsNullOrEmpty(cliente?.Telefono))
            {
                AgregarFilaDatos(tabla, "Teléfono:", cliente.Telefono, fuenteLabel, fuenteValor);
            }

            AgregarFilaDatos(tabla, "Nº Pedido:", $"#{pedido.IdPedido:D6}", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Fecha Pedido:", pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm"), fuenteLabel, fuenteValor);

            
            doc.Add(tabla);
        }
        private void AgregarDireccionFacturacion(Document doc, UserApiModel cliente)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DIRECCIÓN DE FACTURACIÓN", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(1) { WidthPercentage = 100 };
            Font fuenteValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);

            PdfPCell celda = new PdfPCell
            {
                Border = Rectangle.BOX,
                BorderColor = new BaseColor(220, 220, 220),
                Padding = 10,
                BackgroundColor = ColorFondo
            };

            string direccion = !string.IsNullOrWhiteSpace(cliente.DireccionFacturacion)
                ? cliente.DireccionFacturacion
                : "Dirección no especificada";

            celda.AddElement(new Paragraph(direccion, fuenteValor));

            tabla.AddCell(celda);
            doc.Add(tabla);
        }



        private async Task AgregarDetallesPedidoFactura(Document doc, int idPedido)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DETALLE DE PRODUCTOS", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            var detalles = await _detalleService.GetByPedido(idPedido);

            PdfPTable tabla = new PdfPTable(5) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 8f, 42f, 15f, 17f, 18f });

            // Encabezados
            Font fuenteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            string[] headers = { "Nº", "Producto", "Cantidad", "Precio Ud.", "Subtotal" };
            foreach (var h in headers)
            {
                tabla.AddCell(new PdfPCell(new Phrase(h, fuenteHeader))
                {
                    BackgroundColor = ColorPrimario,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Padding = 8
                });
            }

            Font fuenteContenido = FontFactory.GetFont(FontFactory.HELVETICA, 9, ColorSecundario);
            Font fuenteDescripcion = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            int contador = 1;

            foreach (var detalle in detalles)
            {
                decimal precioUnitario = detalle.Cantidad > 0 ? detalle.Subtotal / detalle.Cantidad : 0;

                // Obtener información del producto
                var producto = await _productoService.GetById(detalle.IdProducto);

                // Número
                AgregarCeldaProducto(tabla, contador.ToString(), fuenteContenido, Element.ALIGN_CENTER);

                // Nombre del producto con descripción
                PdfPCell celdaProducto = new PdfPCell();
                celdaProducto.HorizontalAlignment = Element.ALIGN_LEFT;
                celdaProducto.VerticalAlignment = Element.ALIGN_MIDDLE;
                celdaProducto.Padding = 6;
                celdaProducto.BorderColor = new BaseColor(220, 220, 220);

                string nombreProducto = producto?.Nombre ?? $"Producto #{detalle.IdProducto}";
                celdaProducto.AddElement(new Paragraph(nombreProducto, fuenteContenido));

                if (producto != null && !string.IsNullOrEmpty(producto.Descripcion))
                {
                    string descripcionCorta = producto.Descripcion.Length > 60
                        ? producto.Descripcion.Substring(0, 57) + "..."
                        : producto.Descripcion;
                    celdaProducto.AddElement(new Paragraph(descripcionCorta, fuenteDescripcion));
                }

                if (producto != null && !string.IsNullOrEmpty(producto.Categoria))
                {
                    Font fuenteCategoria = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, new BaseColor(100, 100, 100));
                    celdaProducto.AddElement(new Paragraph($"Cat: {producto.Categoria}", fuenteCategoria));
                }

                tabla.AddCell(celdaProducto);

                // Cantidad
                AgregarCeldaProducto(tabla, detalle.Cantidad.ToString(), fuenteContenido, Element.ALIGN_CENTER);

                // Precio unitario
                AgregarCeldaProducto(tabla, precioUnitario.ToString("C2"), fuenteContenido, Element.ALIGN_RIGHT);

                // Subtotal
                Font fuenteSubtotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, ColorSecundario);
                AgregarCeldaProducto(tabla, detalle.Subtotal.ToString("C2"), fuenteSubtotal, Element.ALIGN_RIGHT);

                contador++;
            }

            doc.Add(tabla);
        }

        private void AgregarTotalesFactura(Document doc, FacturaApiModel factura)
        {
            doc.Add(new Paragraph(" "));
            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT };
            tabla.SetWidths(new float[] { 60f, 40f });

            Font fuenteLabel = FontFactory.GetFont(FontFactory.HELVETICA, 11, ColorSecundario);
            Font fuenteTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, ColorPrimario);

            AgregarFilaTotales(tabla, "Subtotal:", factura.Subtotal.ToString("C2"), fuenteLabel, fuenteLabel);
            decimal porcentajeIva = factura.Subtotal > 0 ? (factura.IVA / factura.Subtotal) * 100 : 21;
            AgregarFilaTotales(tabla, $"IVA ({porcentajeIva:F0}%):", factura.IVA.ToString("C2"), fuenteLabel, fuenteLabel);

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

            PdfPCell celdaTotalValor = new PdfPCell(new Phrase(factura.Total.ToString("C2"), fuenteTotal))
            {
                Border = Rectangle.TOP_BORDER,
                BorderColor = ColorPrimario,
                BorderWidth = 2,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Padding = 8,
                PaddingTop = 12,
                BackgroundColor = ColorFondo
            };
            tabla.AddCell(celdaTotalValor);

            doc.Add(tabla);
        }

        private void AgregarPiePaginaFactura(Document doc, FacturaApiModel factura)
        {
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Font fuentePie = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            Paragraph condiciones = new Paragraph(
                "CONDICIONES DE PAGO: Pago contra entrega.",
                fuentePie
            );
            condiciones.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(condiciones);

            doc.Add(new Paragraph(" "));

            PdfPTable tablaSello = new PdfPTable(1) { WidthPercentage = 40, HorizontalAlignment = Element.ALIGN_RIGHT };
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

            Paragraph gracias = new Paragraph(
                "¡Gracias por confiar en SmartWarehouse!",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, ColorPrimario)
            );
            gracias.Alignment = Element.ALIGN_CENTER;
            gracias.SpacingBefore = 20;
            doc.Add(gracias);
        }

        #endregion

        #region ALBARAN

        public async Task<string> GenerarAlbaranPdf(PedidoApiModel pedido, string rutaDestino = null)
        {
            if (rutaDestino == null)
            {
                string carpetaAlbaranes = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "SmartWarehouse",
                    "Albaranes"
                );
                Directory.CreateDirectory(carpetaAlbaranes);
                rutaDestino = Path.Combine(
                    carpetaAlbaranes,
                    $"Albaran_{pedido.IdPedido}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                );
            }

            Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaDestino, FileMode.Create));

            documento.Open();

            AgregarEncabezadoAlbaran(documento, pedido);
            AgregarSeparador(documento);
            await AgregarDatosClienteAlbaran(documento, pedido);
            AgregarSeparador(documento);
            AgregarDireccionEntrega(documento, pedido);
            AgregarSeparador(documento);
            await AgregarDetallesPedidoAlbaran(documento, pedido.IdPedido);
            AgregarSeparador(documento);
            AgregarFirmaEntrega(documento);

            documento.Close();
            return rutaDestino;
        }

        private void AgregarEncabezadoAlbaran(Document doc, PedidoApiModel pedido)
        {
            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 60f, 40f });

            // Empresa
            PdfPCell celdaEmpresa = new PdfPCell() { Border = Rectangle.NO_BORDER, PaddingBottom = 10 };
            celdaEmpresa.AddElement(new Paragraph("SmartWarehouse", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, ColorPrimario)));
            Font fuenteSub = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
            celdaEmpresa.AddElement(new Paragraph("Sistema de Gestión de Entregas", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("CIF: B-12345678", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("C/ de Abizanda, 70, Hortaleza", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("28033 Madrid", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("Tel: 913 82 19 05", fuenteSub));
            celdaEmpresa.AddElement(new Paragraph("info@smartwarehouse.com", fuenteSub));
            tabla.AddCell(celdaEmpresa);

            // Albarán
            PdfPCell celdaAlbaran = new PdfPCell() { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, BackgroundColor = ColorPrimario, Padding = 10 };
            celdaAlbaran.AddElement(new Paragraph("ALBARÁN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.WHITE)) { Alignment = Element.ALIGN_RIGHT });
            celdaAlbaran.AddElement(new Paragraph($"Pedido Nº {pedido.IdPedido:D6}", FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.WHITE)) { Alignment = Element.ALIGN_RIGHT });
            celdaAlbaran.AddElement(new Paragraph($"Fecha: {pedido.FechaPedido:dd/MM/yyyy}", FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.WHITE)) { Alignment = Element.ALIGN_RIGHT });
            tabla.AddCell(celdaAlbaran);

            doc.Add(tabla);
            doc.Add(new Paragraph(" "));
        }

        private async Task AgregarDatosClienteAlbaran(Document doc, PedidoApiModel pedido)
        {
            var cliente = await _userService.GetById(pedido.IdCliente);

            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DATOS DEL CLIENTE", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 30f, 70f });

            Font fuenteLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.GRAY);
            Font fuenteValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);

            AgregarFilaDatos(tabla, "Cliente:", cliente?.Nombre ?? "N/A", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Email:", cliente?.Email ?? "N/A", fuenteLabel, fuenteValor);

            if (!string.IsNullOrEmpty(cliente?.Telefono))
            {
                AgregarFilaDatos(tabla, "Teléfono:", cliente.Telefono, fuenteLabel, fuenteValor);
            }

            AgregarFilaDatos(tabla, "Nº Pedido:", $"#{pedido.IdPedido:D6}", fuenteLabel, fuenteValor);
            AgregarFilaDatos(tabla, "Fecha Pedido:", pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm"), fuenteLabel, fuenteValor);

            if (pedido.FechaEntrega.HasValue)
            {
                AgregarFilaDatos(tabla, "Fecha Entrega:", pedido.FechaEntrega.Value.ToString("dd/MM/yyyy HH:mm"), fuenteLabel, fuenteValor);
            }

            // Información del repartidor
            if (pedido.IdRepartidor != 0)
            {
                var repartidor = await _userService.GetById((int)pedido.IdRepartidor);
                if (repartidor != null)
                {
                    AgregarFilaDatos(tabla, "Entregado por:", repartidor.Nombre, fuenteLabel, fuenteValor);
                    if (!string.IsNullOrEmpty(repartidor.Telefono))
                    {
                        AgregarFilaDatos(tabla, "Tel. Repartidor:", repartidor.Telefono, fuenteLabel, fuenteValor);
                    }
                }
            }

            doc.Add(tabla);
        }
        private void AgregarDireccionEntrega(Document doc, PedidoApiModel pedido)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DIRECCIÓN DE ENTREGA", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(1) { WidthPercentage = 100 };

            Font fuenteValor = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);

            PdfPCell celda = new PdfPCell();
            celda.Border = Rectangle.BOX;
            celda.BorderColor = new BaseColor(220, 220, 220);
            celda.Padding = 10;
            celda.BackgroundColor = ColorFondo;

            // Dirección principal
            string direccionCompleta = !string.IsNullOrEmpty(pedido.DireccionEntrega)
                ? pedido.DireccionEntrega
                : pedido.DireccionEntrega;

            if (!string.IsNullOrEmpty(direccionCompleta))
            {
                celda.AddElement(new Paragraph(direccionCompleta, fuenteValor));
            }

            // Ciudad y código postal
            string ciudadCP = "";
            if (!string.IsNullOrEmpty(pedido.CodigoPostal))
            {
                ciudadCP = pedido.CodigoPostal;
            }
            if (!string.IsNullOrEmpty(pedido.Ciudad))
            {
                ciudadCP += string.IsNullOrEmpty(ciudadCP) ? pedido.Ciudad : $" - {pedido.Ciudad}";
            }

            if (!string.IsNullOrEmpty(ciudadCP))
            {
                celda.AddElement(new Paragraph(ciudadCP, fuenteValor));
            }

            // Notas adicionales
            if (!string.IsNullOrEmpty(pedido.Notas))
            {
                Font fuenteNotas = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9, BaseColor.GRAY);
                Paragraph notasParrafo = new Paragraph($"Notas: {pedido.Notas}", fuenteNotas);
                notasParrafo.SpacingBefore = 5;
                celda.AddElement(notasParrafo);
            }

            tabla.AddCell(celda);
            doc.Add(tabla);
        }

        private async Task AgregarDetallesPedidoAlbaran(Document doc, int idPedido)
        {
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, ColorSecundario);
            Paragraph titulo = new Paragraph("DETALLE DE PRODUCTOS", fuenteTitulo)
            {
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            doc.Add(titulo);

            var detalles = await _detalleService.GetByPedido(idPedido);

            PdfPTable tabla = new PdfPTable(3) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 10f, 70f, 20f });

            Font fuenteHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            string[] headers = { "Nº", "Producto", "Cantidad" };
            foreach (var h in headers)
            {
                tabla.AddCell(new PdfPCell(new Phrase(h, fuenteHeader))
                {
                    BackgroundColor = ColorPrimario,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Padding = 8
                });
            }

            Font fuenteContenido = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);
            Font fuenteDescripcion = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY);
            int contador = 1;

            foreach (var detalle in detalles)
            {
                // Obtener información del producto
                var producto = await _productoService.GetById(detalle.IdProducto);

                // Número
                tabla.AddCell(new PdfPCell(new Phrase(contador.ToString(), fuenteContenido))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Padding = 6,
                    BorderColor = new BaseColor(220, 220, 220)
                });

                // Producto con descripción
                PdfPCell celdaProducto = new PdfPCell();
                celdaProducto.HorizontalAlignment = Element.ALIGN_LEFT;
                celdaProducto.VerticalAlignment = Element.ALIGN_MIDDLE;
                celdaProducto.Padding = 6;
                celdaProducto.BorderColor = new BaseColor(220, 220, 220);

                string nombreProducto = producto?.Nombre ?? $"Producto #{detalle.IdProducto}";
                celdaProducto.AddElement(new Paragraph(nombreProducto, fuenteContenido));

                if (producto != null && !string.IsNullOrEmpty(producto.Descripcion))
                {
                    string descripcionCorta = producto.Descripcion.Length > 80
                        ? producto.Descripcion.Substring(0, 77) + "..."
                        : producto.Descripcion;
                    celdaProducto.AddElement(new Paragraph(descripcionCorta, fuenteDescripcion));
                }

                tabla.AddCell(celdaProducto);

                // Cantidad
                tabla.AddCell(new PdfPCell(new Phrase(detalle.Cantidad.ToString(), fuenteContenido))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    Padding = 6,
                    BorderColor = new BaseColor(220, 220, 220)
                });

                contador++;
            }

            doc.Add(tabla);
        }

        private void AgregarFirmaEntrega(Document doc)
        {
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            Font fuenteInstrucciones = FontFactory.GetFont(FontFactory.HELVETICA, 10, ColorSecundario);
            Paragraph instrucciones = new Paragraph(
                "Por favor, firme este albarán como constancia de recepción de la mercancía.",
                fuenteInstrucciones
            );
            instrucciones.Alignment = Element.ALIGN_LEFT;
            instrucciones.SpacingBefore = 10;
            doc.Add(instrucciones);

            doc.Add(new Paragraph(" "));

            PdfPTable tablaFirmas = new PdfPTable(2) { WidthPercentage = 100 };
            tablaFirmas.SetWidths(new float[] { 50f, 50f });

            Font fuenteFirma = FontFactory.GetFont(FontFactory.HELVETICA, 11, ColorSecundario);

            // Firma del repartidor
            PdfPCell celdaRepartidor = new PdfPCell();
            celdaRepartidor.Border = Rectangle.NO_BORDER;
            celdaRepartidor.PaddingTop = 20;
            celdaRepartidor.PaddingRight = 10;

            Paragraph firmaRepartidor = new Paragraph("Firma del repartidor:", fuenteFirma);
            celdaRepartidor.AddElement(firmaRepartidor);
            celdaRepartidor.AddElement(new Paragraph(" "));

            PdfPCell celdaLineaRepartidor = new PdfPCell(new Phrase("_____________________________", fuenteFirma));
            celdaLineaRepartidor.Border = Rectangle.NO_BORDER;
            celdaLineaRepartidor.PaddingTop = 30;
            celdaRepartidor.AddElement(new Paragraph("_____________________________", fuenteFirma));

            tablaFirmas.AddCell(celdaRepartidor);

            // Firma del receptor
            PdfPCell celdaReceptor = new PdfPCell();
            celdaReceptor.Border = Rectangle.NO_BORDER;
            celdaReceptor.PaddingTop = 20;
            celdaReceptor.PaddingLeft = 10;

            Paragraph firmaReceptor = new Paragraph("Firma del receptor:", fuenteFirma);
            celdaReceptor.AddElement(firmaReceptor);
            celdaReceptor.AddElement(new Paragraph(" "));
            celdaReceptor.AddElement(new Paragraph("_____________________________", fuenteFirma));

            tablaFirmas.AddCell(celdaReceptor);

            doc.Add(tablaFirmas);

            // Nota legal
            doc.Add(new Paragraph(" "));
            Font fuenteNota = FontFactory.GetFont(FontFactory.HELVETICA, 7, BaseColor.GRAY);
            Paragraph nota = new Paragraph(
                "La firma de este documento implica la aceptación de la mercancía entregada en perfectas condiciones.",
                fuenteNota
            );
            nota.Alignment = Element.ALIGN_CENTER;
            nota.SpacingBefore = 20;
            doc.Add(nota);
        }

        #endregion

        #region COMÚN

        private void AgregarSeparador(Document doc)
        {
            Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, ColorPrimario, Element.ALIGN_CENTER, -2)));
            linea.SpacingBefore = 5;
            linea.SpacingAfter = 5;
            doc.Add(linea);
        }

        private void AgregarFilaDatos(PdfPTable tabla, string label, string valor, Font fuenteLabel, Font fuenteValor)
        {
            tabla.AddCell(new PdfPCell(new Phrase(label, fuenteLabel)) { Border = Rectangle.NO_BORDER, PaddingBottom = 5 });
            tabla.AddCell(new PdfPCell(new Phrase(valor, fuenteValor)) { Border = Rectangle.NO_BORDER, PaddingBottom = 5 });
        }

        private void AgregarFilaTotales(PdfPTable tabla, string label, string valor, Font fuenteLabel, Font fuenteValor)
        {
            tabla.AddCell(new PdfPCell(new Phrase(label, fuenteLabel)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
            tabla.AddCell(new PdfPCell(new Phrase(valor, fuenteValor)) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 5 });
        }

        private void AgregarCeldaProducto(PdfPTable tabla, string texto, Font fuente, int alineacion)
        {
            tabla.AddCell(new PdfPCell(new Phrase(texto, fuente)) { HorizontalAlignment = alineacion, VerticalAlignment = Element.ALIGN_MIDDLE, Padding = 6, BorderColor = new BaseColor(220, 220, 220) });
        }

        public static void AbrirPdf(string rutaPdf)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = rutaPdf, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir el PDF: " + ex.Message, ex);
            }
        }

        #endregion
    }
}