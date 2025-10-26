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
    class UbicacionRepartidorDAO
    {
        private DBConnection db;

        public UbicacionRepartidorDAO()
        {
            db = new DBConnection();
        }

        // ✅ Obtener todas las ubicaciones
        public List<UbicacionRepartidor> ObtenerUbicaciones()
        {
            List<UbicacionRepartidor> lista = new List<UbicacionRepartidor>();

            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "SELECT * FROM UbicacionRepartidor";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UbicacionRepartidor u = new UbicacionRepartidor
                    {
                        IdUbicacion = reader.GetInt32("idUbicacion"),
                        IdRepartidor = reader.GetInt32("idRepartidor"),
                        Latitud = reader.GetDecimal("latitud"),
                        Longitud = reader.GetDecimal("longitud"),
                        FechaHora = reader.GetDateTime("fechaHora")
                    };
                    lista.Add(u);
                }

                reader.Close();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ubicaciones: " + ex.Message);
            }

            return lista;
        }

        // ✅ Insertar ubicación
        public bool InsertarUbicacion(UbicacionRepartidor u)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "INSERT INTO UbicacionRepartidor (idRepartidor, latitud, longitud, fechaHora) VALUES (@repartidor, @lat, @lon, @fecha)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@repartidor", u.IdRepartidor);
                cmd.Parameters.AddWithValue("@lat", u.Latitud);
                cmd.Parameters.AddWithValue("@lon", u.Longitud);
                cmd.Parameters.AddWithValue("@fecha", u.FechaHora);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar ubicación: " + ex.Message);
                return false;
            }
        }

        // ✅ Eliminar ubicación
        public bool EliminarUbicacion(int id)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "DELETE FROM UbicacionRepartidor WHERE idUbicacion=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar ubicación: " + ex.Message);
                return false;
            }
        }
    }
}