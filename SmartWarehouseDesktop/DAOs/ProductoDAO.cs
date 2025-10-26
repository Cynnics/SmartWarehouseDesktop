using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWarehouseDesktop.Conexion;

namespace SmartWarehouseDesktop.Entity
{
    class ProductoDAO
    {
        private DBConnection db;

        public ProductoDAO()
        {
            db = new DBConnection();
        }

        // Obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "SELECT * FROM Producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto
                    {
                        IdProducto = reader.GetInt32("idProducto"),
                        Nombre = reader.GetString("nombre"),
                        Descripcion = reader.GetString("descripcion"),
                        Precio = reader.GetDecimal("precio"),
                        Stock = reader.GetInt32("stock"),
                        Categoria = reader.IsDBNull(reader.GetOrdinal("categoria")) ? null : reader.GetString("categoria")
                    };
                    lista.Add(p);
                }

                reader.Close();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return lista;
        }
        // Insertar un producto
        public bool InsertarProducto(Producto p)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "INSERT INTO Producto (nombre, descripcion, precio, stock, categoria) VALUES (@nombre, @descripcion, @precio, @stock, @categoria)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@categoria", p.Categoria);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar producto: " + ex.Message);
                return false;
            }
        }

        // Actualizar un producto
        public bool ActualizarProducto(Producto p)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "UPDATE Producto SET nombre=@nombre, descripcion=@descripcion, precio=@precio, stock=@stock, categoria=@categoria WHERE idProducto=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@categoria", p.Categoria);
                cmd.Parameters.AddWithValue("@id", p.IdProducto);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar producto: " + ex.Message);
                return false;
            }
        }

        // Eliminar un producto
        public bool EliminarProducto(int id)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "DELETE FROM Producto WHERE idProducto=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
                return false;
            }
        }
    }
}
