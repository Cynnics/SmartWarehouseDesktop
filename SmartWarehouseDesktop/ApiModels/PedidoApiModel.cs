using System;

namespace SmartWarehouseDesktop.ApiModels
{
    // Modelo mínimo para mostrar pedidos en el formulario de facturación
    public class PedidoApiModel
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido{ get; set; }
        public int IdCliente { get; set; }
        public int? IdRepartidor { get; set; }     // opcional, si tu API lo devuelve
        public string Estado { get; set; }          // pendiente, preparado, en_reparto, entregado...
        public DateTime? FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string Notas { get; set; }


    }
}
