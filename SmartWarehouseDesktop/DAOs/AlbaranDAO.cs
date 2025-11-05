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
    public class AlbaranDAO
    {
        private DBConnection db = new DBConnection();

        public List<Albaran> ObtenerAlbaranes()
        {
            List<Albaran> albaranes = new List<Albaran>();
            string query = "SELECT * FROM Albaran";

            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Albaran a = new Albaran
                        {
                            IdAlbaran = reader.GetInt32("idAlbaran"),
                            IdPedido = reader.GetInt32("idPedido"),
                            FechaGeneracion = reader.GetDateTime("fechaGeneracion"),
                            EntregadoPor = reader.IsDBNull(reader.GetOrdinal("entregadoPor")) ? (int?)null : reader.GetInt32("entregadoPor"),
                            RecibidoPor = reader.IsDBNull(reader.GetOrdinal("recibidoPor")) ? "" : reader.GetString("recibidoPor")
                        };
                        albaranes.Add(a);
                    }
                }
            }
            return albaranes;
        }

        public bool InsertarAlbaran(Albaran a)
        {
            string query = @"INSERT INTO Albaran (idPedido, fechaGeneracion, entregadoPor, recibidoPor)
                             VALUES (@pedido, @fecha, @entregado, @recibido)";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pedido", a.IdPedido);
                cmd.Parameters.AddWithValue("@fecha", a.FechaGeneracion);
                cmd.Parameters.AddWithValue("@entregado", a.EntregadoPor);
                cmd.Parameters.AddWithValue("@recibido", a.RecibidoPor);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarAlbaran(int idAlbaran)
        {
            string query = "DELETE FROM Albaran WHERE idAlbaran=@id";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAlbaran);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}