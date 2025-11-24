using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.ApiModels
{
    public class AlbaranApiModel
    {
        public int IdAlbaran { get; set; }
        public int IdPedido { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int EntregadoPor { get; set; }
        public string RecibidoPor { get; set; }
        public string Estado { get; set; } = "generado";
    }
}
