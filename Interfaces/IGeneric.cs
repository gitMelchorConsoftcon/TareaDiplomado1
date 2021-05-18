using System.Collections.Generic;
using System.Threading.Tasks;

namespace TareaDiplomado.Interfaces
{
    public interface IGeneric<T>
    {
        void Guardar(T obj);
        Task<List<T>> Listar();
        T Buscar(int id);
        void Borrar(int id);
        void Modificar(int id,T obj);

    }
}
