using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace My_API.Domain.Interfaces.Repository
{
    public interface IRepositorioBase<TEntidad, TEntidadID> 
    {
        public TEntidad Agregar(TEntidad entidad);
        public TEntidad Editar(TEntidad entidad);
        public TEntidad Eliminar(TEntidadID id);
        public TEntidad Obtener(TEntidadID id);
        //void GuardarTodosLosCambios();
    }
}
