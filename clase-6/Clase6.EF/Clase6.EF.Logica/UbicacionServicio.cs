using System.Collections.Generic;
using System.Linq;
using Clase6.EF.Data.EF;
using Clase6.EF.Logica;

namespace Clase6.EF.Logica
{
    public interface IUbicacionServicio: IRepositorio<Ubicacion>
    {
        Ubicacion? ObtenerPorNombre(string nombre); // Add nullability annotation
    }

    public class UbicacionServicio : IUbicacionServicio
    {
        private readonly Pw32cIslaTesoroContext _context;

        public UbicacionServicio(Pw32cIslaTesoroContext context)
        {
            this._context = context;
        }

        public void Actualizar(Ubicacion ubicacion)
        {
            this._context.Ubicacions.Update(ubicacion);
            this._context.SaveChanges();
        }

        public void Agregar(Ubicacion ubicacion)
        {
            this._context.Ubicacions.Add(ubicacion);
            this._context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var ubicacion = this.ObtenerPorId(id);

            if (ubicacion == null)
                return;

            this._context.Ubicacions.Remove(ubicacion);
            this._context.SaveChanges();
        }

        public Ubicacion? ObtenerPorId(int id)
        {
            return this._context.Ubicacions.Find(id);
        }

        public Ubicacion? ObtenerPorNombre(string nombre)
        {
            return this._context.Ubicacions.FirstOrDefault(x => x.Nombre == nombre);
        }

        public List<Ubicacion> ObtenerTodos()
        {
            return this._context.Ubicacions.ToList();
        }
    }
}