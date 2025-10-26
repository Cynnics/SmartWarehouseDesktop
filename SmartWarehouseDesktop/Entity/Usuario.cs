using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }  // ADMIN, CLIENTE, REPARTIDOR

        public Usuario() { }

        public Usuario(int id, string nombre, string email, string password, string rol)
        {
            IdUsuario = id;
            Nombre = nombre;
            Email = email;
            Password = password;
            Rol = rol;
        }

        public override string ToString()
        {
            return $"{Nombre} ({Rol})";
        }
    }
}
