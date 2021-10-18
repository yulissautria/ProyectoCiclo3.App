using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        private readonly AppContext _appContext = new AppContext();
 
    
 
      public IEnumerable<Servicio> GetAll()
        {
           return _appContext.Servicios.Include(u => u.origen)
                       .Include(u => u.destino).
                       Include(e => e.encomienda);
        }
          public Servicio GetServiWithId(int servicioid){
            return _appContext.Servicios.Find(servicioid);
        }
        
        public Servicio Create(int origen,int destino,string fecha,string hora, int encomienda)
        {
          var newServicio = new Servicio();
          newServicio.destino = _appContext.Usuarios.Find(destino);
          newServicio.origen = _appContext.Usuarios.Find(origen);
          newServicio.encomienda = _appContext.Encomiendas.Find(encomienda);
          newServicio.fecha = DateTime.Parse(fecha);
          newServicio.hora = hora;
          
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;
        }
       public Servicio Update(Servicio newServicio){
            var serv= _appContext.Servicios.Find(newServicio.id);
            if(serv != null){
                serv.id= newServicio.id;
                serv.origen= newServicio.origen;
                serv.destino= newServicio.destino;
                serv.encomienda= newServicio.encomienda;
                serv.hora= newServicio.hora;
                serv.fecha= newServicio.fecha;
                _appContext.SaveChanges();
                
            }
        return serv;
        }
        public void Delete(int id)
        {
        var serv = _appContext.Servicios.Find(id);
        if (serv == null)
            return;
        _appContext.Servicios.Remove(serv);
        _appContext.SaveChanges();

        }
      
    }

    
}