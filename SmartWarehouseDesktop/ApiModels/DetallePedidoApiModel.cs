namespace SmartWarehouseDesktop.ApiModels
{
    public class DetallePedidoApiModel
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }

}
