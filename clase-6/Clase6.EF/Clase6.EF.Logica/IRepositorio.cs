namespace Clase6.EF.Logica; 
public interface IRepositorio<T> 
{
    List<T> ObtenerTodos();
    T? ObtenerPorId(int id);
    void Agregar(T obj);
    void Actualizar(T obj);
    void Eliminar(int id);
}