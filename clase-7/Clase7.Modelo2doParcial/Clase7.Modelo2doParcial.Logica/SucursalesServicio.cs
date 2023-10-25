using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase7.Modelo2doParcial.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Clase7.Modelo2doParcial.Logica;

public interface ISucursalesServicio
{
    List<Sucursal> Listar();
    void Crear(Sucursal sucursal);
    List<Sucursal> Filtrar(int? idCadena);
    void Eliminar(int id);
}

public class SucursalesServicio : ISucursalesServicio
{
    private Pw32cModelo2doParcialContext _contexto;

    public SucursalesServicio(Pw32cModelo2doParcialContext contexto)
    {
        _contexto = contexto;
    }

    public List<Sucursal> Listar()
    {
        return _contexto.Sucursals.Include(t => t.IdCadenaNavigation).ToList();
    }
    public void Crear(Sucursal sucursal)
    {
        _contexto.Sucursals.Add(sucursal);
        _contexto.SaveChanges();
    }

    public List<Sucursal> Filtrar(int? idCadena)
    {
        return _contexto.Sucursals.Where(s => s.IdCadena == idCadena).ToList();
    }

    public void Eliminar(int id)
    {
        var sucursal = _contexto.Sucursals.Find(id);
        if (sucursal != null)
        {
            _contexto.Sucursals.Remove(sucursal);
            _contexto.SaveChanges();
        }
    }
}


