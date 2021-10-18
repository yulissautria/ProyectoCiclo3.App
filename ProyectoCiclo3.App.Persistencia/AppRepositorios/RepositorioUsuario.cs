using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
       
        private readonly AppContext _appContext = new AppContext();
        
        public IEnumerable<Usuario> GetAll()
        {
            return _appContext.Usuarios;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuarios.Find(id);
        }

        public Usuario Create(Usuario newUsuario)
        {
            var addUsuario = _appContext.Usuarios.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;
        }

        public Usuario Update(Usuario newUsuario){
            var usuario = _appContext.Usuarios.Find(newUsuario.id);

            if(usuario != null){
                usuario.nombres = newUsuario.nombres;
                usuario.apellidos = newUsuario.apellidos;
                usuario.dirección = newUsuario.dirección;
                usuario.teléfono = newUsuario.teléfono;
              
                //Guardar en base de datos
                _appContext.SaveChanges();
            }
        return usuario;
        }

        public void Delete(int id)
        {
        var user= _appContext.Usuarios.Find(id);
        if (user == null)
            return;
        _appContext.Usuarios.Remove(user);
        _appContext.SaveChanges();
        }
    }
}