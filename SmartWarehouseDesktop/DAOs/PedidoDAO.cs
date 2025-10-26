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
    class PedidoDAO
    {
        private DBConnection db;

        public PedidoDAO()
        {
            db = new DBConnection();
        }

        // Obtener todos los pedidos
        public List<Pedido> ObtenerPedidos()
        {
            List<Pedido> lista = new List<Pedido>();

            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "SELECT * FROM Pedido";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pedido p = new Pedido
                    {
                        IdPedido = reader.GetInt32("idPedido"),
                        FechaPedido = reader.GetDateTime("fechaPedido"),
                        Estado = reader.GetString("estado"),
                        IdCliente = reader.GetInt32("idCliente"),
                        IdRepartidor = reader.IsDBNull(reader.GetOrdinal("idRepartidor")) ? (int?)null : reader.GetInt32("idRepartidor")
                    };
                    lista.Add(p);
                }

                reader.Close();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedidos: " + ex.Message);
            }

            return lista;
        }

        // ✅ Insertar un pedido
        public bool InsertarPedido(Pedido p)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "INSERT INTO Pedido (fechaPedido, estado, idCliente, idRepartidor) VALUES (@fecha, @estado, @cliente, @repartidor)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", p.FechaPedido);
                cmd.Parameters.AddWithValue("@estado", p.Estado);
                cmd.Parameters.AddWithValue("@cliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@repartidor", p.IdRepartidor);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar pedido: " + ex.Message);
                return false;
            }
        }

        // ✅ Actualizar un pedido
        public bool ActualizarPedido(Pedido p)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "UPDATE Pedido SET fechaPedido=@fecha, estado=@estado, idCliente=@cliente, idRepartidor=@repartidor WHERE idPedido=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", p.FechaPedido);
                cmd.Parameters.AddWithValue("@estado", p.Estado);
                cmd.Parameters.AddWithValue("@cliente", p.IdCliente);
                cmd.Parameters.AddWithValue("@repartidor", p.IdRepartidor);
                cmd.Parameters.AddWithValue("@id", p.IdPedido);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar pedido: " + ex.Message);
                return false;
            }
        }

        // ✅ Eliminar pedido
        public bool EliminarPedido(int id)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "DELETE FROM Pedido WHERE idPedido=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar pedido: " + ex.Message);
                return false;
            }
        }
    }
}