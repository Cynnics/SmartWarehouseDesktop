using System;

namespace SmartWarehouseDesktop.ApiModels
{

    public class PedidoApiModel
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido{ get; set; }
        public int IdCliente { get; set; }
        public int? IdRepartidor { get; set; }     
        public string Estado { get; set; }         
        public DateTime? FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string Notas { get; set; }


    }
}
