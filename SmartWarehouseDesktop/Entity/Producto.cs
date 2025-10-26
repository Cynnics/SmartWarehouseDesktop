using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.Entity
{
    class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, decimal precio, int stock, string categoria)
        {
            IdProducto = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Precio:C2} ({Stock} uds)";
        }
    }
}
