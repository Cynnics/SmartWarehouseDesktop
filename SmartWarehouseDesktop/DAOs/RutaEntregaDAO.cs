using MySql.Data.MySqlClient;
using SmartWarehouseDesktop.Conexion;
using SmartWarehouseDesktop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.DAOs
{
    public class RutaEntregaDAO
    {
        private DBConnection db = new DBConnection();

        public List<RutaEntrega> ObtenerRutas()
        {
            List<RutaEntrega> rutas = new List<RutaEntrega>();
            string query = "SELECT * FROM RutaEntrega";

            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RutaEntrega r = new RutaEntrega
                        {
                            IdRuta = reader.GetInt32("idRuta"),
                            IdRepartidor = reader.GetInt32("idRepartidor"),
                            FechaRuta = reader.GetDateTime("fechaRuta"),
                            DistanciaEstimadaKm = reader.IsDBNull(reader.GetOrdinal("distanciaEstimadakm")) ? (decimal?)null : reader.GetDecimal("distanciaEstimadakm"),
                            DuracionEstimadaMin = reader.IsDBNull(reader.GetOrdinal("duracionEstimadaMin")) ? (int?)null : reader.GetInt32("duracionEstimadaMin"),
                            Estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? "Planificada" : reader.GetString("estado")
                        };
                        rutas.Add(r);
                    }
                }
            }
            return rutas;
        }

        public bool InsertarRuta(RutaEntrega r)
        {
            string query = @"INSERT INTO RutaEntrega (idRepartidor, fechaRuta, distanciaEstimadakm, duracionEstimadaMin, estado)
                             VALUES (@rep, @fecha, @dist, @dur, @estado)";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rep", r.IdRepartidor);
                cmd.Parameters.AddWithValue("@fecha", r.FechaRuta);
                cmd.Parameters.AddWithValue("@dist", r.DistanciaEstimadaKm);
                cmd.Parameters.AddWithValue("@dur", r.DuracionEstimadaMin);
                cmd.Parameters.AddWithValue("@estado", r.Estado);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarRuta(RutaEntrega r)
        {
            string query = @"UPDATE RutaEntrega 
                             SET distanciaEstimadakm=@dist, duracionEstimadaMin=@dur, estado=@estado 
                             WHERE idRuta=@id";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dist", r.DistanciaEstimadaKm);
                cmd.Parameters.AddWithValue("@dur", r.DuracionEstimadaMin);
                cmd.Parameters.AddWithValue("@estado", r.Estado);
                cmd.Parameters.AddWithValue("@id", r.IdRuta);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarRuta(int idRuta)
        {
            string query = "DELETE FROM RutaEntrega WHERE idRuta=@id";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idRuta);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}