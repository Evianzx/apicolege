using apicolege.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.Data.repositorio
{
   public interface IAsignaturaRepositorio
    {
        Task<IEnumerable<Asignatura>> GetAllAsignatura();
        Task<Asignatura> GetDetails(int id);
        Task<bool> InsertcAsignatura(Asignatura asignatura);
        Task<bool> UpdateAsignatura(Asignatura asignatura);
        Task<bool> DeleteAsignatura(Asignatura asignatura);
        Task<object?> GetAsignaturaDetails(int id);
        Task<bool> InsertcInscrito(Inscrito inscrito);
    }
}
