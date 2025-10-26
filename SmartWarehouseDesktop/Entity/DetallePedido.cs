using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public DetallePedido() { }

        public DetallePedido(int id, int pedido, int producto, int cantidad, decimal subtotal)
        {
            IdDetalle = id;
            IdPedido = pedido;
            IdProducto = producto;
            Cantidad = cantidad;
            Subtotal = subtotal;
        }

        public override string ToString()
        {
            return $"Detalle #{IdDetalle} - Pedido {IdPedido} - Producto {IdProducto} - {Cantidad} uds.";
        }
    }
}
