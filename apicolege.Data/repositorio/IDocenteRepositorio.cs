using apicolege.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicolege.Data.repositorio
{
    public interface IDocenteRepositorio
    {
        Task<IEnumerable<Docente>> GetAllDocente();
        Task<Docente> GetDetails(int id);
    }
}
