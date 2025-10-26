using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }  // Pendiente, En curso, Entregado, Cancelado
        public int IdCliente { get; set; }
        public int? IdRepartidor { get; set; }  // Puede ser nulo

        public Pedido() { }

        public Pedido(int id, DateTime fecha, string estado, int cliente, int? repartidor)
        {
            IdPedido = id;
            FechaPedido = fecha;
            Estado = estado;
            IdCliente = cliente;
            IdRepartidor = repartidor;
        }

        public override string ToString()
        {
            return $"Pedido #{IdPedido} - {Estado} ({FechaPedido:d})";
        }
    }
}
