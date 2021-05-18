using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareaDiplomado.Interfaces;

namespace TareaDiplomado.Db
{
    public class Operaciones<T> : IGeneric<T> where T : class
    {

        Datos datos = new Datos();
        DbSet<T> entidad;
        public Operaciones()
        {
            entidad = datos.Set<T>();   
        }

        public void Borrar(int id)
        {
            var borrar = entidad.Find(id);

            if (borrar != null)
            {
                entidad.Remove(borrar);
                datos.SaveChanges();
            }
        }

        public T Buscar(int id)
        {
          try
            {
                return entidad.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Guardar(T obj)
        {
                entidad.Add(obj);
                datos.SaveChanges();   
        }

        public async  Task<List<T>> Listar()
        {
            try
            {
                return await entidad.ToListAsync();
            }
            catch 
            {
                return null;
            }
        }

        public async void  Modificar(int id , T obj)
        {                       
             datos.Update(obj);
             await datos.SaveChangesAsync();
            
        }
    }
}
