
namespace SmartWarehouseDesktop.ApiModels
{
    
    // Modelo para capturar respuestas de error enviadas por la API
    // cuando el login falla o algo sale mal.
    public class ApiErrorResponse
    {
        public string Error { get; set; }
    }
}
