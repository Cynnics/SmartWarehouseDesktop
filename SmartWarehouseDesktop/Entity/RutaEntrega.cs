using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    public class RutaEntrega
    {
        public int IdRuta { get; set; }
        public int IdRepartidor { get; set; }
        public DateTime FechaRuta { get; set; }
        public decimal? DistanciaEstimadaKm { get; set; }
        public int? DuracionEstimadaMin { get; set; }
        public string Estado { get; set; }

        public RutaEntrega() { }

        public RutaEntrega(int id, int repartidor, DateTime fecha, decimal? distancia, int? duracion, string estado)
        {
            IdRuta = id;
            IdRepartidor = repartidor;
            FechaRuta = fecha;
            DistanciaEstimadaKm = distancia;
            DuracionEstimadaMin = duracion;
            Estado = estado;
        }

        public override string ToString()
        {
            return $"Ruta #{IdRuta} - Repartidor {IdRepartidor} ({Estado})";
        }
    }
}