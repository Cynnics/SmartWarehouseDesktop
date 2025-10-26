using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    class UbicacionRepartidor
    {
        public int IdUbicacion { get; set; }
        public int IdRepartidor { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public DateTime FechaHora { get; set; }

        public UbicacionRepartidor() { }

        public UbicacionRepartidor(int id, int repartidor, decimal lat, decimal lon, DateTime fecha)
        {
            IdUbicacion = id;
            IdRepartidor = repartidor;
            Latitud = lat;
            Longitud = lon;
            FechaHora = fecha;
        }

        public override string ToString()
        {
            return $"Repartidor {IdRepartidor} - ({Latitud}, {Longitud}) {FechaHora}";
        }
    }
}
