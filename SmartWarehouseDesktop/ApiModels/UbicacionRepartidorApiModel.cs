using System;

namespace SmartWarehouseDesktop.ApiModels
{
    public class UbicacionRepartidorApiModel
    {
        public int IdUbicacion { get; set; }
        public int IdRepartidor { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
