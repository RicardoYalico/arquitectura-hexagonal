using System;
using System.Collections.Generic;
using System.Text;

namespace My_API.Application.Interfaces.Services
{
    public interface IServiceBase<TEntity, TEntityID>
    {
        public TEntity Agregar(TEntity entidad);
        public TEntity Editar(TEntity id);
        public TEntity Eliminar(TEntityID id);
        public TEntity Obtener(TEntityID id);

    }
}
