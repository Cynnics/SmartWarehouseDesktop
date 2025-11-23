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
    }
}
