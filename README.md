# 🏭 SmartWarehouseDesktop

**SmartWarehouseDesktop** es una aplicación de escritorio desarrollada como parte del **Trabajo de Fin de Grado (TFG)** del ciclo formativo de **Desarrollo de Aplicaciones Multiplataforma (DAM)**.  
El objetivo principal es ofrecer una herramienta práctica para **gestionar el inventario, pedidos y usuarios** de un almacén de forma eficiente.

---

## 🧠 Objetivo del proyecto

Desarrollar un sistema de escritorio capaz de:
- Controlar y visualizar el **stock de productos**.
- Gestionar **pedidos, clientes y repartidores**.
- Mantener una **base de datos MySQL** actualizada en tiempo real.
- Servir como base para futuras integraciones multiplataforma (Android, web o GPS).

El proyecto busca simular un entorno empresarial real, aplicando buenas prácticas de programación, diseño orientado a objetos y persistencia de datos.

---

## ⚙️ Tecnologías utilizadas

| Tecnología | Descripción |
|-------------|-------------|
| 🧩 **C# (.NET Framework)** | Lenguaje principal de la app de escritorio |
| 🗄️ **MySQL** | Base de datos relacional |
| 💻 **Visual Studio 2022** | Entorno de desarrollo integrado (IDE) |
| 🔗 **MySQL.Data (Connector)** | Conector oficial de MySQL para .NET |
| 🌐 **Git + GitHub** | Control de versiones y alojamiento del código |

---

## 🧱 Estructura del proyecto

SmartWarehouseDesktop/
├── DBConnection.cs # Clase de conexión con MySQL
│
├── Models/
│ ├── Producto.cs
│ ├── Usuario.cs
│ ├── Pedido.cs
│ ├── DetallePedido.cs
│ └── UbicacionRepartidor.cs
│
├── DAO/
│ ├── ProductoDAO.cs
│ ├── UsuarioDAO.cs
│ ├── PedidoDAO.cs
│ ├── DetallePedidoDAO.cs
│ └── UbicacionRepartidorDAO.cs
│
├── Forms/
│ ├── FormProductos.cs
│ ├── FormUsuarios.cs
│ ├── FormPedidos.cs
│ └── Prompt.cs
│
├── SmartWarehouseDesktop.sln # Solución del proyecto
└── README.md # Este archivo

> 💡 Estructura modular: cada entidad tiene su propia clase de datos y su DAO asociado.

---

## 🖥️ Funcionalidades principales

- 📦 **Gestión de productos**  
  CRUD completo: alta, baja, modificación y listado.

- 👥 **Gestión de usuarios**  
  Control de roles (administrador, cliente, repartidor).

- 🚚 **Gestión de pedidos**  
  Relación entre clientes, productos y repartidores.

- 📍 **Ubicación de repartidores** *(para futuras integraciones)*  
  Permite registrar coordenadas y asociarlas a un pedido.

---

## 🧰 Instalación y ejecución

### 1️⃣ Requisitos previos
- Visual Studio 2019 / 2022  
- MySQL Server y MySQL Workbench  
- MySQL Connector/.NET instalado  
- Git (opcional, para clonar el repositorio)

### 2️⃣ Clonar el repositorio

git clone https://github.com/tuUsuario/SmartWarehouseDesktop.git
3️⃣ Configurar la base de datos
Crear una base de datos smartwarehouse_db en MySQL.

Ejecutar el script SQL incluido (database_script.sql).

Ajustar los datos de conexión en DBConnection.cs:

csharp
Copiar código
private string server = "localhost";
private string database = "smartwarehouse_db";
private string uid = "root";
private string password = "tu_contraseña";
4️⃣ Ejecutar el proyecto
Abrir SmartWarehouseDesktop.sln en Visual Studio.

Compilar y ejecutar con F5.

📸 Capturas de pantalla (opcional)
Añade aquí imágenes de la app en funcionamiento:

Pantalla principal

CRUD de productos

CRUD de usuarios

📚 Autor y créditos
👤 Autor: [Tu nombre completo]
🎓 Ciclo Formativo: Desarrollo de Aplicaciones Multiplataforma (DAM)
🏫 Centro: [Nombre del centro educativo]
📅 Año académico: 2025

🧩 Futuras mejoras
Implementación de versión Android sincronizada.

Integración con GPS para seguimiento de repartidores.

Exportación de reportes en PDF/Excel.

Sistema de autenticación avanzada por roles.

📜 Licencia
Este proyecto se publica bajo la licencia MIT, lo que permite su uso y modificación libremente con fines educativos.

🧾 Estado del proyecto
✅ Base de datos implementada
✅ CRUD de productos funcional
🟡 CRUD de usuarios en desarrollo
🔜 Interfaz mejorada y funcionalidades extendidas
