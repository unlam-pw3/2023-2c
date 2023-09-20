using Clase4.POO.Logica.ObjetosMagicos;

namespace Clase4.POO.Logica.Servicios
{
    public interface IObjetoMagicoService
    {
        bool Agregar(ObjetoMagico objetoMagico);
        List<ObjetoMagico> Listar();
        bool Actualizar(ObjetoMagico objetoMagico);
        ObjetoMagico ObtenerPorId(Guid id);

        void Limpiar();
    }

    public class ObjetoMagicoService : IObjetoMagicoService
    {
        private static readonly List<ObjetoMagico> _objetosMagicos = new()
        {
            new Veneno("Hiedra venenosa", "Produce mareos y perdida de conocimiento"),
            new PocionCuracion("Lata de espinaca", "Otorga fuerza extraordinaria temporalmente"),
        };

        public bool Agregar(ObjetoMagico objetoMagico)
        {
            if (ObjetoMagicoService._objetosMagicos.Any(o => o.Nombre == objetoMagico.Nombre))
                throw new Exception("Ya existe un objeto mágico con ese nombre");

            ObjetoMagicoService._objetosMagicos.Add(objetoMagico);
            return true;
        }

        public List<ObjetoMagico> Listar() => ObjetoMagicoService._objetosMagicos;
        
        public bool Actualizar(ObjetoMagico objetoMagico)
        {
            var objetoMagicoEncontrado = ObtenerPorId(objetoMagico.Id) ?? throw new Exception("No se encontró el objeto mágico");
            ObjetoMagicoService._objetosMagicos.Remove(objetoMagicoEncontrado);
            ObjetoMagicoService._objetosMagicos.Add(objetoMagico);
            return true;
        }

        public ObjetoMagico ObtenerPorId(Guid id) => ObjetoMagicoService._objetosMagicos.Find(o => o.Id == id) ?? throw new Exception("No se encontró el objeto mágico");

        public void Limpiar() => ObjetoMagicoService._objetosMagicos.Clear();
    }
}