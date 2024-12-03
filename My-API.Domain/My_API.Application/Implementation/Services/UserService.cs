using System;
using System.Collections.Generic;
using System.Text;
using My_API.Domain.Entities;
using My_API.Application.Interfaces.Services;
using My_API.Domain.Interfaces.Repository;

namespace My_API.Application.Implementation.Services
{
    public class UserService : IUserService<User, int>
    {

        private readonly IRepositorioBase<User, int> repositorioBase;

        public UserService(IRepositorioBase<User, int> _repositorioBase) {
            repositorioBase = _repositorioBase;
        }

        public User Agregar(User entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'User' es requerido");

            var resultUser = repositorioBase.Agregar(entidad);
            //repositorioBase.GuardarTodosLosCambios();
            return resultUser;
        }

        public User Editar(User entidad)
        {
            var resultUser = repositorioBase.Editar(entidad);
            //repositorioBase.GuardarTodosLosCambios();
            return resultUser;
        }

        public User Eliminar(int id)
        {
            var resultUser = repositorioBase.Eliminar(id);
            //repositorioBase.GuardarTodosLosCambios();
            return resultUser;
        }

        public User Obtener(int id)
        {
            var resultUser = repositorioBase.Obtener(id);
            return resultUser;
        }
    }
}
