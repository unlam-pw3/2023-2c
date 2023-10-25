using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase7.Modelo2doParcial.Data.EF;

namespace Clase7.Modelo2doParcial.Logica
{
    public interface ICadenasServicio
    {
        List<Cadena> Listar();
    }

    public class CadenasServicio : ICadenasServicio
    {
        private Pw32cModelo2doParcialContext _contexto;

        public CadenasServicio(Pw32cModelo2doParcialContext contexto)
        {
            _contexto = contexto;
        }
        public List<Cadena> Listar()
        {
            return _contexto.Cadenas.OrderBy(c => c.RazonSocial).ToList();
        }
    }
}
