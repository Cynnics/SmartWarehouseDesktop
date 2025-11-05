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
    public class FacturaDAO
    {
        private DBConnection db = new DBConnection();

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            string query = "SELECT * FROM Factura";

            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Factura f = new Factura
                        {
                            IdFactura = reader.GetInt32("idFactura"),
                            IdPedido = reader.GetInt32("idPedido"),
                            FechaEmision = reader.GetDateTime("fechaEmision"),
                            Subtotal = reader.GetDecimal("subtotal"),
                            IVA = reader.GetDecimal("iva"),
                            Total = reader.GetDecimal("total")
                        };
                        facturas.Add(f);
                    }
                }
            }
            return facturas;
        }

        public bool InsertarFactura(Factura f)
        {
            string query = @"INSERT INTO Factura (idPedido, fechaEmision, subtotal, iva, total)
                             VALUES (@pedido, @fecha, @sub, @iva, @total)";

            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pedido", f.IdPedido);
                cmd.Parameters.AddWithValue("@fecha", f.FechaEmision);
                cmd.Parameters.AddWithValue("@sub", f.Subtotal);
                cmd.Parameters.AddWithValue("@iva", f.IVA);
                cmd.Parameters.AddWithValue("@total", f.Total);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarFactura(int idFactura)
        {
            string query = "DELETE FROM Factura WHERE idFactura = @id";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idFactura);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarFactura(Factura f)
        {
            string query = @"UPDATE Factura 
                             SET subtotal=@sub, iva=@iva, total=@total 
                             WHERE idFactura=@id";
            using (var conn = db.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sub", f.Subtotal);
                cmd.Parameters.AddWithValue("@iva", f.IVA);
                cmd.Parameters.AddWithValue("@total", f.Total);
                cmd.Parameters.AddWithValue("@id", f.IdFactura);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}