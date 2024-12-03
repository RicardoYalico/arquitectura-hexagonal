using System;
using System.Collections.Generic;
using System.Text;
using My_API.Domain.Entities;
using My_API.Domain.Interfaces.Repository;
using System.Linq;
using My_API.Infrastructure.DataSource.Context;

namespace My_API.Infrastructure.DataSource.Implementation.Repository
{
    public class UserRepository : IUserRepository, IRepositorioBase<User, int>
    {
        private AppDbContext db;

        public UserRepository(AppDbContext _db)
        {
            db = _db;
        }

        User IRepositorioBase<User, int>.Agregar(User entidad)
        {
            db.Users.Add(entidad);
            return entidad;
        }

        User IRepositorioBase<User, int>.Editar(User entidad)
        {
            var userSeleccionado = db.Users.Where(c => c.UserID == entidad.UserID).FirstOrDefault();
            if (userSeleccionado != null)
            {
                userSeleccionado.Name = entidad.Name;

                db.Entry(userSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return entidad;
        }

        User IRepositorioBase<User, int>.Eliminar(int id)
        {
            var usuarioSeleccionado = db.Users.Where(c => c.UserID == id).FirstOrDefault();
            if (usuarioSeleccionado != null)
            {
                db.Users.Remove(usuarioSeleccionado);
            }
            return usuarioSeleccionado;
        }

        //void IRepositorioBase<User, int>.GuardarTodosLosCambios()
        //{
        //    throw new NotImplementedException();
        //}

        User IRepositorioBase<User, int>.Obtener(int id)
        {
            var userSeleccionado = db.Users.Where(c => c.UserID == id).FirstOrDefault();
            return userSeleccionado;
        }
    }
}
