using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    public class Albaran
    {
        public int IdAlbaran { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int? EntregadoPor { get; set; }
        public string RecibidoPor { get; set; }

        public Albaran() { }

        public Albaran(int id, int pedido, DateTime fecha, int? entregadoPor, string recibidoPor)
        {
            IdAlbaran = id;
            IdPedido = pedido;
            FechaGeneracion = fecha;
            EntregadoPor = entregadoPor;
            RecibidoPor = recibidoPor;
        }

        public override string ToString()
        {
            return $"Albarán #{IdAlbaran} - Pedido {IdPedido} ({FechaGeneracion:d})";
        }
    }
}