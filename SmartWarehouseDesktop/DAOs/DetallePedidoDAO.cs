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
    class DetallePedidoDAO
    {
        private DBConnection db;

        public DetallePedidoDAO()
        {
            db = new DBConnection();
        }

        // ✅ Obtener todos los detalles
        public List<DetallePedido> ObtenerDetalles()
        {
            List<DetallePedido> lista = new List<DetallePedido>();

            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "SELECT * FROM DetallePedido";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DetallePedido d = new DetallePedido
                    {
                        IdDetalle = reader.GetInt32("idDetalle"),
                        IdPedido = reader.GetInt32("idPedido"),
                        IdProducto = reader.GetInt32("idProducto"),
                        Cantidad = reader.GetInt32("cantidad"),
                        Subtotal = reader.GetDecimal("subtotal")
                    };
                    lista.Add(d);
                }

                reader.Close();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener detalles: " + ex.Message);
            }

            return lista;
        }

        // ✅ Insertar detalle
        public bool InsertarDetalle(DetallePedido d)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "INSERT INTO DetallePedido (idPedido, idProducto, cantidad, subtotal) VALUES (@pedido, @producto, @cantidad, @subtotal)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pedido", d.IdPedido);
                cmd.Parameters.AddWithValue("@producto", d.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                cmd.Parameters.AddWithValue("@subtotal", d.Subtotal);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar detalle: " + ex.Message);
                return false;
            }
        }

        // ✅ Actualizar detalle
        public bool ActualizarDetalle(DetallePedido d)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "UPDATE DetallePedido SET idPedido=@pedido, idProducto=@producto, cantidad=@cantidad, subtotal=@subtotal WHERE idDetalle=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pedido", d.IdPedido);
                cmd.Parameters.AddWithValue("@producto", d.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                cmd.Parameters.AddWithValue("@subtotal", d.Subtotal);
                cmd.Parameters.AddWithValue("@id", d.IdDetalle);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar detalle: " + ex.Message);
                return false;
            }
        }

        // ✅ Eliminar detalle
        public bool EliminarDetalle(int id)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "DELETE FROM DetallePedido WHERE idDetalle=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar detalle: " + ex.Message);
                return false;
            }
        }
    }
}