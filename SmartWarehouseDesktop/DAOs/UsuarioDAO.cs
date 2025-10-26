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
    class UsuarioDAO
    {
        private DBConnection db;

        public UsuarioDAO()
        {
            db = new DBConnection();
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "SELECT * FROM Usuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario u = new Usuario
                    {
                        IdUsuario = reader.GetInt32("idUsuario"),
                        Nombre = reader.GetString("nombre"),
                        Email = reader.GetString("email"),
                        Password = reader.GetString("password"),
                        Rol = reader.GetString("rol")
                    };
                    lista.Add(u);
                }

                reader.Close();
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }

            return lista;
        }

        // Insertar un usuario
        public bool InsertarUsuario(Usuario u)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "INSERT INTO Usuario (nombre, email, password, rol) VALUES (@nombre, @correo, @pass, @rol)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Email);
                cmd.Parameters.AddWithValue("@pass", u.Password);
                cmd.Parameters.AddWithValue("@rol", u.Rol);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
                return false;
            }
        }

        // Actualizar usuario
        public bool ActualizarUsuario(Usuario u)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "UPDATE Usuario SET nombre=@nombre, email=@correo, password=@pass, rol=@rol WHERE idUsuario=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Email);
                cmd.Parameters.AddWithValue("@pass", u.Password);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                cmd.Parameters.AddWithValue("@id", u.IdUsuario);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar usuario: " + ex.Message);
                return false;
            }
        }

        // Eliminar usuario
        public bool EliminarUsuario(int id)
        {
            try
            {
                var conn = db.GetConnection();
                db.OpenConnection();

                string query = "DELETE FROM Usuario WHERE idUsuario=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                db.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                return false;
            }
        }
    }
}