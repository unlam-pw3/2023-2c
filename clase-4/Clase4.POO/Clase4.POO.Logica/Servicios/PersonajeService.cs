namespace Clase4.POO.Logica.Servicios
{
    public interface IPersonajeService
    {
        void Agregar(Personaje personaje);
        List<Personaje> Listar();
        Personaje? Actualizar(Personaje personaje);
        Personaje? ObtenerPorId(Guid id);
    }
    public class PersonajeService: IPersonajeService
    {
        private static List<Personaje> personajes = new List<Personaje>()
        {
            new Personaje(
                 "Gandalf",
                 100,
                 100),
            new Personaje("Saruman",
                75,
                75)
        };

        public void Agregar(Personaje personaje)
        {
            personajes.Add(personaje);
        }

        public List<Personaje> Listar()
        {
            return personajes;
        }

       public Personaje? Actualizar(Personaje personaje)
        {
            var personajeEncontrado = ObtenerPorId(personaje.Id);
            if (personajeEncontrado != null)
            {
                personajeEncontrado.Nombre = personaje.Nombre;
                personajeEncontrado.HP = personaje.HP;
                personajeEncontrado.XP = personaje.XP;
            }
            return personajeEncontrado;
        }

        public Personaje? ObtenerPorId(Guid id)
        {
            return personajes.Find(p => p.Id == id);
        }
    }
}
