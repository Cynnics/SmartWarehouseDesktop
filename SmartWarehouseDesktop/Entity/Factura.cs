using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public Factura() { }

        public Factura(int id, int pedido, DateTime fecha, decimal subtotal, decimal iva, decimal total)
        {
            IdFactura = id;
            IdPedido = pedido;
            FechaEmision = fecha;
            Subtotal = subtotal;
            IVA = iva;
            Total = total;
        }

        public override string ToString()
        {
            return $"Factura #{IdFactura} - Pedido {IdPedido} - Total: {Total:C2}";
        }
    }
}